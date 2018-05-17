using System;
using System.Collections.Generic;
using System.Text;
using BLAG.Common.Models;

namespace BLAG.Common
{
    public class ScoreCalculator
    {
        public double Score(QuestionBase question, TimeSpan time)
        {
            var timeLapsed = time.TotalMilliseconds;
            var timeMax = question.Time.TotalMilliseconds;

            if (1 - timeLapsed / timeMax >= 0.9)
                return question.Points;
            
            return question.Points * 1.05 - ((timeLapsed / timeMax) / 2) * question.Points;
        }
    }
}
