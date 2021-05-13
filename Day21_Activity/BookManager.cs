using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BooksWebApplication.Models.BookContext;

namespace BooksWebApplication.Models
{
  
    public class BookManager : IRepo<Book>
    {
        private PublicationContext _context;
        private ILogger<BookManager> _logger;

        public BookManager(PublicationContext context, ILogger<BookManager> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(Book t)
        {
            try
            {
                _context.Books.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public void Delete(Book t)
        {
            try
            {
                _context.Remove(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public Book Get(int id)
        {
            try
            {
                Book book = _context.Books.FirstOrDefault(a => a.Id == id);
                return book;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Book> GetAll()
        {
            try
            {
                if (_context.Books.Count() == 0)
                    return null;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return _context.Books;
        }

        public void Update(int id, Book t)
        {
            Book book = Get(id);
            if (book != null)
            {
                book.Title = t.Title;
                book.Price = t.Price;
                book.Author_Id = t.Author_Id;
            }
            _context.SaveChanges();
        }
    }
}
