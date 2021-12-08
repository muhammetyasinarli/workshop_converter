using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkConverter.API.Model
{
    public class UriBuilderRequest
    {
        public UriBuilderRequest(string scheme, string host, string path, string query)
        {
            Scheme = scheme;
            Host = host;
            Path = path;
            Query = query;
        }
        public string Scheme { get; set; }
        public string  Host { get; set; }
        public string Path { get; set; }
        public string Query { get; set; }
    }
}
