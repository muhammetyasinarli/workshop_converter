using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkConverter.API.Model
{
    public class ConversionResponse
    {
        public ConversionResponse(string link)
        {
            Link = link;
        }

        /// <summary>
        /// Link resulting from conversion
        /// </summary>
        public string Link { get; set; }
    }
}
