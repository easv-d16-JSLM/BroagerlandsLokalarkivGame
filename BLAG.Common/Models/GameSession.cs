using System;
using System.Collections.Generic;

namespace BLAG.Common.Models
{
    public class GameSession
    {
        public Questionnaire Questionnaire { get; set; }
        public DateTime StartTime { get; set; }

        public void StartGame()
        {
        }

        public IList<Player> GetLeaderboard()
        {
            return null;
        }
    }
}