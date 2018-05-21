using System;

namespace BLAG.Common.Models
{
    public class QuestionImage : QuestionBase
    {
        // String will hold the ID of where the image file is saved in LiteDB
        public String Image { get; set; }
    }
}
