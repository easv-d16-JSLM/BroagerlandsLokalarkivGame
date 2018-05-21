using System;

namespace BLAG.Common.Models
{
    public class QuestionBase : ModelBase
    {
        public int Points { get; set; }
        public Questionnaire Questionnaire { get; set; } 
        public TimeSpan Time { get; set; }
    }
}