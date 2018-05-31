using System.Collections.Generic;

namespace BLAG.Common.Models
{
    public class Answer : ModelBase
    {
        public string CorrectAnswer { get; set; }
        public IList<string> Options { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}