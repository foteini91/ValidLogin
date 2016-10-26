using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Security;
using ValidLogin.Models;

namespace ValidLogin.Controllers
{
    public class UsersController : ApiController
    {
        //private static IList<User> listUser = new List<User>();
        //private static IList<Tip> listTips = new List<Tip>();

        //public static void InitializeMockData()
        //{
        //    listTips.Add(new Tip { Name = "drink water" });
        //    listTips.Add(new Tip { Name = "drink water again" });

        //    //1os tropos
        //    //var user1 = new User();
        //    //user1.username = "f";
        //    //user1.password = "1234";
        //    //user1.tipsList = listTips;
        //    // listUser.Add(user1);

        //    listUser.Add(new User { username = "f1", password = "7890", tipsList = listTips });
        //    listUser.Add(new User { username = "f2", password = "1234", tipsList = listTips });
        //    listUser.Add(new User { username = "f3", password = "4567", tipsList = listTips });

        //}



        // GET api/values
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

                //var co1 = (from item in db.User
                //            where (item.Id == id_U)
                //           select item.Id).First();
                //insert.Longitude
            }

        }

        //[ActionName("FindAllPropertiesOfTipsByUser")]
        //public IEnumerable<Tip> GetTipsByUser(string userName)
        //{
        //    Context db = new Context();
        //    var user = from u in db.Users where u.username == userName select u;
        //    var tipsProp = user.SelectMany().tipsList;
        //    return tipsProp;
        //}




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



        //[ActionName("CreateNewUser")]
        //public void CreateNewAccount(string userName, string password)
        //{
        //    SqlConnection Connection = new SqlConnection("data source=localhost;initial catalog=DefaultConnection;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        //    Connection.Open();
        //    SqlCommand Command = new SqlCommand( " INSERT INTO UserDetails VALUES('" + userName + "', '" + password + "')"  , Connection );



        //   // string query = "INSERT INTO UserDetails VALUES ('" + firstName + "','" + lastName + "','" + userName + "','" + password + "');";


        //    Command.ExecuteNonQuery();

        //    Connection.Close();
        //}


        


        //// PUT api/values/5
        //public void Put(int psw, User user)
        //{
        //    int index = list.ToList().FindIndex(e => e.password == psw);
        //    list[index] = user;
        //}

        //// DELETE api/values/5
        //public void Delete(int psw)
        //{
        //    User user = Get(psw);
        //    list.Remove(user);
        //}

        //void EnsureAuthenticated(string role)
        //{
        //    string[] parts = UTF8Encoding.UTF8.GetString(Convert.FromBase64String(Request.Headers.Authorization.Parameter)).Split(':');
        //    if (parts.Length != 2 || !Membership.ValidateUser(parts[0], parts[1]))
        //        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "No account with that username and password"));
        //    if (role != null && !Roles.IsUserInRole(parts[0], role))
        //        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "An administrator account is required"));
        //}
    }
}
