using System;
using System.Collections.Generic;
using System.Text;

namespace BLAG.Common.Models
{
    public class Questionnaire : ModelBase
    {
        public IList<QuestionBase> Questions { get; set; }
    }
}
