using System;

namespace BLAG.Common.Models
{
    public class PlayerAnswer : ModelBase
    {
        public Player Player;
        public string PlayerAnswered { get; set; }
        public TimeSpan Time { get; set; }
    }
}