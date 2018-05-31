namespace BLAG.Common.Models
{
    public class PlayerAsnwer<T> : ModelBase
    {
        public Player Player;
        public Answer Answer { get; set; }
        public T PlayerAnswer { get; set; }
    }
}