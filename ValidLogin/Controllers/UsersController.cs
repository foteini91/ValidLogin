using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security;
using ValidLogin.Models;

namespace ValidLogin.Controllers
{
    public class UsersController : ApiController
    {
       
        // GET api/values /// Tipcontrolles kanei ayti ti leitoyrgia.. isos tha to sbiso ayto
        [ActionName("FindTipUsers")]
        public IEnumerable<string> Get(string usr)
        {
            //Context db = new Context();

            //var user = db.Users
            // // .Where(u => u.login.Equals(login))
            //  .Select(usr => 
            //      usr.username)
            //  .FirstOrDefault();

            //var users = from u in db.Users where u.username == usr select u;

            //var tipsName = users.First().tipsList.Select(c => c.Name);

            //return tipsName.ToList();

            HealthMeApp_Data db = new HealthMeApp_Data();
            var users = from u in db.User where u.Username == usr select u;
            var tipsName = users.First().Tip.Select(c => c.Name);
            return tipsName;


        }

            ////Get api/Tips
        //[ActionName("FindAllTips")]
        //public IEnumerable<string> GetAllTips()
        //{
        //    AllContext db = new AllContext();
        //    var tipName = from t in db.Tip select t.Name;
        //    return tipName;
        //}


        ////Post api/User
        [ActionName("LoginUser")]
        [Route("api/Users/LoginUser")]
        public bool Post(string userName, string passWord)
        {
            HealthMeApp_Data db = new HealthMeApp_Data();
            return db.User.Any(u => u.Username == userName && u.Password == passWord);
        }


        [ActionName("CheckRegisterUser")]
        [Route("api/Users/CheckRegisterUser")]
        public bool PostUsername(string userName)
        {
            HealthMeApp_Data db = new HealthMeApp_Data();
            return db.User.Any(u => u.Username == userName);
        }



        //Get api/User/id
        [ActionName("GetIdUser")]
        [Route("api/Users/GetIdUser")]
        public int? GetUserId(string userName,string passWord)
        {
            //AllContext db = new AllContext();
            //var id_user = (from item in db.User
            //               where (item.username == userName && item.password == passWord)
            //               select item.Id);
            //return id_user;

            HealthMeApp_Data db = new HealthMeApp_Data();
            var id_user = db.User.First(a => a.Username == userName && a.Password == passWord).Id;
            return id_user;
        }

        //post in register
        [ActionName("PostRegister")]
        [Route("api/Users/PostRegister")]
        public void PostRegister(string r_usr, string r_psw)
        {
            using (HealthMeApp_Data db = new HealthMeApp_Data())
            {
                //var id_Q = (from item in db.Answer
                //            where (item.Id == id_A)
                //            select item.QuestionId).First();

                User insert = new User();
                insert.Username = r_usr;
                insert.Password = r_psw;
                insert.Id += insert.Id ;
                db.User.Add(insert);
                db.SaveChanges();
            }
        }

        //post longitude-latitude
        [ActionName("PostLong_Lat")]
        [Route("api/Users/PostLong_Lat")]
        public void PostLongLat(int id_U, double lon, double lat)
        {
            using (HealthMeApp_Data db = new HealthMeApp_Data())
            {
                var item = (from u in db.User where u.Id == id_U select u).SingleOrDefault();
                item.Latitude = lat;
                item.Longitude = lon;
              
                db.SaveChanges();
            }

        }

      



        //Get api/values
        //[ActionName("FindAllUsers")]
        //public IQueryable<string> Get()
        //{
        //    Context db = new Context();

        //    //var user = db.Users
        //    // // .Where(u => u.login.Equals(login))
        //    //  .Select(usr => 
        //    //      usr.username)
        //    //  .FirstOrDefault();

        //    var user = from u in db.Users select u.username;
        //    return user;
        //}






        // [HttpPost]
        //GET api/values/5
        //public List<User> Get(string psw, string usr)
        //{
        //    InitializeMockData();
        //    return listUser.Find(li => li.password == psw && li.username == usr);
        //}





        //GET TIPS
        //[ActionName("FindTipByUser")]
        //public IEnumerable<Tip> Get(string usr)
        //{
        //    InitializeMockData();

        //    foreach (var user in listUser.Where(tl => tl.username == usr))
        //    {
        //        return user.tipsList;
        //    }

        //    return null;
        //}



        // POST api/values
        //[HttpPost]
        //public bool POST(User newuser)
        //{
        //    InitializeMockData();
        //    return listUser.Any(li => li.password == newuser.password && li.username == newuser.username);
        //}

        
    }
}
