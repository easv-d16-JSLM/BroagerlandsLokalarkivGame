using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLAG.Common.Models
{
    public class QuestionVideo : QuestionBase
    {
        [Required]
        public object Video { get; set; }
    }
}
