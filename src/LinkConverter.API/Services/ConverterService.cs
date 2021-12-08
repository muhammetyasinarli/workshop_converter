using LinkConverter.API.Core;
using LinkConverter.API.Core.Pages;
using LinkConverter.API.Model;
using LinkConverter.API.Model.Exceptions;
using LinkConverter.API.Repositories;
using System;
using System.Collections.Generic;

namespace LinkConverter.API.Services
{
    public class ConverterService : IConverterService
    {
        private readonly IConverterRepository conversionRepository;
        private readonly IPageFactory pageFactory;

        public ConverterService(IConverterRepository conversionRepository, IPageFactory pageFactory)
        {
            this.conversionRepository = conversionRepository;
            this.pageFactory = pageFactory;
        }

        public ConversionResponse ConvertWebUrlToDeeplink(string link)
        {
            Validate(link);

            IPage page = pageFactory.CreatePage(ConversionDirection.WebUrlToDeeplink, link);

            string deeplink = page.BuildDeeplink(link);

            SaveConversion(link, deeplink, ConversionDirection.WebUrlToDeeplink);

            return new ConversionResponse(deeplink);
        }

        public ConversionResponse ConvertDeeplinkToWebUrl(string link)
        {
            Validate(link);

            IPage page = pageFactory.CreatePage(ConversionDirection.DeeplinkToWebUrl, link);

            string webUrl = page.BuildWebUrl(link);

            SaveConversion(link, webUrl, ConversionDirection.DeeplinkToWebUrl);

            return new ConversionResponse(webUrl);
        }

        public IEnumerable<LinkConversion> GetLinkConversion()
        {
            return conversionRepository.GetLinkConversion();
        }

        private static void Validate(string link)
        {
            if (String.IsNullOrWhiteSpace(link))
            {
                throw new RequiredFieldException(nameof(link));
            }
        }

        private void SaveConversion(string sourceLink, string targetLink, ConversionDirection direction)
        {
            var result = conversionRepository.Create(new LinkConversion(sourceLink, targetLink, direction));
            if(result < 0)
            {
                throw new DatabaseException("Link conversion result could not be saved to database");
            }
        }
    }
}
