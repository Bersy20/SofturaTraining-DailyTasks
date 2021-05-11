using System;
using System.Collections.Generic;
using System.Text;

namespace EFandLINQProject.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string CommentText { get; set; }
    }
}
