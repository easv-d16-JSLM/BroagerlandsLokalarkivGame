namespace BLAG.Common.Models
{
    public class AnswerNumber : AnswerBase<double>
    {
        public double CorrectValue;

        protected override double GetCorrectness(double userAnswer)
        {
            return userAnswer.Equals(CorrectValue) ? 1 : 0;
        }
    }
}