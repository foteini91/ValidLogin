using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidLogin.Models;

namespace TestDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Context())
            {
                List<Tip> ltp = new List<Tip>();
                var tp = new Tip { Name = "drink water" };
                ltp.Add(tp);
                var usr = new User { username = "Foteini", password = "1", tipsList = ltp };
                db.Users.Add(usr);

                int i = db.SaveChanges();
                Console.WriteLine("{0} records added...", i);
                Console.ReadLine();
            }
        }
    }
}
