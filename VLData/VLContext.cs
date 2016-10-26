using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ValidLogin.Models;

namespace VLData
{
    public class VLContext : DbContext
    {
        public VLContext(): base()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tip> Tips { get; set; }
    }
}