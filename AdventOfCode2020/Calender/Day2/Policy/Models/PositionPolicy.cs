using System.Collections.Generic;
using AdventOfCode2020.Calender.Day2.Policy.Interface;

namespace AdventOfCode2020.Calender.Day2.Policy.Models
{
    public class PositionPolicy : IPolicy
    {
        public PositionPolicy(List<int> positions)
        {
            Positions = positions;
        }

        public List<int> Positions { get; }
    }
}