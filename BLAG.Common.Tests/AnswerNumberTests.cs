using System;
using BLAG.Common.Models.Answer;
using FluentAssertions;
using Xunit;

namespace BLAG.Common.Tests
{
    public class AnswerNumberTests
    {
        [Theory]
        [InlineData(1925, 1950, 0)]
        [InlineData(1930, 1950, 0)]
        [InlineData(1935, 1950, 1)]
        [InlineData(1940, 1950, 13)]
        [InlineData(1945, 1950, 60)]
        [InlineData(1950, 1950, 100)]
        [InlineData(1955, 1950, 60)]
        [InlineData(1960, 1950, 13)]
        [InlineData(1965, 1950, 1)]
        [InlineData(1970, 1950, 0)]
        [InlineData(1975, 1950, 0)]
        public void CheckAnswer(int userAnswer, int correctValue, int points)
        {
            var answer = new AnswerNumber {CorrectValue = correctValue, Precision = 5};

            var result = answer.CalculateScore(userAnswer, 100, new TimeSpan(0, 0, 10), new TimeSpan(0, 0, 0));

            result.Should().BeApproximately(points, 1,
                "because of the precision of the answer");
        }
    }
}