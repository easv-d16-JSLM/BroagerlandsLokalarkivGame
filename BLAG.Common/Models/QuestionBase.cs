using System;
using System.ComponentModel.DataAnnotations;

namespace BLAG.Common.Models
{
    public abstract class QuestionBase : ModelBase
    {
        [Required]
        public int Points { get; set; }
        [Required]
        public Questionnaire Questionnaire { get; set; } 
        [Required]
        public TimeSpan Time { get; set; }
    }
}