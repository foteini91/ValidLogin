using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ValidLogin.Controllers
{
    public class AnswerController : ApiController
    {
        //GET/api/Answers
        [ActionName("AnswersByQuestionId")]
        public IQueryable<IdNameAnswer> Get(int id_Q)
        {
            HealthMeApp_Data db = new HealthMeApp_Data();
            var Id_NameAnswer = from item in db.Answer
                                where (item.QuestionId == id_Q)
                                select new IdNameAnswer { Id = item.Id, Name = item.Name };
            return Id_NameAnswer;
        }

        //[ActionName("GetAnswers")]
        //public IList<int> Get()
        //{
        //    AllContext db = new AllContext();
        //    return from item in db.Answer 
        //}

        //POST/api/Answers
        //[ActionName("PostAnswers")]
        //public void Post(int id_A)
        //{
        //    using (AllContext db = new AllContext())
        //    {
        //        Result insert = new Result();

        //        var _result = from item in db.Answer
        //                      where (item.Id == id_A)
        //                      select new ResultValue { id_User = 1, id_Question = item.QuestionId, id_Answer = id_A };

        //        db.Result.Add(_result);

        //        ResultValue insert_a = new ResultValue();
        //        insert.UserId = 1;
        //        insert.QuestionId = result;
        //        insert.AnswerId = insert_a.id_Answer;
        //        db.Result.Add(insert);
        //        db.SaveChanges();

        //    }
        //}

        [ActionName("PostAnswers")]
        public void Post(int id_A,int id_U)
        {
            using (HealthMeApp_Data db = new HealthMeApp_Data())
            {
                var id_Q = (from item in db.Answer
                           where (item.Id == id_A)
                           select item.QuestionId).First();

                Result insert = new Result();
                insert.AnswerId = id_A;
                insert.QuestionId = id_Q;
                insert.UserId = id_U;
                db.Result.Add(insert);
                db.SaveChanges();
            }
        }

        //[ActionName("PostAnswers")]
        //public void Post(int id_A)
        //{
        //    using (AllContext db = new AllContext())
        //    {
        //        Result insert = new Result();
        //        insert.AnswerId = id_A;
        //        insert.UserId = 3;
        //        insert.QuestionId = 2;
        //        db.Result.Add(insert);
        //        db.SaveChanges();
        //    }

        //}

       



        //    [ActionName("PostAnswers")]
        //    [HttpPost]
        //    public string POST(int qId)
        //    {
        //        AllContext db = new AllContext();
        //        var ans = db.Answer.Select(u => u.QuestionId == qId);
        //        return ans.Name;
        //    }
    }
}
