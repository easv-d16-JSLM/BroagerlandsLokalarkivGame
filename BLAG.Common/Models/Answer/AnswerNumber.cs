using System;

namespace BLAG.Common.Models.Answer

{
    public class AnswerNumber : AnswerBase<double>
    {
        public double CorrectValue { get; set; }

        public int Precision { get; set; }


        protected override double GetCorrectness(double userAnswer)
        {
            var test = Math.Exp(-Math.Pow(userAnswer - CorrectValue, 2) / (2 * Math.Pow(Precision, 2)));
            return test;
        }
    }
}