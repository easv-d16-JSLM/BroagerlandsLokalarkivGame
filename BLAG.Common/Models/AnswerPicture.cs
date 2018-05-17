using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLAG.Common.Models
{
    public class AnswerPicture : AnswerBase
    {
        // Collection of STRINGS, CHANGE LATER - not supposed to be string
        [Required]
        public IList<String> PictureList;
        [Required]
        public int CorrectPictureIndex;

    }
}
