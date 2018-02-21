// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Mailosaur
{
    using Microsoft.Rest;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Files operations.
    /// </summary>
    public partial interface IFiles
    {
        /// <summary>
        /// Download an attachment
        /// </summary>
        /// <remarks>
        /// Downloads a single attachment. Simply supply the unique identifier
        /// for the required attachment.
        /// </remarks>
        /// <param name='id'>
        /// The identifier of the attachment to be downloaded.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.HttpOperationException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        Task<HttpOperationResponse<Stream>> GetAttachmentWithHttpMessagesAsync(System.Guid id, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Download EML
        /// </summary>
        /// <remarks>
        /// Downloads an EML file representing the specified email. Simply
        /// supply the unique identifier for the required email.
        /// </remarks>
        /// <param name='id'>
        /// The identifier of the email to be downloaded.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.HttpOperationException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        Task<HttpOperationResponse<Stream>> GetEmailWithHttpMessagesAsync(System.Guid id, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}