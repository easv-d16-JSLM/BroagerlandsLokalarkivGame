using System;
using System.Diagnostics;
using BLAG.Common.Models.Answer;
using FluentAssertions;
using Geolocation;
using Xunit;
using Xunit.Abstractions;

namespace BLAG.Common.Tests
{
    public class AnswerMapTests
    {
        public AnswerMapTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private readonly ITestOutputHelper _output;

        [Theory]
        [InlineData(54.88791970422942, 9.674760891571054)]
        [InlineData(54.887031072205346, 9.69299658018599)]
        public void AnswerInaccurate(double latitude, double longtitude)
        {
            var answer = new AnswerMap
            {
                Location = new Coordinate {Latitude = 54.890351, Longitude = 9.66989000000001},
                Precision = 100
            };
            var cord = new Coordinate {Latitude = latitude, Longitude = longtitude};

            var result = answer.CalculateScore(cord, 100, new TimeSpan(0, 0, 10), new TimeSpan(0, 0, 0));

            Trace.WriteLine("Hello World");

            result.Should().BeLessThan(100, "because the location is not accurate enough");

            _output.WriteLine("Points Gained: " + result);
            _output.WriteLine("Correct answer should be within: " + answer.Precision + "Meters");
        }

        [Fact]
        public void AnswerIsTheSame()
        {
            var answer = new AnswerMap
            {
                Location = new Coordinate {Latitude = 54.890351, Longitude = 9.66989000000001},
                Precision = 100
            };
            var cord = answer.Location;

            var result = answer.CalculateScore(cord, 100, new TimeSpan(0, 0, 10), new TimeSpan(0, 0, 0));

            result.Should().Be(100, "Because coordinates is the same");

            _output.WriteLine("Points Gained: " + result);
            _output.WriteLine("Answer should be within: " + answer.Precision + "Meters");
        }
    }
}