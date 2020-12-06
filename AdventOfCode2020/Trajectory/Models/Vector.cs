using AdventOfCode2020.Trajectory.Interfaces;
using AdventOfCode2020.Trajectory.Structs.Interfaces;

namespace AdventOfCode2020.Trajectory.Models
{
    public record Vector : IVector
    {
        public Vector(IPoint point)
        {
            Point = point;
        }

        public IPoint Point { get; }
    }
}