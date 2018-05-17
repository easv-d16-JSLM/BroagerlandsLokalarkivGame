using System.ComponentModel.DataAnnotations;

namespace BLAG.Common.Models
{
    public abstract class AnswerBase : ModelBase
    {
        [Required]
        public QuestionBase Question { get; set; }
    }
}