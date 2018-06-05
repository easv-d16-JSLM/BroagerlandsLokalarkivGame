using System.Collections.Generic;

namespace BLAG.Common.Models
{
    public class Questionnaire : ModelBase
    {
        public string Title { get; set; }
        public IList<Question> Questions { get; set; }
    }
}