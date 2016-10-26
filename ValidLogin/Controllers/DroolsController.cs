using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;

namespace ValidLogin.Controllers
{
    
    public class DroolsController : ApiController
    {

        List<AgeSexDrools> agesex = new List<AgeSexDrools>();
        List<AgeNameDroolsName> agesexName = new List<AgeNameDroolsName>();

        //    //GET/api/AgeSex
        [ActionName("lala")]
        public IEnumerable<AgeNameDroolsName> Get()
        {
            // HealthMeApp_Data db = new HealthMeApp_Data();

            using (HealthMeApp_Data db = new HealthMeApp_Data())
            {
                foreach (var user in db.User)

                {

                    var age = (from item_a in db.Result
                               where (item_a.QuestionId == 1 && item_a.UserId == user.Id)
                               select item_a.AnswerId).FirstOrDefault(); //id=2

                    var ageName = (from a in db.Answer
                                   where (a.Id == age)
                                   select a.Name).FirstOrDefault();


                    var sex = (from item_s in db.Result
                               where (item_s.QuestionId == 2 && item_s.UserId == user.Id)
                               select item_s.AnswerId).FirstOrDefault();

                    var sexName = (from s in db.Answer
                                   where (s.Id == sex)
                                   select s.Name).FirstOrDefault();

                    // agesex.Add(new AgeSexDrools() { Id = user.Id, Age = age, Sex = sex });
                    agesexName.Add(new AgeNameDroolsName() { Id = user.Id, AgeN = ageName, SexN = sexName });
                }

            }

            return agesexName;

        }



    }


   


}
    

