using BLAG.Common.Models.Answer;

namespace BLAG.Common.Models
{
    public class PlayerAsnwer<T> : ModelBase
    {
        public Player Player;
        public AnswerBase<T> Answer { get; set; }
        public T PlayerAnswer { get; set; }
    }
}