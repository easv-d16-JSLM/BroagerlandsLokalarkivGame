using System.ComponentModel.DataAnnotations;

namespace BLAG.Common.Models
{
    public class AnswerBase : ModelBase
    {
        [Required]
        public QuestionBase Question { get; set; }
    }
}