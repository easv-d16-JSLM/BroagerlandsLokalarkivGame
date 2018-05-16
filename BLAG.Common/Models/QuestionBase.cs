using System;

namespace BLAG.Common.Models
{
    public abstract class QuestionBase : ModelBase
    {
        public uint Points { get; set; }
        public object Questionnaire { get; set; } //TODO: replace
        public TimeSpan Time { get; set; }
    }
}