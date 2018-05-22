using System;
using LiteDB;

namespace BLAG.Common.Models
{
    public abstract class AnswerBase<TAnswer> : ModelBase

    {
        [BsonRef("questions")]
        public QuestionBase Question { get; set; }

        public double CalculateScore(TAnswer userAnswer, int pointsMax, TimeSpan timeMax, TimeSpan userTime)
        {
            var points = pointsMax * GetCorrectness(userAnswer);

            var timeLapsed = userTime.TotalMilliseconds;
            var timeTotal = timeMax.TotalMilliseconds;

            if (1 - timeLapsed / timeTotal >= 0.9)
                return points;

            return points * 1.05 - ((timeLapsed / timeTotal) / 2) * points;
        }

        /// <returns>int between 0 and 1</returns>
        protected abstract double GetCorrectness(TAnswer userAnswer);
    }
}