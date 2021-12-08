using LinkConverter.API.Core;
using LinkConverter.API.Model;
using LinkConverter.API.Repositories;
using LinkConverter.API.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using Microsoft.EntityFrameworkCore;

namespace LinkConverter.UnitTests
{
    public abstract class TestBase
    {
        public virtual IServiceProvider Initialize(Action<IServiceCollection> action = null)
        {
            var services = new ServiceCollection();

            var mockConverterRepository = new Mock<IConverterRepository>();
            mockConverterRepository.Setup(r => r.Create(It.IsAny<LinkConversion>()));

            services.AddSingleton(mockConverterRepository.Object);
            services.AddSingleton<IConverterService, ConverterService>();
            services.AddSingleton<ILinkBuilder, LinkBuilder>();
            services.AddSingleton<IPageFactory, PageFactory>();
            services.AddDbContext<DefaultDbContext>(options => options.UseInMemoryDatabase(databaseName: $"Test_{Guid.NewGuid()}"));

            return services.BuildServiceProvider();
        }
    }
}
