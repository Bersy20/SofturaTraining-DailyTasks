using System;
using System.Collections.Generic;
using System.Text;

namespace EFandLINQProject.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string PostText { get; set; }
        public string Category { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
