using AdventOfCode2020.BinaryBoarding.Interfaces;

namespace AdventOfCode2020.BinaryBoarding.Models
{
    public record AirlineRow : IAirlinePoint
    {
        public AirlineRow(int row)
        {
            Row = row;
        }

        public int Row { get; }

        public int GetNumber() => Row;
    }
}