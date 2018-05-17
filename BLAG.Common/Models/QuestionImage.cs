using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLAG.Common.Models
{
    public class QuestionImage : QuestionBase
    {
        [Required]
        public object Image { get; set; }
    }
}
