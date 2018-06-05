using System.Collections.Generic;

namespace BLAG.Common.Models
{
    public class Answer : ModelBase
    {
        public QuestionType AnswerType { get; set; }
        public string CorrectAnswer { get; set; }
        public IList<string> Options { get; set; }
        public Question Question { get; set; }
    }
}