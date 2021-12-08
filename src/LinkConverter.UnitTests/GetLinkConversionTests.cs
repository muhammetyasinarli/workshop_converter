using LinkConverter.API.Services;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Moq;
using LinkConverter.API.Repositories;
using LinkConverter.API.Model;
using System;
using LinkConverter.API.Core;
using System.Collections.Generic;

namespace LinkConverter.UnitTests
{
    public class GetLinkConversionTests : TestBase
    {
        [Fact]
        public void GetLinkConversion_ShouldNotBeNull()
        {
            var serviceProvider = base.Initialize();
            IConverterService converter = serviceProvider.GetService<IConverterService>();

            var results = converter.GetLinkConversion();
            
            Assert.NotNull(results);
        }
    }
}
