using System;
using System.Collections.Generic;
using System.Text;
using BLAG.Common.Models;
using FluentAssertions;
using Xunit;

namespace BLAG.Common.Tests
{
    public class AnswerNumberTests
    {
        [Theory]
        [InlineData(1978, 1978, 100)]
        [InlineData(2001, 2001, 100)]
        [InlineData(1978, 1990, 0)]
        [InlineData(1978, 2000, 0)]
        public void CheckAnswer(int userAnswer, int correctValue, int points)
        {
            var answer = new AnswerNumber(){CorrectValue = correctValue};

            var result = answer.CalculateScore(userAnswer, points, new TimeSpan(0, 0, 10), new TimeSpan(0, 0, 0));

            result.Should().Be(points, "because of the answer giving is either correct or incorrect");
        }
    }
}
