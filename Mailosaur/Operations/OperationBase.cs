namespace Mailosaur.Operations
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Mailosaur.Models;
    using Newtonsoft.Json;

    public class OperationBase
    {
        /// <summary>
        /// Initializes a new instance of the OperationBase class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the HttpClient.
        /// </param>
        public OperationBase(HttpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Gets a reference to the HttpClient
        /// </summary>
        private readonly HttpClient _client;

        public Task ExecuteRequest(HttpMethod method, string path, object body = null)
        {
            return ExecuteRequest<object>(method, path, body, HttpStatusCode.NoContent);
        }

        public async Task<T> ExecuteRequest<T>(HttpMethod method, string path, object body = null, HttpStatusCode expectedStatus = HttpStatusCode.OK)
        {
            using (var request = new HttpRequestMessage(method, path))
            {
                if (body != null)
                {
                    var requestContent = JsonConvert.SerializeObject(body);
                    request.Content = new StringContent(requestContent, Encoding.UTF8, "application/json");
                }

                using (var response = await _client.SendAsync(request))
                {
                    if (response.StatusCode != expectedStatus)
                        await ThrowExceptionAsync(response);

                    if (response.StatusCode != HttpStatusCode.NoContent)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        if (typeof(T) != typeof(MessageListResultWithHeaders))
                            return JsonConvert.DeserializeObject<T>(content);
                        
                        response.Headers.TryGetValues("x-ms-delay", out IEnumerable<string> delayHeaderValues);
                        
                        return (T)(object)new MessageListResultWithHeaders() {
                            MessageListResult = JsonConvert.DeserializeObject<MessageListResult>(content),
                            DelayHeader = delayHeaderValues?.FirstOrDefault()
                        };
                    }

                    return default(T);
                }
            }
        }

        public async Task<Stream> ExecuteStreamRequest(HttpMethod method, string path, object body = null)
        {
            var request = new HttpRequestMessage(method, path);

            if (body != null)
            {
                var requestContent = JsonConvert.SerializeObject(body);
                request.Content = new StringContent(requestContent, Encoding.UTF8, "application/json");
            }

            var response = await _client.SendAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
                await ThrowExceptionAsync(response);

            request.Dispose();

            return await response.Content.ReadAsStreamAsync();
        }

        public void HandleAggregateException(Action requestMethod)
        {
            try
            {
                requestMethod();
            }
            catch (AggregateException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T HandleAggregateException<T>(Func<T> requestMethod)
        {
            try
            {
                return requestMethod();
            }
            catch (AggregateException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string PagePath(string path, int? page = null, int? itemsPerPage = null, DateTime? receivedAfter = null)
        {
            string isoReceivedAfter = null;
            if (receivedAfter != null) {
                isoReceivedAfter = WebUtility.UrlEncode(receivedAfter.Value.ToString("o"));
            }
            
            path += page != null ? $"&page={page}" : "";
            path += itemsPerPage != null ? $"&itemsPerPage={itemsPerPage}" : "";
            path += receivedAfter != null ? $"&receivedAfter={isoReceivedAfter}" : "";
            return path;
        }

        private async Task ThrowExceptionAsync(HttpResponseMessage response)
        {
            string errorMessage = "";
            string errorType = "";

            switch (response.StatusCode) {
                case HttpStatusCode.BadRequest:
                    errorMessage = "Request had one or more invalid parameters.";
                    errorType = "invalid_request";
                    break;
                case HttpStatusCode.Unauthorized:
                    errorMessage = "Authentication failed, check your API key.";
                    errorType = "authentication_error";
                    break;
                case HttpStatusCode.Forbidden:
                    errorMessage = "Insufficient permission to perform that task.";
                    errorType = "permission_error";
                    break;
                case HttpStatusCode.NotFound:
                    errorMessage = "Request did not find any matching resources.";
                    errorType = "invalid_request";
                    break;
                default:
                    errorMessage = "An API error occurred, see httpResponse for further information.";
                    errorType = "api_error";
                    break;
            }

            var httpResponseBody = (response.StatusCode != HttpStatusCode.NoContent) ?
                await response.Content.ReadAsStringAsync() : "";

            throw new MailosaurException(errorMessage, errorType, (int)response.StatusCode, httpResponseBody);
        }
    }
}