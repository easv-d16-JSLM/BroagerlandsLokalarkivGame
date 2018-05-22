using System.Collections.Generic;

namespace BLAG.Common.Models
{
    public class AnswerPicture : AnswerBase<int>
    {
        // String will hold the ID of where the image file is saved in LiteDB
        public IList<string> PictureList;
        public int CorrectPictureIndex;

        protected override double GetCorrectness(int userAnswer)
        {
            return userAnswer.Equals(CorrectPictureIndex) ? 1 : 0;
        }
    }
}
