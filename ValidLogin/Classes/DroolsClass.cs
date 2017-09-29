using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ValidLogin.Classes
{
    public class DroolsClass
    {
        public static string Address = "http://192.168.0.124:8180/kie-server/services/rest/";

        public static List<TipName> listTips = new List<TipName> { };
        static AnswerName answerName = new AnswerName();

        public void InsertTip(int userID)
        {
            XElement xElem = GetXmlData();
            var aa = Get(userID);

            //  foreach (var item in answerName)
            //  {
            var asdf = QueryData(xElem, aa.AgeN, aa.SexN, aa.SleepN, aa.AlcN, aa.StressN, aa.ActivityN,
                                 aa.SmokingN, aa.BreakN, aa.WtrN);
            //  }

            PostXml(asdf);

            PostTip(userID, listTips);
            listTips.Clear();
        }


        public void PostTip(int id_user, List<TipName> listTips)
        {
            using (HealthMeApp_Data db = new HealthMeApp_Data())
            { 
                Tip insert = new Tip();
                if (db.Tip.Any(u => u.UserId == id_user))
                {
                    var tt = (from t in db.Tip where t.UserId == id_user select t).ToList();
                    foreach (var newT in listTips)
                    {
                        foreach (var item in tt)
                        {
                            item.Name = newT.Name;
                        }
                    }
                }
                else foreach (var item in listTips)
                    {
                        insert.Name = item.Name;
                        insert.UserId = id_user;
                        db.Tip.Add(insert);
                        db.SaveChanges();
                    }
                             

            }
        }








        //-----------------------------------M E T H O D S---------------------------------------------//

        //---------Create the XML----------------------------------------------------------------------//
        public static XElement GetXmlData()
        {
            //creating an xml document
            XElement xmldoc = new XElement(
               new XElement("batch-execution", new XAttribute("lookup", "defaultKieSession"),
               new XElement("insert", new XAttribute("out-identifier", "usr2"),
               new XElement("demo.allnewrules.User",
               new XElement("ageS", ""),
               new XElement("sex", ""),
               new XElement("smoking", ""),
               new XElement("alc_drinking", ""),
               new XElement("stress", ""),
               new XElement("breakfast", ""),
               new XElement("slp_hours", ""),
               new XElement("ph_activity", ""),
               new XElement("wtr_drinking", ""))),
               new XElement("fire-all-rules")));

            return xmldoc;
        }


        //---------Modify the XML by setting AGE and SEX----------------------------------------------//
        public static XElement QueryData(XElement queryitem, string ag, string se,
                                                   string slp, string alc, string str, string act, string smk,
                                                   string brk, string wtr)
        {
            try //emfanizei NullReference exception
            {
                var list = from XElement e in queryitem.Descendants("demo.allnewrules.User")
                           select e;

                foreach (XElement node in list)
                {
                    node.ReplaceWith(new XElement("demo.allnewrules.User",
                        new XElement("ageS", ag),
                        new XElement("sex", se),
                        new XElement("smoking", smk),
                        new XElement("alc_drinking", alc),
                        new XElement("stress", str),
                        new XElement("breakfast", brk),
                        new XElement("slp_hours", slp),
                        new XElement("ph_activity", act),
                        new XElement("wtr_drinking", wtr)));
                }

            }

            catch (NullReferenceException nre)
            {
                Console.WriteLine("\nNullReference" + nre.Message);
            }
            return queryitem;
        }


        //-----------return UserId + Age(Name) + Sex(Name)----------------------------------------//
        public static AnswerName Get(int uId)
        {
            using (HealthMeApp_Data db = new HealthMeApp_Data())
            {
                // foreach (var user in db.User)

                // {

                var age = (from item_a in db.Result
                           where (item_a.QuestionId == 1 && item_a.UserId == uId)
                           select item_a.AnswerId).FirstOrDefault(); //id=2

                var ageName = (from a in db.Answer
                               where (a.Id == age)
                               select a.Name).FirstOrDefault();


                var sex = (from item_s in db.Result
                           where (item_s.QuestionId == 2 && item_s.UserId == uId)
                           select item_s.AnswerId).FirstOrDefault();

                var sexName = (from s in db.Answer
                               where (s.Id == sex)
                               select s.Name).FirstOrDefault();


                var sleep = (from item_slp in db.Result
                             where (item_slp.QuestionId == 3 && item_slp.UserId == uId)
                             select item_slp.AnswerId).FirstOrDefault();

                var sleepName = (from slp in db.Answer
                                 where (slp.Id == sleep)
                                 select slp.Name).FirstOrDefault();


                var alcohol = (from item_alc in db.Result
                               where (item_alc.QuestionId == 4 && item_alc.UserId == uId)
                               select item_alc.AnswerId).FirstOrDefault();

                var alcName = (from alc in db.Answer
                               where (alc.Id == alcohol)
                               select alc.Name).FirstOrDefault();


                var stress = (from item_str in db.Result
                              where (item_str.QuestionId == 5 && item_str.UserId == uId)
                              select item_str.AnswerId).FirstOrDefault();

                var stressName = (from str in db.Answer
                                  where (str.Id == stress)
                                  select str.Name).FirstOrDefault();


                var activity = (from item_act in db.Result
                                where (item_act.QuestionId == 6 && item_act.UserId == uId)
                                select item_act.AnswerId).FirstOrDefault();

                var activityName = (from act in db.Answer
                                    where (act.Id == activity)
                                    select act.Name).FirstOrDefault();


                var smoke = (from item_smk in db.Result
                             where (item_smk.QuestionId == 7 && item_smk.UserId == uId)
                             select item_smk.AnswerId).FirstOrDefault();

                var smokeName = (from smk in db.Answer
                                 where (smk.Id == smoke)
                                 select smk.Name).FirstOrDefault();


                var breakfast = (from item_brk in db.Result
                                 where (item_brk.QuestionId == 8 && item_brk.UserId == uId)
                                 select item_brk.AnswerId).FirstOrDefault();

                var breakName = (from brk in db.Answer
                                 where (brk.Id == breakfast)
                                 select brk.Name).FirstOrDefault();


                var water = (from item_wtr in db.Result
                             where (item_wtr.QuestionId == 9 && item_wtr.UserId == uId)
                             select item_wtr.AnswerId).FirstOrDefault();

                var waterName = (from wtr in db.Answer
                                 where (wtr.Id == water)
                                 select wtr.Name).FirstOrDefault();



                // agesex.Add(new AgeSexDrools() { Id = user.Id, Age = age, Sex = sex });
                //answerName.Add(new AnswerName()
                //{
                answerName.Id = uId;
                answerName.AgeN = ageName;
                answerName.SexN = sexName;
                answerName.AlcN = alcName;
                answerName.BreakN = breakName;
                answerName.ActivityN = activityName;
                answerName.SmokingN = smokeName;
                answerName.WtrN = waterName;
                answerName.StressN = stressName;
                answerName.SleepN = sleepName;
                //});
                //}

            }

            return answerName;
        }


        //---------------------------Post in web service(containers) the XML-Retrieve the value TIP--------//
        public static IList<TipName> PostXml(XElement xml)
        {

            var client = new RestClient(Address);

            var request = new RestRequest("server/containers/instances/TipContainer", Method.POST);
            //request.RequestFormat = DataFormat.Xml; //mallon kanei aytomata serialization to json??
            request.AddHeader("Accept", "application/xml");
            request.AddParameter("application/xml", xml, ParameterType.RequestBody);
            request.AddHeader("X-KIE-ContentType", "XSTREAM");
            request.AddHeader("Authorization", "Basic a2llc2VydmVyOmtpZXNlcnZlcjEh");
            request.AddBody(xml);

            var response = client.Execute<ResponseClass.orgkieserverapimodelServiceResponseResultResultDemoallnewrulesUser>(request);
            var user = response.Data; //object



            try
            {

                if (!user.tipBreakfast.ToString().Equals("System.Object"))
                {
                    listTips.Add(new TipName() { Name = user.tipBreakfast.ToString() });

                }

                if (!user.tipDrink.ToString().Equals("System.Object"))
                {
                    listTips.Add(new TipName() { Name = user.tipDrink.ToString() });

                }

                if (!user.tipPhysical.ToString().Equals("System.Object"))
                {
                    listTips.Add(new TipName() { Name = user.tipPhysical.ToString() });

                }


                if (!user.tipSleep.ToString().Equals("System.Object"))
                {
                    listTips.Add(new TipName() { Name = user.tipSleep.ToString() });

                }


                if (!user.tipSmok.ToString().Equals("System.Object"))
                {
                    listTips.Add(new TipName() { Name = user.tipSmok.ToString() });

                }


                if (!user.tipStress.ToString().Equals("System.Object"))
                {
                    listTips.Add(new TipName() { Name = user.tipStress.ToString() });

                }

                if (!user.tipWater.ToString().Equals("System.Object"))
                {

                    listTips.Add(new TipName() { Name = user.tipWater.ToString() });

                }
            }






            //try
            //{

            //if (!String.IsNullOrEmpty(user.tipBreakfast.ToString()))
            //{
            //    listTips.Add(new TipNew() { Name = user.tipBreakfast.ToString() });

            //}
            //else return null;

            //if (!String.IsNullOrEmpty(user.tipWater.ToString()))
            //{
            //    listTips.Add(new TipNew() { Name = user.tipWater.ToString() });

            //}

            //else return null;

            //if (!String.IsNullOrEmpty(user.tipStress.ToString()))
            //{
            //    listTips.Add(new TipNew() { Name = user.tipStress.ToString() });

            //}

            //else return null;
            //if (!String.IsNullOrEmpty(user.tipSmok.ToString()))
            //{
            //    listTips.Add(new TipNew() { Name = user.tipSmok.ToString() });

            //}
            //else return null;

            //if (!String.IsNullOrEmpty(user.tipSleep.ToString()))
            //{
            //    listTips.Add(new TipNew() { Name = user.tipSleep.ToString() });

            //}
            //else return null;

            //if (!String.IsNullOrEmpty(user.tipPhysical.ToString()))
            //{
            //    listTips.Add(new TipNew() { Name = user.tipPhysical.ToString() });

            //}
            //else return null;

            //if (!String.IsNullOrEmpty(user.tipDrink.ToString()))
            //{
            //    listTips.Add(new TipNew() { Name = user.tipDrink.ToString() });

            //}
            //else return null;

            //  }

            catch (NullReferenceException nre)
            {
                Console.WriteLine("\nNullReference" + nre.Message);
            }

            return listTips;





            //try {

            //    Action<string> add = x => { if (!String.IsNullOrEmpty(x)) listTips.Add(new TipNew { Name = x }); };
            //    add(user.tipBreakfast.ToString());
            //    add(user.tipDrink.ToString());
            //    add(user.tipPhysical.ToString());
            //    add(user.tipSleep.ToString());
            //    add(user.tipSmok.ToString());
            //    add(user.tipStress.ToString());
            //    add(user.tipWater.ToString());

            //}
            //catch (NullReferenceException nre)
            //{
            //    Console.WriteLine("\nNullReference" + nre.Message);
            //}
            //return listTips;



            ////if (!String.IsNullOrEmpty(user.tipBreakfast.ToString()))
            ////    {
            ////    usertip.Add(user.tipBreakfast.ToString())
            ////}


            // var usertip = user.tipBreakfast

            ////////        var aa = user.GetType().GetProperties()
            ////////.Where(pi => pi.GetValue(user) is string)
            ////////.Select(pi => (string)pi.GetValue(user));
            // .Any(value => string.IsNullOrEmpty(value));
            //na balo IF sto isnullorempty!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1


            //////var bb = aa.Select(p => !string.IsNullOrEmpty(p));

            // return bb;
            //Console.WriteLine(usertip);
            //Console.ReadLine();

        }






    }


}
