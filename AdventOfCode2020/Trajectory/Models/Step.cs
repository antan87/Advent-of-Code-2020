using AdventOfCode2020.Trajectory.Interfaces;

namespace AdventOfCode2020.Trajectory.Models
{
    public record Step : IStep
    {
        public Step(ICommand command, IVector vector)
        {
            this.Command = command;
            this.Vector = vector;
        }

        public ICommand Command { get; }
        public IVector Vector { get;  }
    }
}