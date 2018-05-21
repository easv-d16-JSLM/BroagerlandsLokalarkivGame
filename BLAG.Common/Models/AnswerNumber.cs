using System;

namespace BLAG.Common.Models
{
    public class AnswerNumber : AnswerBase<double>
    {
        public double CorrectValue;
        public int EndValue;
        public int Precision;
        public int StartValue;

        protected override double GetCorrectness(double userAnswer)
        {
            var test = Math.Exp(-Math.Pow(userAnswer - CorrectValue, 2) / (2 * Math.Pow(Precision, 2)));
            return test;
        }
    }
}