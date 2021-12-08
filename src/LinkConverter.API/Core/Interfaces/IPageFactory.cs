using LinkConverter.API.Core.Pages;

namespace LinkConverter.API.Core
{
    public interface IPageFactory
    {
        public IPage CreatePage(ConversionDirection direction, string link);
    }
}