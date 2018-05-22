using System.Collections.Generic;

namespace BLAG.Common.Models
{
    public class AnswerPicture : AnswerBase<int>
    {
        public int CorrectPictureIndex;

        // String will hold the ID of where the image file is saved in LiteDB
        public IList<string> PictureList;

        protected override double GetCorrectness(int userAnswer)
        {
            return userAnswer.Equals(CorrectPictureIndex) ? 1 : 0;
        }
    }
}