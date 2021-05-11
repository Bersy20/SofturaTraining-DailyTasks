using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFandLINQProject.Model
{
    class PostRepo : IRepo<Post>
    {
        private TweetContext _context;
        public PostRepo()
        {

        }
        public PostRepo(TweetContext dbContext)
        {
            _context = dbContext;
        }
        public bool Add(Post t)
        {
            try
            {
                _context.Posts.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public Post Get(int id)
        {
            try
            {
                Post post = _context.Posts.FirstOrDefault(cmt => cmt.Id == id);
                return post;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return null;
        }

        public IList<Post> GetAll()
        {
            if (_context.Posts.Count() > 0)
                return _context.Posts.ToList();
            return null;
        }
    }
}
