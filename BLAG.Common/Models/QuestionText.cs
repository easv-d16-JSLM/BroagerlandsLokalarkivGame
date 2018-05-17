using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLAG.Common.Models
{
    public class QuestionText : QuestionBase
    {
        [Required]
        [StringLength(500)]
        public string Text { get; set; }
    }
}
