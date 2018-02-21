// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Mailosaur.Models
{
    using Microsoft.Rest;

    /// <summary>
    /// Exception thrown for an invalid response with MailosaurError
    /// information.
    /// </summary>
    public partial class MailosaurException : RestException
    {
        /// <summary>
        /// Gets information about the associated HTTP request.
        /// </summary>
        public HttpRequestMessageWrapper Request { get; set; }

        /// <summary>
        /// Gets information about the associated HTTP response.
        /// </summary>
        public HttpResponseMessageWrapper Response { get; set; }

        /// <summary>
        /// Gets or sets the body object.
        /// </summary>
        public MailosaurError Body { private get; set; }
public MailosaurError MailosaurError => Body;

        /// <summary>
        /// Initializes a new instance of the MailosaurException class.
        /// </summary>
        public MailosaurException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the MailosaurException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public MailosaurException(string message)
            : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the MailosaurException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public MailosaurException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}