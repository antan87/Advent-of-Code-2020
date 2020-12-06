using System.Collections.Generic;

namespace AdventOfCode2020.Trajectory.Interfaces
{
    public interface IMap
    {
        public List<IVector>? Vectors { get;  }
        public IVector? CurrentPosition { get; }
    }
}