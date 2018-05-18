using System;
using BLAG.Common.Models;
using FluentAssertions;
using Xunit;

namespace BLAG.Common.Tests
{
    public class ScoreCalculatorTests
    {
        [Theory]
        [InlineData(0, 100)]
        [InlineData(1, 100)]
        [InlineData(5, 100)]
        [InlineData(10, 95)]
        [InlineData(15, 90)]
        [InlineData(20, 85)]
        [InlineData(22, 83)]
        [InlineData(23, 82)]
        [InlineData(24, 81)]
        [InlineData(25, 80)]
        [InlineData(50, 55)]
        public void PointCalculate(int seconds, int points)
        {
            //Arrange
            var calc = new ScoreCalculator();
            var time = TimeSpan.FromSeconds(seconds);
            var q = new QuestionText() {Points = 100, Time = TimeSpan.FromSeconds(50)};
            //Act
            var result = calc.Score(q, time);
            //Assert
            result.Should().Be(points, "because question points should scale with time");
        }
    }
}
