using System;
using System.ComponentModel.DataAnnotations;

namespace BLAG.Common.Models
{
    public abstract class QuestionBase : ModelBase
    {
        [Required]
        public uint Points { get; set; }
        [Required]
        public object Questionnaire { get; set; } //TODO: replace
        [Required]
        public TimeSpan Time { get; set; }
    }
}