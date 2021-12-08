using LinkConverter.API.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace LinkConverter.API.Core.Pages
{
    public class ProductDetailPage: IPage
    {
        private readonly Regex webUrlRegex;
        private readonly Regex deeplinkRegex;
        private readonly Regex contentIdRegex;
        public int Priority => 1;

        public ProductDetailPage()
        {
            webUrlRegex = new Regex(@"\b(https://www.trendyol.com)\S+(-p-)([0-9a-zA-Z]+)\b", RegexOptions.Compiled);
            deeplinkRegex = new Regex(@"\b(ty://\?Page=Product&ContentId=)([0-9a-zA-Z]+)\b", RegexOptions.Compiled);
            contentIdRegex = new Regex("(.*)-p-(\\d+)");
        }

        public string BuildDeeplink(string webUrl)
        {
            var linkBuilder = new LinkBuilder(webUrl);

            List<string> parameters = new List<string>();
            parameters.Add($"{Constants.PAGE_PARAM}={Constants.PRODUCT_PARAM}");
            
            var contentId = ExtractContentId(webUrl);
            parameters.Add($"{Constants.CONTENT_ID_PARAM}={contentId}");

            string boutiqueId = linkBuilder.GetParameterWithName(Constants.BOUTIQUE_ID_PARAM);
            if (!String.IsNullOrWhiteSpace(boutiqueId))
            {
                parameters.Add($"{Constants.CAMPAIGN_ID_PARAM}={boutiqueId}");
            }
            string merchantId = linkBuilder.GetParameterWithName(Constants.MERCHANT_ID_PARAM_LOWER);
            if (!String.IsNullOrWhiteSpace(merchantId))
            {
                parameters.Add($"{Constants.MERCHANT_ID_PARAM_UPPER}={merchantId}");
            }

            return linkBuilder.CreateDeeplink(Constants.DEEPLINK_SCHEME, String.Join("&", parameters.ToArray()));
        }

        private string ExtractContentId(string webUrl)
        {
            const int capturedGroupIndex = 2;
            return contentIdRegex.Match(webUrl)?.Groups[capturedGroupIndex].Value;
        }

        public string BuildWebUrl(string deeplink)
        {
            var linkBuilder = new LinkBuilder(deeplink);

            string path = String.Empty;
            var contentId = linkBuilder.GetParameterWithName(Constants.CONTENT_ID_PARAM);
            if (!String.IsNullOrWhiteSpace(contentId))
            {
                path = $"{Constants.WEB_URL_PRODUCT_DETAIL_PATH}{contentId}";
            }

            List<string> parameters = new List<string>();
            var campaignId = linkBuilder.GetParameterWithName(Constants.CAMPAIGN_ID_PARAM);
            if (!String.IsNullOrWhiteSpace(campaignId))
            {
                parameters.Add($"{Constants.BOUTIQUE_ID_PARAM}={campaignId}");
            }

            var merchantId = linkBuilder.GetParameterWithName(Constants.MERCHANT_ID_PARAM_UPPER);
            if (!String.IsNullOrWhiteSpace(merchantId))
            {
                parameters.Add($"{Constants.MERCHANT_ID_PARAM_LOWER}={merchantId}");
            }

            return linkBuilder.CreateLink(new UriBuilderRequest(Constants.WEB_URL_SCHEME, Constants.WEB_URL_HOST, path, String.Join("&", parameters.ToArray())));
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
