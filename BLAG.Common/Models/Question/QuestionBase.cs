using System;
using LiteDB;

namespace BLAG.Common.Models.Question
{
    public class QuestionBase : ModelBase
    {
        public int Points { get; set; }

        [BsonRef("questionnaires")]
        public Questionnaire Questionnaire { get; set; }

        public TimeSpan Time { get; set; }
    }
}