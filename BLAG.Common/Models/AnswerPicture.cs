using System;
using System.Collections.Generic;
using System.Text;

namespace BLAG.Common.Models
{
    class AnswerPicture : AnswerBase<int>
    {
        public IList<Object> PictureList;
        public int CorrectPictureIndex;

        protected override double GetCorrectness(int userAnswer)
        {
            return userAnswer.Equals(CorrectPictureIndex) ? 1 : 0;
        }
    }
}
