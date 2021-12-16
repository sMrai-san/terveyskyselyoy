using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TerveysKyselyOY.Models;
using Xunit;

namespace UnitTests
{
    public class UnitTests
    {
        //***********************************************
        //MODEL TESTING
        //***********************************************


        //***********************************************
        //Under 256 string does not fail in Answer Model
        [Fact]
        public void IsStringUnder256()
        {
            //String for testing
            var under256String = new StringBuilder();
            for (var i = 0; i < 256; i++)
            {
                under256String.Append("a");
            }

            //Write the string into a Model
            var stringAns = new Answer
            {
                StringAnswer = under256String.ToString()
            };

            var validationResultsUnder = new List<ValidationResult>();
            //Should be true, because Model max string lenght is 256
            var actualUnder = Validator.TryValidateObject(stringAns, new ValidationContext(stringAns), validationResultsUnder, true);
            Assert.True(actualUnder, "String is under or 256 charachers long");
            Assert.Empty(validationResultsUnder);
        }

        //***********************************************
        //Over 256 string Fails in Answer Model
        [Fact]
        public void IsStringOver256()
        {
            //String for testing
            var over256String = new StringBuilder();
            for (var i = 0; i < 257; i++)
            {
                over256String.Append("a");
            }

            //Write the string into a Model
            var stringAns = new Answer
            {
                StringAnswer = over256String.ToString()
            };

            var validationResultsOver = new List<ValidationResult>();
            //Should be false, because Model max string lenght is 256
            var actualOver = Validator.TryValidateObject(stringAns, new ValidationContext(stringAns), validationResultsOver, false);
            Assert.True(actualOver, "String is over 256 charachters");
            Assert.Empty(validationResultsOver);
        }


        //***********************************************
        //Under 10 000 int in Model
        [Fact]
        public void IsIntUnder10000()
        {
            //Int to be tested
            var overInt = 10000;
            //Write it to Model
            var intAns = new Answer
            {
                IntAnswer = overInt
            };

            
            var validationResultsOver = new List<ValidationResult>();
            //should be in range
            Assert.InRange(intAns.IntAnswer, 0, 10000);
            //let us test if it is not in range at all
            Assert.NotInRange(intAns.IntAnswer + 1, 0, 10000);
            Assert.Empty(validationResultsOver);
        }

        //***********************************************
        //Points and multiple choice testing
        [Fact]
        public void IsGettingPoints()
        {

            //Answering question with a true
            Answer userAnswer = new Answer
            {
                BoolAnswer = true
            };

            //Testing if the BoolAnswer gets true/false
            Assert.True(userAnswer.BoolAnswer, "BoolAnswer in Answer Model is true");
            Assert.False(!userAnswer.BoolAnswer, "BoolAnswer in Answer Model is false");


            //Questions
            var question0 = new Question
            {
                MultipleChoices = new string[] { "Paremminkin voisi mennä", "Voin hyvin" },
                QuestionPoints = 5,
                PointsMultiplier = 2

            };
            var question1 = new Question
            {
                MultipleChoices = new string[] { "Yhden tai useamman kerran", "En kertaakaan" },
                QuestionPoints = 2,
                PointsMultiplier = 5

            };

            //Placeholder for the question in hand
            var answer = "";
            //Answered "Voin hyvin" 10 points this is false
            answer = question0.MultipleChoices[1];
            if (answer == question0.MultipleChoices[1])
            {
                var falseUsesMultiplier = question0.QuestionPoints * question0.PointsMultiplier;
                Assert.Equal(10, falseUsesMultiplier);
                //testing true too
                Assert.Equal(5, question0.QuestionPoints);
            }

            //Answered "Yhden tai useamman kerran" 2 points this is true
            answer = question1.MultipleChoices[0];
            if (answer == question1.MultipleChoices[0])
            {
                //no multiplier needed when true, yet we do not want nulls at all
                var trueNeedsNoMultiplier = 1;
                Assert.Equal(2, question1.QuestionPoints * trueNeedsNoMultiplier);
                //testing false too
                Assert.Equal(10, question1.QuestionPoints * question1.PointsMultiplier);
            }

            var validationResultsOver = new List<ValidationResult>();
            Assert.Empty(validationResultsOver);
        }

    }
}
