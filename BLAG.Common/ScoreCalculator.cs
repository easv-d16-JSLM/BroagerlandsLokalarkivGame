using System;
using BLAG.Common.Models;

namespace BLAG.Common
{
    public class ScoreCalculator
    {
        public double Score(Question question, TimeSpan time)
        {
            var timeElapsed = time.TotalMilliseconds;
            var timeMax = question.Time.TotalMilliseconds;

            var timeUsed = timeElapsed / timeMax;
            if (timeUsed <= 0.1)
                return question.Points;

            return question.Points * (1.05 - timeUsed / 2);
        }
    }
}