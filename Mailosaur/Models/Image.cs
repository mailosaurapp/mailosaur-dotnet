// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Mailosaur.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Image
    {
        /// <summary>
        /// Initializes a new instance of the Image class.
        /// </summary>
        public Image()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Image class.
        /// </summary>
        public Image(string src = default(string), string alt = default(string))
        {
            Src = src;
            Alt = alt;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "src")]
        public string Src { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "alt")]
        public string Alt { get; set; }

    }
}
