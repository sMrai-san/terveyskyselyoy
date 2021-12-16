using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TerveysKyselyOY.Models
{
    public class Answer
    {
        public int AnswerID { get; set; }

        [StringLength(256, ErrorMessage = "Tekstipohjaisen kysymyksen vastaus ei saa olla yli 256 merkkiä.")]
        public string StringAnswer { get; set; }

        [Range(0, 10000, ErrorMessage = "Numeropohjaisen kysymyksen vastaus ei saa olla suurempi kuin 10 000.")]
        public int IntAnswer { get; set; }

        public bool BoolAnswer { get; set; }

        public DateTime? AnswerDate { get; set; }

        public int QuestionID { get; set; }
        public Question Question { get; set; }

    }
}
