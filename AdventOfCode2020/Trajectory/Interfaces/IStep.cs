namespace AdventOfCode2020.Trajectory.Interfaces
{
    public interface IStep
    {
        ICommand Command { get; }
        IVector Vector { get; }
    }
}