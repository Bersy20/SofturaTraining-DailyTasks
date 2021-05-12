using CommentWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentWebApplication.Controllers
{
    public class CommentController : Controller
    {
        static List<Comment> comments = new List<Comment>()
        {
            new Comment(){Id=101,PostCategory="Fun",PostText="Check status of movies on may 14th",CommentToPost="Super Movies"},
            new Comment(){Id=102,PostCategory="Health",PostText="Health is wealth",CommentToPost="Absolutely"},
            new Comment(){Id=103,PostCategory="Food",PostText="Food is essential for Life",CommentToPost="Yummyy!!"},
        };
        public IActionResult Index()
        {
            return View(comments);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            comments.Add(comment);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            int idx = comments.FindIndex(c => c.Id == id);
            return View(comments[idx]);
        }
        [HttpPost]
        public IActionResult Edit(int id, Comment comment)
        {
            int idx = comments.FindIndex(c => c.Id == id);
            comments[idx].CommentToPost = comment.CommentToPost;
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            int idx = comments.FindIndex(c => c.Id == id);
            return View(comments[idx]);
        }
        [HttpPost]
        public IActionResult Delete(int id, Comment comment)
        {
            int idx = comments.FindIndex(c => c.Id == id);            
            comments.RemoveAt(idx);
            return RedirectToAction("Index");
        }
    }
}
