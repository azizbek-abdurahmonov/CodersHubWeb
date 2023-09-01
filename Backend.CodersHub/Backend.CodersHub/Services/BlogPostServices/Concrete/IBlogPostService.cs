using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.CodersHub.Models;

namespace Backend.CodersHub.Services.BlogPostServices.Concrete
{
    public interface IBlogPostService
    {
        Guid Add(Guid token, BlogPostDto blogPostDto);
        BlogPost Get(Guid id);
        void Update(Guid id, BlogPostDto blogPostDto);
        void Delete(Guid id);
        List<BlogPost> GetPosts();
        List<BlogPost> GetUserPosts(Guid token);
        List<BlogPost> Search(string keyword);

    }
}

