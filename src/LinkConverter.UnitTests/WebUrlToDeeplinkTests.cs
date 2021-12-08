using LinkConverter.API.Model.Exceptions;
using LinkConverter.API.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LinkConverter.UnitTests
{
    public class WebUrlToDeeplinkTests : TestBase
    {
        [Theory]
        [InlineData("https://www.trendyol.com/casio/saat-p-1925865?boutiqueId=439892&merchantId=105064", "ty://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=105064")]
        [InlineData("https://www.trendyol.com/casio/erkekkol-saati-p-1925865", "ty://?Page=Product&ContentId=1925865")]
        [InlineData("https://www.trendyol.com/casio/erkekkol-saati-p-1925865?boutiqueId=439892", "ty://?Page=Product&ContentId=1925865&CampaignId=439892")]
        [InlineData("https://www.trendyol.com/casio/erkekkol-saati-p-1925865?merchantId=105064", "ty://?Page=Product&ContentId=1925865&MerchantId=105064")]
        [InlineData("https://www.trendyol.com/sr?q=elbise", "ty://?Page=Search&Query=elbise")]
        [InlineData("https://www.trendyol.com/sr?q=%C3%BCt%C3%BC", "ty://?Page=Search&Query=%C3%BCt%C3%BC")]
        [InlineData("https://www.trendyol.com/Hesabim/Favoriler", "ty://?Page=Home")]
        [InlineData("https://www.trendyol.com/Hesabim/#/Siparislerim", "ty://?Page=Home")]
        public void ConvertWebUrlToDeeplink_ShouldReturnExpectedDeeplink_WhenLinkIsNotEmptyOrNull(string webUrl, string deeplink)
        {
            var serviceProvider = base.Initialize();

            var conversionResult = serviceProvider.GetService<IConverterService>().ConvertWebUrlToDeeplink(webUrl);
            bool isValid = conversionResult != null && deeplink == conversionResult.Link;

            Assert.True(isValid, $"The converted deeplink {conversionResult} is not equal to expected deeplink {deeplink}");
        }

        [Fact]
        public void ConvertWebUrlToDeeplink_ShouldReturnRequiredFieldException_WhenLinkIsEmpty()
        {
            var serviceProvider = base.Initialize();
            IConverterService converter = serviceProvider.GetService<IConverterService>();
            string webUrl = string.Empty;

            Assert.Throws<RequiredFieldException>(() => { converter.ConvertDeeplinkToWebUrl(webUrl); });
        }

        [Fact]
        public void ConvertWebUrlToDeeplink_ShouldReturnRequiredFieldException_WhenLinkIsNull()
        {
            var serviceProvider = base.Initialize();
            IConverterService converter = serviceProvider.GetService<IConverterService>();
            string webUrl = null;

            Assert.Throws<RequiredFieldException>(() => { converter.ConvertDeeplinkToWebUrl(webUrl); });
        }
    }
}
