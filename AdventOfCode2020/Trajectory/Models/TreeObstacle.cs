using AdventOfCode2020.Trajectory.Interfaces;
using AdventOfCode2020.Trajectory.Structs.Interfaces;

namespace AdventOfCode2020.Trajectory.Models
{
    public record TreeObstacle : IObstacle, IVector
    {
        public TreeObstacle(IPoint point)
        {
            this.Point = point;
        }

        public IPoint Point { get; }
    }
}