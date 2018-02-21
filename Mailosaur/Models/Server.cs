// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Mailosaur.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Server
    {
        /// <summary>
        /// Initializes a new instance of the Server class.
        /// </summary>
        public Server()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Server class.
        /// </summary>
        /// <param name="id">Unique identifier for the server. Used as username
        /// for SMTP/POP3 authentication.</param>
        /// <param name="password">SMTP/POP3 password.</param>
        /// <param name="name">A name used to identify the server.</param>
        /// <param name="users">Users (excluding administrators) who have
        /// access to the server.</param>
        /// <param name="messages">The number of messages currently in the
        /// server.</param>
        /// <param name="forwardingRules">The rules used to manage email
        /// forwarding for this server.</param>
        public Server(string id = default(string), string password = default(string), string name = default(string), IList<System.Guid?> users = default(IList<System.Guid?>), int? messages = default(int?), IList<ForwardingRule> forwardingRules = default(IList<ForwardingRule>))
        {
            Id = id;
            Password = password;
            Name = name;
            Users = users;
            Messages = messages;
            ForwardingRules = forwardingRules;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets unique identifier for the server. Used as username for
        /// SMTP/POP3 authentication.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets SMTP/POP3 password.
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a name used to identify the server.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets users (excluding administrators) who have access to
        /// the server.
        /// </summary>
        [JsonProperty(PropertyName = "users")]
        public IList<System.Guid?> Users { get; set; }

        /// <summary>
        /// Gets or sets the number of messages currently in the server.
        /// </summary>
        [JsonProperty(PropertyName = "messages")]
        public int? Messages { get; set; }

        /// <summary>
        /// Gets or sets the rules used to manage email forwarding for this
        /// server.
        /// </summary>
        [JsonProperty(PropertyName = "forwardingRules")]
        public IList<ForwardingRule> ForwardingRules { get; set; }

    }
}