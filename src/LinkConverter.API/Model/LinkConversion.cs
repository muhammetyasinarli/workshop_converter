using LinkConverter.API.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkConverter.API.Model
{
    public class LinkConversion
    {
        public LinkConversion(string sourceLink, string targetLink, ConversionDirection direction) 
        {
            SourceLink = sourceLink;
            TargetLink = targetLink;
            Direction = direction;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string SourceLink { get; set; }
        public string TargetLink { get; set; }
        public ConversionDirection Direction { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
