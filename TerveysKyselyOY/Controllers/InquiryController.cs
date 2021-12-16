using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerveysKyselyOY.Data;
using TerveysKyselyOY.Models;
using TerveysKyselyOY.ViewModels;

namespace TerveysKyselyOY.Controllers
{
    public class InquiryController : Controller
    {
        //Totally would be nice to have a Database for this
        private ExampleData ex = new ExampleData();
        static List<string> aList = new List<string>();
        static List<int> nList = new List<int>();

        //*****************************************************
        //List of inquiries
        //*****************************************************
        public ActionResult Index()
        {
            return View(ex.InquiriesList);
        }

        //*****************************************************
        //Answers
        //*****************************************************
        public ActionResult Answer(int id)
        {
            //Clearing the "database"
            aList.Clear();
            nList.Clear();
            
            var questionCount = (from que in ex.QuestionList
                                 where que.InquiryID == id
                                 select que).Count();

            var inquiryName = (from inq in ex.InquiriesList
                               where inq.InquiryID == id
                               select inq.InquiryName).FirstOrDefault();

            ViewBag.InquiryName = inquiryName;
            ViewBag.QuestionCount = questionCount;
            ViewBag.QuestionNumber = 0;

            QuestionAnswerModel inquiry = (from inq in ex.QuestionList
                                           where inq.InquiryID == id
                                           select new QuestionAnswerModel
                                           {
                                               InquiryID = inq.InquiryID,
                                               SubjectID = inq.SubjectID,
                                               QuestionID = inq.QuestionID,
                                               QuestionContent = inq.QuestionContent,
                                               QuestionStyle = inq.QuestionStyle,
                                               MultipleChoices = inq.MultipleChoices,
                                               QuestionPoints = inq.QuestionPoints,
                                               PointsMultiplier = inq.PointsMultiplier
                                               

                                           }).ElementAt(0);

            //var inquiry = ex.QuestionList.Where(x => x.InquiryID == id);

            return View(inquiry);
        }

        [HttpPost]
        public ActionResult Answer(QuestionAnswerModel ans, int count, int qCount, string inquiryN)
        {
            try
            {
                //timestamp for answer
                ans.AnswerDate = DateTime.Now;
                //here you can save your answers to db later on...now we save it to controller wide list as a string
                if (!string.IsNullOrEmpty(ans.StringAnswer))
                {
                    aList.Add(ans.QuestionContent.Remove(ans.QuestionContent.Length - 1) + ": " + ans.StringAnswer);
                }
                else if (ans.IntAnswer != 0)
                {
                    aList.Add(ans.QuestionContent.Remove(ans.QuestionContent.Length - 1) + ": " + ans.IntAnswer.ToString());
                }
                else
                {
                    var mChoices = (from inq in ex.QuestionList
                                    where inq.InquiryID == ans.InquiryID
                                    select inq.MultipleChoices).ToArray();

                    if (ans.BoolAnswer == true)
                    {
                        aList.Add(ans.QuestionContent.Remove(ans.QuestionContent.Length - 1) + ": " + mChoices[count][1]);
                        nList.Add(ans.QuestionPoints * ans.PointsMultiplier);
                        
                    }
                    else if (ans.BoolAnswer == false)
                    {
                        aList.Add(ans.QuestionContent.Remove(ans.QuestionContent.Length - 1) + ": " + mChoices[count][0]);
                        nList.Add(ans.QuestionPoints);
                    }
                }

                ViewBag.QuestionCount = qCount;


                //let's go to the next question + 1 (using ElementAt(count))
                count = count + 1;

                //if we have reached the last question in the specific inquiry...
                if (count == qCount)
                {
                    //showing all the answers to user
                    ViewBag.aList = aList;
                    //Converting totalpoints to decimal as needed
                    ViewBag.TotalPoints = Convert.ToDecimal(nList.Sum());
                    ViewBag.QuestionNumber = count;
                    ViewBag.InquiryName = inquiryN;
                    //passing timestamp to View
                    ViewBag.AnswerTimeStamp = ans.AnswerDate;
                    return View();
                }
                //...else next question
                else
                {
                    //we need to know the question in hand
                    ViewBag.QuestionNumber = count;
                    //we are passing Inquiry name until survey is finished
                    ViewBag.InquiryName = inquiryN;
            
                    QuestionAnswerModel inquiry = (from inq in ex.QuestionList
                                                   where inq.InquiryID == ans.InquiryID
                                                   select new QuestionAnswerModel
                                                   {
                                                       InquiryID = inq.InquiryID,
                                                       SubjectID = inq.SubjectID,
                                                       QuestionID = inq.QuestionID,
                                                       QuestionContent = inq.QuestionContent,
                                                       QuestionStyle = inq.QuestionStyle,
                                                       MultipleChoices = inq.MultipleChoices,
                                                       QuestionPoints = inq.QuestionPoints,
                                                       PointsMultiplier = inq.PointsMultiplier

                                                   }).ElementAt(count);

                    return View(inquiry);
                }
            }
            //Any errors and you're back in Inquiry listing for now...
            catch
            {
                RedirectToAction("Inquiry", "Index");
            }
            return View();
        }
    }
}
