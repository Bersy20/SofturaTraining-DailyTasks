using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFandLINQProject.Model
{
    class CommentRepo : IRepo<Comment>
    {
        private TweetContext _context;
        public CommentRepo()
        {

        }
        public CommentRepo(TweetContext dbContext)
        {
            _context = dbContext;
        }
        public bool Add(Comment t)
        {
            try
            {
                _context.Comments.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);           
            }
            return false;
        }

        public Comment Get(int id)
        {
            try
            {
                Comment comment = _context.Comments.FirstOrDefault(cmt => cmt.Id == id);
                return comment;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return null;
        }

        public IList<Comment> GetAll()
        {
            if (_context.Comments.Count() > 0)
                return _context.Comments.ToList();
            return null;
        }
    }
}
