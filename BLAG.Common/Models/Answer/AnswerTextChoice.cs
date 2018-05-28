using System.Collections.Generic;

namespace BLAG.Common.Models.Answer
{
    public class AnswerTextChoice : AnswerBase<string>
    {
        public string CorrectChoice { get; set; }
        public IList<string> TextChoices { get; set; }

        protected override double GetCorrectness(string userAnswer)
        {
            return userAnswer.Equals(CorrectChoice) ? 1 : 0;
        }
    }
}