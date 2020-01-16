using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogMongoDB;
using BlogMongoDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsercizioMongoDB1_02.Controllers
{
    public class BlogController : Controller
    {
        private IDbService _db;
        public BlogController(IDbService db)
        {
            _db = db;
        }

        // GET: Blog
        public async Task<ActionResult> Index()
        {
            var postlist = await _db.GetPosts();
            ViewBag.Message = "Benvenuto nel Blog più bello del mondo!";
            ViewBag.CurrentDate = DateTime.Now.ToString();
            ViewBag.ShowDate = true;
            return View(postlist);
        }

        // GET: Blog/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var post = await _db.GetPosts(id);
            return View(post);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Blog post)
        {
            try
            {
                post.CreationDate = DateTime.Now;
                post.EditDate = post.CreationDate;
                await _db.AddPost(post);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var post = await _db.GetPosts(id);
            return View(post);
        }

        // POST: Blog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Blog post)
        {
            try
            {
                post.EditDate = DateTime.Now;
                await _db.EditPost(post);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        public async Task<ActionResult> DeleteView(string id)
        {
            var post = await _db.GetPosts(id);
            return View(post);
        }

        // POST: Blog/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var post = await _db.GetPosts(id);
                await _db.DeletePost(post);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}