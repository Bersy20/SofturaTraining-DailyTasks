using BooksWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebApplication.Controllers
{
    public class BookController : Controller
    {
        private ILogger<BookController> _logger;
        private IRepo<Book> _repo;

        public BookController(IRepo<Book> repo, ILogger<BookController> logger)
        {
            _logger = logger;
            _repo = repo;
        }
        public IActionResult Index()
        {
            List<Book> books = _repo.GetAll().ToList();
            return View(books);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            _repo.Add(book);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Book book = _repo.Get(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(int id, Book book)
        {
            _repo.Update(id, book);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Book book = _repo.Get(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Delete(Book book)
        {
            _repo.Delete(book);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            Book book = _repo.Get(id);
            return View(book);
        }
        public IActionResult Details(Book book)
        {
            return RedirectToAction("Index");
        }
    }
}
