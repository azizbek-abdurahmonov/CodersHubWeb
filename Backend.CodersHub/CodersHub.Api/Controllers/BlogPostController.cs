using Backend.CodersHub.Files;
using Backend.CodersHub.Models;
using Backend.CodersHub.Services.BlogPostServices.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CodersHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostController : Controller
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostController()
        {
            _blogPostService = new BlogPostService();
        }

        [HttpPost("Add")]
        public Guid Add(Guid token, BlogPostDto post)
        {
            return _blogPostService.Add(token, post);
        }

        [HttpDelete("Delete")]
        public void Delete(Guid id)
        {
            _blogPostService.Delete(id);
        }

        [HttpGet("GetById")]
        public BlogPost Get(Guid id)
        {
            return _blogPostService.Get(id);
        }

        [HttpGet("GetUserPosts")]
        public List<BlogPost> GetUserPosts(Guid token)
        {
            var userPosts = _blogPostService.GetUserPosts(token);
            return userPosts;
        }

        [HttpPost("Update")]
        public void Update(Guid id, BlogPostDto post)
        {
            _blogPostService.Update(id, post);
        }

        [HttpGet("GetAllPosts")]
        public List<BlogPost> GetPosts()
        {
            return _blogPostService.GetPosts();
        }

        [HttpGet("Search")]
        public List<BlogPost> Search(string keyword)
        {
            return _blogPostService.Search(keyword);
        }
    }
}
