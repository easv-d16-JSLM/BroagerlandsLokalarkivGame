using System;
using System.Collections.Generic;
using System.Text;
using BLAG.Common.Models;
using BLAG.Common.Models.Answer;
using FluentAssertions;
using Xunit;

namespace BLAG.Common.Tests
{
    public class AnswerTextChoiceTests
    {
        [Theory]
        [InlineData("Affirmative", "Affirmative", 100)]
        [InlineData("Negatory", "Negatory", 100)]
        [InlineData("Affirmative", "Negatory", 0)]
        [InlineData("Negatory", "Affirmative", 0)]
        public void CheckAnswer(string userAnswer, string correctValue, int points)
        {
            var answer = new AnswerTextChoice() { CorrectChoice = correctValue };

            var result = answer.CalculateScore(userAnswer, points, new TimeSpan(0, 0, 10), new TimeSpan(0, 0, 0));

            result.Should().Be(points, "because of the answer giving is either correct or incorrect");
        }
    }
}
