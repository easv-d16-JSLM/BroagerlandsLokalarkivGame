using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLAG.Common.Models
{
    public class QuestionAudio : QuestionBase
    {
        [Required]
        public byte[] Audio { get; set; }
    }
}
