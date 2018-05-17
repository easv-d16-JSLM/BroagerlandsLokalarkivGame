using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLAG.Common.Models
{
    public class QuestionVideo : QuestionBase
    {
        // Collection of STRINGS, CHANGE LATER - not supposed to be string
        [Required]
        public String Video { get; set; }
    }
}
