using System.Collections.Generic;
using BLAG.Common.Models;

namespace BLAG.Common.Models
{
    public class Questionnaire : ModelBase
    {
        public IList<Question> Questions { get; set; }
    }
}