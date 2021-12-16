using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TerveysKyselyOY.Models;

namespace TerveysKyselyOY.ViewModels
{
    public class QuestionAnswerModel
    {
        public int QuestionID { get; set; }

        public string QuestionContent { get; set; }

        public string QuestionStyle { get; set; }

        public int QuestionPoints { get; set; }

        public int PointsMultiplier { get; set; }

        public string[] MultipleChoices { get; set; }

        

        [StringLength(256, ErrorMessage = "Tekstipohjaisen kysymyksen vastaus ei saa olla yli 256 merkkiä.")]
        public string StringAnswer { get; set; }

        [Range(0, 10000, ErrorMessage = "Numeropohjaisen kysymyksen vastaus ei saa olla suurempi kuin 10 000.")]
        public int IntAnswer { get; set; }

        public bool BoolAnswer { get; set; }

        public DateTime? AnswerDate { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        public int InquiryID { get; set; }
        public Inquiry Inquiry { get; set; }
    }
}
