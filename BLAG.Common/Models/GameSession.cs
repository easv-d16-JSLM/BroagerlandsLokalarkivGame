using System;

namespace BLAG.Common.Models
{
    public class GameSession : ModelBase
    {
        public GameSession()
        {
            JoinCode = GenerateJoinCode();
        }

        public int CurrentQuestionIndex { get; set; }

        public string JoinCode { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public DateTime StartTime { get; set; }

        private string GenerateJoinCode()
        {
            var joinCode = "";
            var r = new Random();
            for (var i = 0; i < 5; i++)
            {
                var c = (char) (r.Next(26) + 'a');
                joinCode += c;
            }
            return joinCode;
        }
    }
}