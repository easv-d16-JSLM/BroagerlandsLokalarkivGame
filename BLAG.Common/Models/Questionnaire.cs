using System.Collections.Generic;

namespace BLAG.Common.Models
{
    public class Questionnaire : ModelBase
    {
        public IList<QuestionBase> Questions { get; set; }
    }
}
