using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerveysKyselyOY.Models;

namespace TerveysKyselyOY.Data
{
    public class ExampleData
    {
        //Totally would be nice to have a Database for this, yet here is the global exampledata
        public static Subject Sub0 { get; set; } = new Subject { SubjectID = 0, SubjectName = "Yleinen terveys" };
        public static Subject Sub1 { get; set; } = new Subject { SubjectID = 1, SubjectName = "Palveluiden laadunhallinta" };
        public static Subject Sub2 { get; set; } = new Subject { SubjectID = 2, SubjectName = "Viihtyvyys" };

        //For 1st inquiry
        public static Question Que0 { get; set; } = new Question { QuestionID = 0, QuestionContent = "Mikä on viimeisin sinulle suoritettu operaatio?", SubjectID = Sub0.SubjectID, InquiryID = 0, QuestionStyle = "text"};

        public static Question Que1 { get; set; } = new Question { QuestionID = 1, QuestionContent = "Menikö kaikki hyvin asteikolla 1-10?", SubjectID = Sub1.SubjectID, InquiryID = 0, QuestionStyle = "number" };

        public static Question Que4 { get; set; } = new Question { QuestionID = 4, QuestionContent = "Missä voisimme parantaa?", SubjectID = Sub1.SubjectID, InquiryID = 0, QuestionStyle = "text" };

        //For 2nd inquiry
        public static Question Que2 { get; set; } = new Question { QuestionID = 2, QuestionContent = "Viihdytkö hyvin asteikolla 1-10?", SubjectID = Sub2.SubjectID, InquiryID = 1, QuestionStyle = "number" };

        public static Question Que3 { get; set; } = new Question { QuestionID = 3, QuestionContent = "Paljonko olet valmis maksamaan viihtyvyydestä 1-10 000€?", SubjectID = Sub2.SubjectID, InquiryID = 1, QuestionStyle = "bignumber" };

        //For 3rd inquiry
        public static Question Que5 { get; set; } = new Question { QuestionID = 5, QuestionContent = "Miten voit tänään?", SubjectID = Sub2.SubjectID, InquiryID = 2, QuestionStyle = "multiple", MultipleChoices = new[] { "Paremminkin voisi mennä", "Voin hyvin" }, QuestionPoints = 5, PointsMultiplier = 2 };
        public static Question Que6 { get; set; } = new Question { QuestionID = 6, QuestionContent = "Kuinka monta kertaa olet unohtanut ottaa lääkkeesi viimeisen viikon aikana?", SubjectID = Sub1.SubjectID, InquiryID = 2, QuestionStyle = "multiple", MultipleChoices = new[]{ "Yhden tai useamman kerran", "En kertaakaan" }, QuestionPoints = 2, PointsMultiplier = 5 };

        public List<Question> QuestionList { get; set; } = new List<Question> { Que0, Que1, Que2, Que3, Que4, Que5, Que6 };

        public static Inquiry Inq0 { get; set; } = new Inquiry { InquiryID = 0, InquiryDate = DateTime.Now, InquiryName = "Terveyskysely aiheesta terveys", InquiryQuestions=new List<Question> { Que0, Que1, Que4 } };

        public static Inquiry Inq1 { get; set; } = new Inquiry { InquiryID = 1, InquiryDate = DateTime.Now, InquiryName = "Viihtyvyyskysely aiheesta viihtyvyys", InquiryQuestions = new List<Question> { Que2, Que3 } };

        public static Inquiry Inq2 { get; set; } = new Inquiry { InquiryID = 2, InquiryDate = DateTime.Now, InquiryName = "Valintakysymykset", InquiryQuestions = new List<Question> { Que5, Que6 } };

        public List<Inquiry> InquiriesList { get; set; } = new List<Inquiry> { Inq0, Inq1, Inq2 };

    }
}
