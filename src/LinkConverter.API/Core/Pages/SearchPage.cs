using LinkConverter.API.Model;
using System;
using System.Text.RegularExpressions;

namespace LinkConverter.API.Core.Pages
{
    public class SearchPage: IPage
    {
        private readonly Regex webUrlRegex;
        private readonly Regex deeplinkRegex;

        public int Priority => 1;

        public SearchPage()
        {
            webUrlRegex = new Regex(@"\b(https://www.trendyol.com/sr\?q=)\S+\b", RegexOptions.Compiled);
            deeplinkRegex = new Regex(@"\b(ty://\?Page=Search&Query=)\S+\b", RegexOptions.Compiled);
        }

        public string BuildDeeplink(string webUrl)
        {
            var  linkBuilder = new LinkBuilder(webUrl);
            var queryParam = linkBuilder.GetParameterWithName(Constants.Q_PARAM);
            string query = $"{Constants.PAGE_PARAM}={Constants.SEARCH_PARAM}&{Constants.QUERY_PARAM}={queryParam}";
            return linkBuilder.CreateDeeplink(Constants.DEEPLINK_SCHEME, query);
        }

        public string BuildWebUrl(string deeplink)
        {
            var linkBuilder = new LinkBuilder(deeplink);
            var queryParam = linkBuilder.GetParameterWithName(Constants.QUERY_PARAM);
            string query = $"{Constants.Q_PARAM}={queryParam}";
            return linkBuilder.CreateLink(new UriBuilderRequest(Constants.WEB_URL_SCHEME, Constants.WEB_URL_HOST, Constants.DEEPLINK_SEARCH_PATH, query));
        }

        public bool IsMatchWithDeeplinkPattern(string link)
        {
            if (String.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            return deeplinkRegex.IsMatch(link);
        }

        public bool IsMatchWithWebUrlPattern(string link)
        {
            if (String.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            return webUrlRegex.IsMatch(link);
        }
    }
}
