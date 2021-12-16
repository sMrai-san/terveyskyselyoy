using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerveysKyselyOY.Models
{
    public class Question
    {
        public int QuestionID { get; set; }

        public string QuestionContent { get; set; }

        public string QuestionStyle { get; set; }

        public int QuestionPoints { get; set; }

        public int PointsMultiplier { get; set; }

        public string[] MultipleChoices { get; set; }

        public List<Answer> Answers { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        public int InquiryID { get; set; }
        public Inquiry Inquiry { get; set; }
    }
}
