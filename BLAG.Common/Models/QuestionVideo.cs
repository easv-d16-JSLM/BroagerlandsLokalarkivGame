using System;

namespace BLAG.Common.Models
{
    public class QuestionVideo : QuestionBase
    {
        // String will hold the ID of where the video file is saved in LiteDB
        public String Video { get; set; }
    }
}
