using LinkConverter.API.Model.Exceptions;
using LinkConverter.API.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LinkConverter.UnitTests
{
    public class DeeplinkToWebUrlTests : TestBase
    {
        [Theory]
        [InlineData("ty://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=105064", "https://www.trendyol.com/brand/name-p-1925865?boutiqueId=439892&merchantId=105064")]
        [InlineData("ty://?Page=Product&ContentId=1925865", "https://www.trendyol.com/brand/name-p-1925865")]
        [InlineData("ty://?Page=Product&ContentId=1925865&CampaignId=439892", "https://www.trendyol.com/brand/name-p-1925865?boutiqueId=439892")]
        [InlineData("ty://?Page=Product&ContentId=1925865&MerchantId=105064", "https://www.trendyol.com/brand/name-p-1925865?merchantId=105064")]
        [InlineData("ty://?Page=Search&Query=elbise", "https://www.trendyol.com/sr?q=elbise")]
        [InlineData("ty://?Page=Search&Query=%C3%BCt%C3%BC", "https://www.trendyol.com/sr?q=%C3%BCt%C3%BC")]
        [InlineData("ty://?Page=Favorites", "https://www.trendyol.com")]
        [InlineData("ty://?Page=Orders", "https://www.trendyol.com")]
        public void ConvertDeeplinkToWebUrl_ShouldReturnExpectedWebUrl_WhenLinkIsNotEmptyOrNull(string deeplink, string webUrl)
        {
            var serviceProvider = base.Initialize();

            var conversionResult = serviceProvider.GetService<IConverterService>().ConvertDeeplinkToWebUrl(deeplink);
            bool isValid = conversionResult != null && webUrl == conversionResult.Link;

            Assert.True(isValid, $"The converted weburl {conversionResult} is not equal to expected weburl {webUrl}");
        }

        [Fact]
        public void ConvertDeeplinkToWebUrl_ShouldReturnRequiredFieldException_WhenLinkIsEmpty()
        {
            var serviceProvider = base.Initialize();
            IConverterService converter = serviceProvider.GetService<IConverterService>();
            string deeplink = string.Empty;

            Assert.Throws<RequiredFieldException>(() => { converter.ConvertDeeplinkToWebUrl(deeplink); });
        }

        [Fact]
        public void ConvertDeeplinkToWebUrl_ShouldReturnRequiredFieldException_WhenLinkIsNull()
        {
            var serviceProvider = base.Initialize();
            IConverterService converter = serviceProvider.GetService<IConverterService>();
            string deeplink = null;

            Assert.Throws<RequiredFieldException>(() => { converter.ConvertDeeplinkToWebUrl(deeplink); });
        }
    }
}
