using System;
using System.Linq;
using AdventOfCode2020.Trajectory.Interfaces;
using AdventOfCode2020.Trajectory.Models;
using AdventOfCode2020.Trajectory.Structs;
using AdventOfCode2020.Trajectory.Structs.Interfaces;
using Parser.Parsers.Interface;

namespace AdventOfCode2020.Calender.Day3
{
    public class Day3TobogganParser : IParser2D<IVector>
    {
        public IVector[] Parse(int y, string value)
        {
            return value.Select((charachter, x) => GetVector(charachter, new Point2D(x, y))).ToArray();
        }

        private IVector GetVector(char charachter, IPoint point)
        {
            switch (charachter)
            {
                case '.':
                    return new Vector(point);

                case '#':
                    return new TreeObstacle(point);

                default:
                    throw new ArgumentException("Missing character implementation.");
            }
        }
    }
}