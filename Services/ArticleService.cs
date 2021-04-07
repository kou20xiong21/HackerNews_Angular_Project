using HackerNews_Angular_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace HackerNews_Angular_Project.Services
{
    public class ArticleService : IArticleService
    {
        private const string baseUrl = "https://hacker-news.firebaseio.com/v0/";
        private readonly IMemoryCache _MemoryCache;
        private static HttpClient _Client = new HttpClient();

        public ArticleService(IMemoryCache memoryCache)
        {
            _MemoryCache = memoryCache;
        }

        public async Task<List<NewsArticle>> GetNewsArticles()
        {
            List<NewsArticle> newsArticlesList = new List<NewsArticle>();

            try
            {
                var reponseNewStories = await _Client.GetAsync(baseUrl + "newstories.json?print=pretty");

                if (reponseNewStories.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = reponseNewStories.Content.ReadAsStringAsync().Result;

                    newsArticlesList = await ConvertResponseToJSON(newsArticlesList, responseContent);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return newsArticlesList;

        }

        private async Task<List<NewsArticle>> ConvertResponseToJSON(List<NewsArticle> newsArticlesList, string responseContent)
        {
            try
            {
                var newsArticlesJSONConverted = JsonConvert.DeserializeObject<List<int>>(responseContent);

                var newsArticles = newsArticlesJSONConverted.Select(GetNewsArticlesByID);

                newsArticlesList = (await Task.WhenAll(newsArticles)).ToList();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return newsArticlesList;
        }

        private async Task<NewsArticle> GetNewsArticlesByID(int id)
        {
            return await _MemoryCache.GetOrCreateAsync(id, async cacheArticles =>
            {
                NewsArticle newsArticlesByID = new NewsArticle();

                if (cacheArticles is null)
                {
                    throw new ArgumentNullException(nameof(cacheArticles));
                }

                try
                {
                    var responseNewsArticlesByID = await _Client.GetAsync(string.Format(baseUrl + "item/{0}.json?print=pretty", id));

                    if (responseNewsArticlesByID.StatusCode == HttpStatusCode.OK)
                    {
                        var responseContent = responseNewsArticlesByID.Content.ReadAsStringAsync().Result;

                        newsArticlesByID = JsonConvert.DeserializeObject<NewsArticle>(responseContent);
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }

                return newsArticlesByID;
            });

        }
    }
}
