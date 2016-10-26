using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ValidLogin.Controllers
{
    public class QuestionController : ApiController
    {
        // GET api/Question
        //[ActionName("ReturnQuestion")]
        //public IQueryable<string> Get()
        //{
        //    AllContext db = new AllContext();
        //    var questions = from q in db.Question select q.Name;
        //    return questions;

        //}

        //GET api/Question/Name/Id
        [ActionName("ReturnQuestionNameId")]
        public IQueryable<IdValue> Get()
        {
            HealthMeApp_Data db = new HealthMeApp_Data();
            var Id_Name = from item in db.Question
                          select new IdValue { Id = item.Id, Name = item.Name };
            return Id_Name;
        }

        ////Get api/Question
        //[ActionName("ReturnNumberOfQuestions")]
        //public int GetNumQuestion()
        //{
        //    AllContext db = new AllContext();
        //    var num_q = (from q in db.Question select q.Name).Count();
        //    return num_q;
        //}

        // GET api/Question/Answer
        [ActionName("NumberOfAnwersByQuestionID")]
        public int GetNumber(int id)
        {
            HealthMeApp_Data db = new HealthMeApp_Data();
            int num = (from a in db.Answer where a.QuestionId == id select a).Count();
            return num;
        }
    }
}
