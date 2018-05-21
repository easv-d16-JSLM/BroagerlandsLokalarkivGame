using System.Collections.Generic;

namespace BLAG.Common.Models
{
    public class AnswerTextChoice : AnswerBase<string>
    {
        public IList<string> TextChoices;
        public string CorrectChoice; 

        protected override double GetCorrectness(string userAnswer)
        {
            return userAnswer.Equals(CorrectChoice) ? 1 : 0;
        }
    }
}
