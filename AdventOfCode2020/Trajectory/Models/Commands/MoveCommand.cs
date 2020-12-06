using AdventOfCode2020.Trajectory.Interfaces;
using AdventOfCode2020.Trajectory.Structs.Interfaces;

namespace AdventOfCode2020.Trajectory.Models.Commands
{
    public record MoveCommand : ICommand
    {
        public MoveCommand(IPoint point)
        {
            Point = point;
        }

        public IPoint Point { get; }
    }
}