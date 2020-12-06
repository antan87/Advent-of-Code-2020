using System.Collections.Generic;
using AdventOfCode2020.Trajectory.Interfaces;

namespace AdventOfCode2020.Trajectory.Models
{
    public record Map : IMap
    {
        public List<IVector>? Vectors { get; init; }
        public IVector? CurrentPosition { get; init; }
    }
}