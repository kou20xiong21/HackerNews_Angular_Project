using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews_Angular_Project.Services
{
    public static class MockingArticleService
    {
        public static IMemoryCache GetMemoryCache(object expectedValue)
        {
            var mockMemoryCache = new Mock<IMemoryCache>();

            mockMemoryCache.Setup(x => x.TryGetValue(It.IsAny<object>(), out expectedValue)).Returns(true);

            return mockMemoryCache.Object;
        }
    }
}
