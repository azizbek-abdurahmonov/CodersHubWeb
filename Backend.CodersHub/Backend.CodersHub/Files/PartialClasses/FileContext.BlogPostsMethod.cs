using Backend.CodersHub.Models;
using System.Text.Json;

namespace Backend.CodersHub.Files
{
    public partial class FileContext : IFileContext
    {
        public Guid AddPost(BlogPost blogPost)
        {
            var allText = File.ReadAllText(_postsPath);
            var posts = new List<BlogPost>();

            if (allText.Length == 0)
            {
                posts.Add(blogPost);
            }
            else
            {
                posts = JsonSerializer.Deserialize<List<BlogPost>>(allText);
                posts.Add(blogPost);
            }

            WriteAllText(_postsPath, JsonSerializer.Serialize(posts));
            return blogPost.Id;
        }

        public void DeletePost(Guid id)
        {
            var allText = File.ReadAllText(_postsPath);
            if (allText.Length == 0) throw new Exception("There are no posts");

            var posts = JsonSerializer.Deserialize<List<BlogPost>>(allText);
            var post = posts.FirstOrDefault(x => x.Id == id);
            if (post != null)
            {
                posts.Remove(post);
            }
            File.WriteAllText(_postsPath, JsonSerializer.Serialize(posts));
        }

        public void UpdatePost(Guid id, BlogPostDto blogPostDto)
        {
            var posts = GetPosts();
            var post = posts.FirstOrDefault(x => x.Id == id);

            if (post == null) throw new Exception("Blog post not found");

            post.Title = blogPostDto.Title;
            post.Body = blogPostDto.Body;

            WriteAllText(_postsPath, JsonSerializer.Serialize(posts));
        }

        public BlogPost GetPost(Guid id)
        {
            var allText = File.ReadAllText(_postsPath);
            if (allText.Length == 0) throw new Exception("There are no posts");

            var posts = JsonSerializer.Deserialize<List<BlogPost>>(allText);
            return posts.FirstOrDefault(x => x.Id == id);
        }

        public List<BlogPost> GetPosts()
        {
            var allText = File.ReadAllText(_postsPath);
            if (allText.Length == 0) return new List<BlogPost>();

            return JsonSerializer.Deserialize<List<BlogPost>>(allText);
        }

        public List<BlogPost> GetUserPosts(Guid token)
        {
            var posts = GetPosts();
            var user = GetUser(token);
            if (posts.Count == 0) return new List<BlogPost>();

            return posts.Where(post => post.UserId == user.Id).ToList();
        }

        public List<BlogPost> SearchPost(string keyword)
        {
            var posts = GetPosts();
            if (posts.Count == 0) return posts;

            return posts.Where(post =>
                post.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                post.Body.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
