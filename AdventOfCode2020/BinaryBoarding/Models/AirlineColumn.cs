using AdventOfCode2020.BinaryBoarding.Interfaces;

namespace AdventOfCode2020.BinaryBoarding.Models
{
    public record AirlineColumn : IAirlinePoint
    {
        public AirlineColumn(int column)
        {
            Column = column;
        }

        public int Column { get; }

        public int GetNumber() => Column;
    }
}