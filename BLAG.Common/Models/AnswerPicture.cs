using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLAG.Common.Models
{
    public class AnswerPicture : AnswerBase
    {
        [Required]
        public IList<byte[]> PictureList;
        [Required]
        public int CorrectPictureIndex;

    }
}
