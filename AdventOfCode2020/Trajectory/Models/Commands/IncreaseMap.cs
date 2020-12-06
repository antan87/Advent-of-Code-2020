using System.Collections.Generic;
using AdventOfCode2020.Trajectory.Interfaces;

namespace AdventOfCode2020.Trajectory.Models.Commands
{
    public record IncreaseMap : ICommand
    {
        public IncreaseMap(IEnumerable<IVector> newNectors)
        {
            NewNectors = newNectors;
        }

        public IEnumerable<IVector> NewNectors { get; }
    }
}