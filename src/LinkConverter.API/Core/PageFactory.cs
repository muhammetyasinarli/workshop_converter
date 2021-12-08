using LinkConverter.API.Core.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkConverter.API.Core
{
    public class PageFactory : IPageFactory
    {
        private readonly List<IPage> pageList;
        public PageFactory()
        {
            pageList = new List<IPage>(){
                new ProductDetailPage(),
                new SearchPage(),
                new HomePage()
            };
        }

        public IPage CreatePage(ConversionDirection direction, string link)
        {
            return pageList.FindAll(r => (direction == ConversionDirection.DeeplinkToWebUrl && r.IsMatchWithDeeplinkPattern(link))
                               || (direction == ConversionDirection.WebUrlToDeeplink && r.IsMatchWithWebUrlPattern(link)))
                ?.OrderByDescending(r => r.Priority).FirstOrDefault();
        }
    }
}
