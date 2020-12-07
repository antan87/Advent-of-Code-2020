namespace AdventOfCode2020.BinaryBoarding.Models
{
    public record AirlineSeat
    {
        public AirlineSeat(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }
        public int Column { get; }

        public int Id => this.Row * 8 + this.Column;
    }
}