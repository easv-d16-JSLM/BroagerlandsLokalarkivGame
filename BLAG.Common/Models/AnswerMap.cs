using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLAG.Common.Models
{
    class AnswerMap : AnswerBase
    {
        [Required]
        public double Latitude;
        [Required]
        public double Longtitude;
    }
}
