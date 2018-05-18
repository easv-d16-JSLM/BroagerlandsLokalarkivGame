using System;
using System.ComponentModel.DataAnnotations;

namespace BLAG.Common.Models
{
    public class QuestionBase : ModelBase
    {
        [Required]
        public int Points { get; set; }
        [Required]
        public Questionnaire Questionnaire { get; set; } 
        
        public TimeSpan Time { get; set; }
    }
}