using HackerNews_Angular_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews_Angular_Project.Services
{
    public interface IArticleService
    {
        Task<List<NewsArticle>> GetNewsArticles();
    }
}
