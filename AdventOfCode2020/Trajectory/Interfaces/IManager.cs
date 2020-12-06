using System.Collections.Generic;

namespace AdventOfCode2020.Trajectory.Interfaces
{
    public interface IManager
    {
        ICommand? GetNextCommand(IMap map, IEnumerable<IStep> steps);
    }
}