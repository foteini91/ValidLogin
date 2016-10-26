using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ValidLogin.Models
{
    public class User

    {
        public User()
        {
            tipsList = new HashSet<Tip>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public virtual ICollection<Tip> tipsList { get; set; }



        //public static IList<Tip> tipsList = new List<Tip>()
        //{
        //    new Tip() { Name="Drink water!" },
        //    new Tip() { Name="Go for a walk!" },
        //};

        //public User(string un, string pw, List<Tips> TIPS)
        //{
        //    username = un;
        //    password = pw;
        //    tipsList = new List<Tips>();
        //{              
        //new Tips() { tip="Drink water!" },
        //new Tips() { tip="Go for a walk!" }
        //};

    }
}        




   

