using LinkConverter.API.Model;
using LinkConverter.API.Model.Exceptions;
using System;
using System.Collections.Specialized;
using System.Web;

namespace LinkConverter.API.Core
{
    public class LinkBuilder : ILinkBuilder
    {
        private readonly Uri sourceUri;
        private readonly NameValueCollection sourceQueryString;

        public LinkBuilder(string link) 
        {
            if(!Uri.TryCreate(link, UriKind.RelativeOrAbsolute, out sourceUri))
            {
                throw new ValidationException($"Not valid link : {link ?? ""}");
            }

            sourceQueryString = HttpUtility.ParseQueryString(sourceUri.Query);
        }
        
        public string GetParameterWithName(string name)
        {
            string parameter = sourceQueryString.Get(name);

            if(parameter == null)
            {
                return parameter;
            }

            //This method was addded for percentage encoding of Turkish character
            return Uri.EscapeUriString(parameter);
        }

        public string CreateDeeplink(string scheme, string query)
        {
            return $"{scheme}://?{query}";
        }

        public string CreateLink(UriBuilderRequest builderRequest)
        {
            UriBuilder uriBuilder = new UriBuilder(builderRequest.Scheme, builderRequest.Host)
            {
                Path = builderRequest.Path,
                Query = builderRequest.Query
            };
            return uriBuilder.ToString();
        }
    }
}
