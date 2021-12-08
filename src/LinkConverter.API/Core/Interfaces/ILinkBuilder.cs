using LinkConverter.API.Core.Pages;
using LinkConverter.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkConverter.API.Core
{
    public interface ILinkBuilder
    {
        public string GetParameterWithName(string name);

        public string CreateDeeplink(string scheme, string query);

        public string CreateLink(UriBuilderRequest builderRequest);
    }
}
