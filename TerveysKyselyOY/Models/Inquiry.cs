using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TerveysKyselyOY.Models
{
    public class Inquiry
    {
        public int InquiryID { get; set; }
        public string InquiryName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InquiryDate { get; set; }


        public List<Question> InquiryQuestions { get; set; }

        public Patient PatientID { get; set; }
        public Patient Patient { get; set; }

    }
}
