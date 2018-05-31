using System;

namespace BLAG.Common.Models
{
    public class Player : ModelBase, IComparable<Player>
    {
        public GameSession GameSession { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }

        public int CompareTo(Player other)
        {
            return Score.CompareTo(other.Score);
        }
    }
}