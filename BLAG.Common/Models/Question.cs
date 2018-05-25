using System;
using LiteDB;

namespace BLAG.Common.Models
{
    public class Question : ModelBase
    {
        public int Points { get; set; }

        [BsonRef("questionnaires")]
        public Questionnaire Questionnaire { get; set; }

        public TimeSpan Time { get; set; }
        public string Content { get; set; }
        public QuestionType QuestionType { get; set; }
    }

    public enum QuestionType
    {
        Text,
        Announcement,
        Video,
        Image,
        Audio
    }
}