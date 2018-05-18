using System;
using System.Collections.Generic;
using System.Text;

namespace BLAG.Common.Models
{
    public class AnswerTextChoice : AnswerBase<string>
    {
        public IList<String> TextChoices;
        public String CorrectChoice;


        protected override double GetCorrectness(string userAnswer)
        {
            return userAnswer.Equals(CorrectChoice) ? 1 : 0;
        }
    }
}
