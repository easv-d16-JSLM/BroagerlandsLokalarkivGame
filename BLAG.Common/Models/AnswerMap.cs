﻿using System;
using System.Collections.Generic;
using System.Text;
using Geolocation;

namespace BLAG.Common.Models
{
    public class AnswerMap : AnswerBase<Coordinate>
    {
        public Coordinate Location;
        public int Precision;

        protected override double GetCorrectness(Coordinate userAnswer)
        { 
            var distance = Geolocation.GeoCalculator.GetDistance(Location, userAnswer, 1, DistanceUnit.Meters);

            return Math.Min(Precision / distance,1);
        }
    }
}
