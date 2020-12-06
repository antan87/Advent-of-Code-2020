using AdventOfCode2020.Trajectory.Structs.Interfaces;

namespace AdventOfCode2020.Trajectory.Structs
{
    public readonly struct Point2D : IPoint
    {
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
}