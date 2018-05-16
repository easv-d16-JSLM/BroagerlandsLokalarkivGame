namespace BLAG.Common.Models
{
    public abstract class AnswerBase : ModelBase
    {
        public QuestionBase Question { get; set; }
    }
}