using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLAG.Common.Models
{
    class AnswerTextChoice : AnswerBase
    {
        [Required]
        public IList<String> TextChoices;
        [Required]
        public String CorrectChoice; 
    }
}
