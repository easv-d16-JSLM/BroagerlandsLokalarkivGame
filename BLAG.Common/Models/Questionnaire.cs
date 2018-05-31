using System.Collections.Generic;

namespace BLAG.Common.Models
{
    public class Questionnaire : ModelBase
    {
        public string Title;
        public IList<Question> Questions { get; set; }
    }
}