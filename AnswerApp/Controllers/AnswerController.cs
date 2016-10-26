using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AnswerApp.Controllers
{
    public class AnswerController : ApiController
    {
        [ActionName("PostAnswers")]
        [HttpPost]
        public string POST(int qId)
        {
            AnswerContext db = new AnswerContext();
            var ans = db.Answer.Find(u => u.QuestionId == qId);
            return ans.Name;
        }
    }
}
