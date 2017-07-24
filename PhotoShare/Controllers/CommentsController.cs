using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhotoShare.Models;

namespace PhotoShare.Controllers
{
    public class CommentsController : Controller
    {
        private Entities context = new Entities();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.PhotoID = comment.PhotoID;
                comment.UserName = "pagulayanralph";//for the mean time
                comment.Content = comment.Content;
                context.Comments.Add(comment);
                context.SaveChanges();
                return RedirectToAction("Display", "Photo", new { id = comment.PhotoID });
            }

            return View(comment);
        }
    }
}
