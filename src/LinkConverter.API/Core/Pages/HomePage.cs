using System.Text.RegularExpressions;

namespace LinkConverter.API.Core.Pages
{
    public class HomePage : IPage
    {
        public int Priority => 0;

        public string BuildDeeplink(string webUrl)
        {
            return Constants.TRENDYOL_HOMEPAGE_DEEPLINK;
        }

        public string BuildWebUrl(string deeplink)
        {
            return Constants.TRENDYOL_HOMEPAGE_WEBURL;
        }

        public bool IsMatchWithDeeplinkPattern(string link)
        {
            return true;
        }

        public bool IsMatchWithWebUrlPattern(string link)
        {
            return true;
        }
    }
}