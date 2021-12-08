using System.ComponentModel.DataAnnotations;

namespace LinkConverter.API.Model
{
    public class ConversionRequest
    {
        /// <summary>
        /// Conversion requested link
        /// </summary>
        public string Link { get; set; }
    }
}
