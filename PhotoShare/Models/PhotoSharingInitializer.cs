using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace PhotoShare.Models
{
    public class PhotoSharingInitializer : DropCreateDatabaseAlways
   <PhotoSharingContext>
    {
        protected override void Seed(PhotoSharingContext context)
        {
            base.Seed(context);

            var photos = new List<Photo>
            {
            new Photo {
                Description = "The loner building at ayala triangle" ,
                Username = "pagulayanralph",
                PhotoFile = getFileBytes("\\Images\\DSC00678-2.jpg"),
                Location ="Zuellig Building, Paseo de Roxas, Makati, Metro Manila",
                ImageMimeType ="image/jpeg",
                CreatedDate = DateTime.Today.AddDays(-1)
                },
            new Photo {
                Description = "Everybody's rushing home",
                Username = "pagulayanralph",
                PhotoFile = getFileBytes("\\Images\\DSC00681.jpg"),
                Location ="Pio del Pilar Monument, 8735 Makati Ave, Makati, 1227 Metro Manila",
                ImageMimeType ="image/jpeg",
                CreatedDate = DateTime.Today.AddDays(-1)
                },
            new Photo {
                Description = "Makati Ave's Cityscape",
                Username = "pagulayanralph",
                PhotoFile = getFileBytes("\\Images\\DSC05132.jpg"),
                Location ="City Garden Grand Hotel Makati, 8008 Makati Ave. cor. Makati City, Kalayaan Avenue, Makati, Metro Manila",
                ImageMimeType ="image/jpeg",
                CreatedDate = DateTime.Today.AddDays(-1)
                }
            };


            photos.ForEach(s => context.Photos.Add(s));
            context.SaveChanges();

            var comments = new List<Comment>
            {
               new Comment {
                  PhotoID = 1,
                  UserName = "Kevin Oslob",
                  Content = "Nice shot bro! What are your settings?"
               }
            };

            comments.ForEach(s => context.Comments.Add(s));
            context.SaveChanges();

        }

        //This gets a byte array for a file at the path specified
        //The path is relative to the route of the web site
        //It is used to seed images
        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }
    }
}