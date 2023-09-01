using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CodersHub.Models
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }

        public BlogPost(Guid userId, string title, string body)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Title = title;
            Body = body;
            CreatedDate = DateTime.Now;
        }
    }
}
