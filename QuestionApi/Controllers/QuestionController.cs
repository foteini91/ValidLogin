using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuestionApi.Controllers
{
    public class QuestionController : ApiController
    {
        // GET api/Question
        [ActionName("ReturnQuestion")]
        public IQueryable<string> Get()
        {
            QuestionContext db = new QuestionContext();
            var questions = from q in db.Question select q.Name;
            return questions;

        }
    }
}
