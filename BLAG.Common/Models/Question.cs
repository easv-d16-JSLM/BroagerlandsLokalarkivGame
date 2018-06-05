using System;

namespace BLAG.Common.Models
{
    public class Question : ModelBase
    {
        public string Content { get; set; }
        public int Points { get; set; }
        public QuestionType QuestionType { get; set; }
        public TimeSpan Time { get; set; }
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