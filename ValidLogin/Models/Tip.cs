using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ValidLogin.Models
{
    public class Tip
    {
        public Tip() { }

        public int Id { get; set; }

     
        public int UserId { get; set; }
        
        public string Name { get; set; }
        public virtual User user { get; set; }
    }
}