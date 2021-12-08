using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkConverter.API
{
    public static class Constants
    {
        public const string TRENDYOL_HOMEPAGE_WEBURL = "https://www.trendyol.com";
        public const string TRENDYOL_HOMEPAGE_DEEPLINK = "ty://?Page=Home";
        public const string Q_PARAM = "q";
        public const string PAGE_PARAM = "Page";
        public const string SEARCH_PARAM = "Search";
        public const string QUERY_PARAM = "Query";
        public const string PRODUCT_PARAM = "Product";
        public const string CONTENT_ID_PARAM = "ContentId";
        public const string BOUTIQUE_ID_PARAM = "boutiqueId";
        public const string MERCHANT_ID_PARAM_LOWER = "merchantId";
        public const string CAMPAIGN_ID_PARAM = "CampaignId";
        public const string MERCHANT_ID_PARAM_UPPER = "MerchantId";
        public const string WEB_URL_SCHEME = "https";
        public const string WEB_URL_HOST = "www.trendyol.com";
        public const string DEEPLINK_SCHEME = "ty";
        public const string DEEPLINK_SEARCH_PATH = "sr";
        public const string WEB_URL_PRODUCT_DETAIL_PATH = "brand/name-p-";
    }
}
