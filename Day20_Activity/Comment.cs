using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentWebApplication.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string PostCategory { get; set; }
        public string PostText { get; set; }
        public string CommentToPost { get; set; }

    }
}
