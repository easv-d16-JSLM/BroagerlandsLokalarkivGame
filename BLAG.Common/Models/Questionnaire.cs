using System.Collections.Generic;
using BLAG.Common.Models.Question;

namespace BLAG.Common.Models
{
    public class Questionnaire : ModelBase
    {
        public IList<QuestionBase> Questions { get; set; }
    }
}