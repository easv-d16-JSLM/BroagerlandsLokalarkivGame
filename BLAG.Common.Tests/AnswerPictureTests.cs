using System;
using System.Collections.Generic;
using System.Text;
using BLAG.Common.Models;
using FluentAssertions;
using Xunit;

namespace BLAG.Common.Tests
{
    public class AnswerPictureTests
    {
        [Theory]
        [InlineData(1, 1, 100)]
        [InlineData(2, 2, 100)]
        [InlineData(1, 2, 0)]
        [InlineData(2, 3, 0)]
        public void CheckAnswer(int userAnswer, int correctValue, int points)
        {
            var answer = new AnswerPicture() { CorrectPictureIndex = correctValue};

            var result = answer.CalculateScore(userAnswer, points, new TimeSpan(0, 0, 10), new TimeSpan(0, 0, 0));

            result.Should().Be(points, "because of the answer giving is either correct or incorrect");
        }
    }
}
