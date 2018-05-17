using System;
using BLAG.Common.Models;
using FluentAssertions;
using Xunit;

namespace BLAG.Common.Tests
{
    public class ScoreCalculatorTests
    {
        [Fact]
        public void AnswerInstantly()
        {
            //Arrange
            var calc = new ScoreCalculator();
            var time = TimeSpan.FromSeconds(0);
            var q = new QuestionText(){Points = 100,Time = TimeSpan.FromSeconds(10)};
            //Act
            var result = calc.Score(q, time);
            //Assert
            result.Should().Be(100, "because instantly answered question must reward full points");
        }
    }
}
