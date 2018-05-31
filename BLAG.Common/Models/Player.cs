namespace BLAG.Common.Models
{
    public class Player : ModelBase
    {
        public GameSession GameSession { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }
    }
}