using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLAG.Common.Models
{
    public class AnswerNumber : AnswerBase<double>
    {
        [Required]
        public double CorrectValue;
        protected override double GetCorrectness(double userAnswer)
        {
            return userAnswer.Equals(CorrectValue) ? 1 : 0;
        }
    }
}
