using System;
using System.Collections.Generic;
using System.Text;
using BLAG.Common.Models;

namespace BLAG.Common
{
    public class ScoreCalculator
    {
        public int Score(QuestionBase question, TimeSpan time)
        {
            var timeLapsed = time.TotalMilliseconds / question.Time.TotalMilliseconds;

            if (timeLapsed >= 0.8)
                return question.Points * 100;

            var percentage = timeLapsed <= 0.5 ? 50 : timeLapsed;

            return Convert.ToInt32(question.Points * percentage);
        }
    }
}
