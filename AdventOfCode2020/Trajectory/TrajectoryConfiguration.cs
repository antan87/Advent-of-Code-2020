using System.Collections.Generic;
using AdventOfCode2020.Trajectory.Interfaces;

namespace AdventOfCode2020.Trajectory
{
    public record TrajectoryConfiguration
    {
        public TrajectoryConfiguration(IManager? manager, List<IVector>? vectors, IVector? startingPosition)
        {
            Manager = manager;
            Vectors = vectors;
            StartingPosition = startingPosition;
        }

        public List<IVector>? Vectors { get; init; }
        public IVector? StartingPosition { get; }
        public IManager? Manager { get; init; }
    }
}