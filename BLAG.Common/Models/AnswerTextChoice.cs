using System.Collections.Generic;

namespace BLAG.Common.Models
{
    public class AnswerTextChoice : AnswerBase<string>
    {
        public string CorrectChoice;
        public IList<string> TextChoices;

        protected override double GetCorrectness(string userAnswer)
        {
            return userAnswer.Equals(CorrectChoice) ? 1 : 0;
        }
    }
}