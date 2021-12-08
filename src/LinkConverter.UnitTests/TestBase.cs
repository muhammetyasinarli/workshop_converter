using LinkConverter.API.Core;
using LinkConverter.API.Model;
using LinkConverter.API.Repositories;
using LinkConverter.API.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;

namespace LinkConverter.UnitTests
{
    public abstract class TestBase
    {
        public virtual IServiceProvider Initialize(Action<IServiceCollection> action = null)
        {
            var services = new ServiceCollection();

            var mockConverterRepository = new Mock<IConverterRepository>();
            mockConverterRepository.Setup(r => r.GetLinkConversion()).Returns(new List<LinkConversion>() { 
                new LinkConversion("ty://?Page=Product&ContentId=1925865&CampaignId=439892", 
                                   "https://www.trendyol.com/brand/name-p-1925865?boutiqueId=439892", 
                                   ConversionDirection.DeeplinkToWebUrl) });
            mockConverterRepository.Setup(r => r.Create(It.IsAny<LinkConversion>()));
            services.AddSingleton(mockConverterRepository.Object);

            services.AddSingleton<IConverterService, ConverterService>();
            services.AddSingleton<ILinkBuilder, LinkBuilder>();
            services.AddSingleton<IPageFactory, PageFactory>();

            return services.BuildServiceProvider();
        }
    }
}
