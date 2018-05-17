using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLAG.Common.Models
{
    class AnswerPicture : AnswerBase
    {
        [Required]
        public IList<Object> PictureList;
        [Required]
        public int CorrectPictureIndex;

    }
}
