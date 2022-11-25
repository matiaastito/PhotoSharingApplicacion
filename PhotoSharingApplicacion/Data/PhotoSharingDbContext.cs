using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PhotoSharingApplicacion.Models;

namespace PhotoSharingApplicacion.Data
{
    public class PhotoSharingDbContext :DbContext
    {
        public PhotoSharingDbContext() : base("KeyPhotoSharingDB") { }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}