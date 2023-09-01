using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Backend.CodersHub.Files;
using Backend.CodersHub.Models;
using Backend.CodersHub.Services.UserServices.Concrete;

namespace Backend.CodersHub.Services.BlogPostServices.Concrete
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IFileContext _fileContext;
        private readonly IUserService _userService;
        public BlogPostService()
        {
            _fileContext = new FileContext();
            _userService = new UserService();
        }

        public Guid Add(Guid token, BlogPostDto blogPostDto)
        {
            var blogPost = new BlogPost(_userService.Get(token).Id, blogPostDto.Title, blogPostDto.Body);
            _fileContext.AddPost(blogPost);
            return blogPost.Id;
        }

        public void Delete(Guid id)
        {
            _fileContext.DeletePost(id);
        }

        public BlogPost Get(Guid id)
        {
            return _fileContext.GetPost(id);
        }

        public List<BlogPost> GetUserPosts(Guid token)
        {
            return _fileContext.GetUserPosts(token);
        }

        public void Update(Guid id, BlogPostDto blogPostDto)
        {
            _fileContext.UpdatePost(id, blogPostDto);
        }

        public List<BlogPost> GetPosts()
        {
            return _fileContext.GetPosts();
        }

        public List<BlogPost> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) throw new Exception("Search keyword is null or whitespace");
            return _fileContext.SearchPost(keyword);
        }
    }
}
