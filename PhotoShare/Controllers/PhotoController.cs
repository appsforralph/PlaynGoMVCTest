using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using PhotoShare.Models;

namespace PhotoShare.Controllers
{
    public class PhotoController : Controller
    {
        private Entities context = new Entities();

        public ActionResult Index()
        {
            ViewBag.Photos = context.Photos.OrderByDescending(item => item.CreatedDate).ToList();
            return View();
        }

        public ActionResult Display (int id)
        {
            Photo photo = context.Photos.Find(id);
            Comment comment = new Comment();
            if (photo == null)
            {
                return HttpNotFound();
            }

            ViewBag.Comments = context.Comments.Where(item=>item.PhotoID == id).ToList();
            ViewBag.Photo = photo;
            ViewBag.Comment = comment;
            return View();
        }


        [HttpPost]
        public ActionResult Create (Photo photo, HttpPostedFileBase image)
        {
            photo.CreatedDate = DateTime.Today;
            photo.Username = "pagulayanralph";//for the mean time
            if (!ModelState.IsValid)
            {
                return View("Index", photo);
            }
            else
            {
                if (image != null)
                {
                    photo.ImageMimeType = image.ContentType;

                    photo.PhotoFile = new byte[image.ContentLength];
                    image.InputStream.Read(photo.PhotoFile, 0, image.ContentLength);
                }
            }
            context.Photos.Add(photo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Photo photo = context.Photos.Find(id);
            context.Photos.Remove(photo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = context.Photos.Find(id);
            context.Photos.Remove(photo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public FileContentResult GetImage (int id)
        {
            Photo photo = context.Photos.Find(id);
            if (photo != null)
            {
                return File(photo.PhotoFile,
                   photo.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public ActionResult Chat()
        {
            return View();
        }
    }
}