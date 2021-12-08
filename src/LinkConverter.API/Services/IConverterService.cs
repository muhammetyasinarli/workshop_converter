using LinkConverter.API.Model;
using System.Collections.Generic;

namespace LinkConverter.API.Services
{
    public interface IConverterService
    {
        public IEnumerable<LinkConversion> GetLinkConversion();
        public ConversionResponse ConvertWebUrlToDeeplink(string webUrl);
        public ConversionResponse ConvertDeeplinkToWebUrl(string deeplink);
    }
}
