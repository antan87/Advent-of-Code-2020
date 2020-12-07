using System.Collections.Generic;
using AdventOfCode2020.Calender.Policy.Interface;

namespace AdventOfCode2020.Calender.Policy.Models
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