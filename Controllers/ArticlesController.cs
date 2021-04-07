using HackerNews_Angular_Project.Models;
using HackerNews_Angular_Project.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HackerNews_Angular_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _ArticleService;

        public ArticlesController(IArticleService articleService)
        {
            _ArticleService = articleService;
        }

        // GET: api/<ArticlesController>
        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            List<NewsArticle> newsArticleList = new List<NewsArticle>();

            try
            {
                newsArticleList = await _ArticleService.GetNewsArticles();

                if (newsArticleList.Count() == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return Ok(newsArticleList);
        }

        // GET api/<ArticlesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ArticlesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ArticlesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticlesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
