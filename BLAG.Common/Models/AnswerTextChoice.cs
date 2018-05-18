using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLAG.Common.Models
{
    public class AnswerTextChoice : AnswerBase<string>
    {
        [Required]
        public IList<String> TextChoices;

        [Required]
        public String CorrectChoice; 

        protected override double GetCorrectness(string userAnswer)
        {
            return userAnswer.Equals(CorrectChoice) ? 1 : 0;
        }
    }
}
