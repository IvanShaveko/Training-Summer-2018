using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web.Second.Models
{
    public class ImageContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
    }

    public class ImageDbInitializer : DropCreateDatabaseAlways<ImageContext>
    {
        protected override void Seed(ImageContext db)
        { 
            db.Images.Add(new Image { ImagePath = "/Content/img/1.jpg", ThumbPath = "/Content/img/1.jpg" });
            db.Images.Add(new Image { ImagePath = "/Content/img/2.jpg", ThumbPath = "/Content/img/2.jpg" });
            db.Images.Add(new Image { ImagePath = "/Content/img/3.jpg", ThumbPath = "/Content/img/3.jpg" });
            db.Images.Add(new Image { ImagePath = "/Content/img/4.jpg", ThumbPath = "/Content/img/4.jpg" });
            db.Images.Add(new Image { ImagePath = "/Content/img/5.jpg", ThumbPath = "/Content/img/5.jpg" });
            db.Images.Add(new Image { ImagePath = "/Content/img/6.jpg", ThumbPath = "/Content/img/6.jpg" });
            db.Images.Add(new Image { ImagePath = "/Content/img/6.jpg", ThumbPath = "/Content/img/6.jpg" });
            db.Images.Add(new Image { ImagePath = "/Content/img/5.jpg", ThumbPath = "/Content/img/5.jpg" });
            db.Images.Add(new Image { ImagePath = "/Content/img/4.jpg", ThumbPath = "/Content/img/4.jpg" });
            db.Images.Add(new Image { ImagePath = "/Content/img/3.jpg", ThumbPath = "/Content/img/3.jpg" });
            db.Images.Add(new Image { ImagePath = "/Content/img/2.jpg", ThumbPath = "/Content/img/2.jpg" });
            db.Images.Add(new Image { ImagePath = "/Content/img/1.jpg", ThumbPath = "/Content/img/1.jpg" });

            base.Seed(db);
        }
    }
}