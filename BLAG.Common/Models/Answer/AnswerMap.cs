using System;
using Geolocation;

namespace BLAG.Common.Models.Answer
{
    public class AnswerMap : AnswerBase<Coordinate>
    {
        public Coordinate Location { get; set; }
        public int Precision { get; set; }

        protected override double GetCorrectness(Coordinate userAnswer)
        {
            var distance = GeoCalculator.GetDistance(Location, userAnswer, 1, DistanceUnit.Meters);

            return Math.Min(Precision / distance, 1);
        }
    }
}