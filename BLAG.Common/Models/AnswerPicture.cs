using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLAG.Common.Models
{
    public class AnswerPicture : AnswerBase<int>
    {
        [Required]
        public IList<byte[]> PictureList;
        [Required]
        public int CorrectPictureIndex;

        protected override double GetCorrectness(int userAnswer)
        {
            return userAnswer.Equals(CorrectPictureIndex) ? 1 : 0;
        }
    }
}
