using HackerNews_Angular_Project.Models;
using HackerNews_Angular_Project.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews_Angular_Project.Tests
{
    [TestFixture]
    public class TestArticleService
    {
        [Test]
        public async Task GetNewsArticles_ShouldReturnCountGreaterThan20()
        {
            object expectedResult = null;

            var mockMemoryCache = MockingArticleService.GetMemoryCache(expectedResult);
            var articleServiceCache = new ArticleService(mockMemoryCache);

            List<NewsArticle> newsArticles = await articleServiceCache.GetNewsArticles();

            Assert.AreNotEqual(20, newsArticles.Count());
        }
    }
}
