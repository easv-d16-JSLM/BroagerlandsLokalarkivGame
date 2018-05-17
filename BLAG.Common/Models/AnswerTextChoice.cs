using System;
using System.Collections.Generic;
using System.Text;

namespace BLAG.Common.Models
{
    class AnswerTextChoice : AnswerBase
    {
        public IList<String> TextChoices;
        public String CorrectChoice; 
    }
}
