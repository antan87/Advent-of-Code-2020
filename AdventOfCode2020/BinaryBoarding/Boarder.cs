using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.BinaryBoarding.Enums;
using AdventOfCode2020.BinaryBoarding.Interfaces;
using AdventOfCode2020.BinaryBoarding.Models;

namespace AdventOfCode2020.BinaryBoarding
{
    public static class Boarder
    {
        public static AirlineSeat Boarding(BoardingCommandKind[] commands, int countRows, int countColumns)
        {
            List<AirlineRow> rows = new List<AirlineRow>();
            for (int index = 0; index < countRows; index++)
                rows.Add(new AirlineRow(index));

            foreach (var command in commands.Where(kind => kind == BoardingCommandKind.Back || kind == BoardingCommandKind.Front))
                rows = ParseLine<AirlineRow>(command, rows);

            List<AirlineColumn> columns = new List<AirlineColumn>();
            for (int index = 0; index < countColumns; index++)
                columns.Add(new AirlineColumn(index));

            foreach (var command in commands.Where(kind => kind == BoardingCommandKind.Left || kind == BoardingCommandKind.Right))
                columns = ParseLine(command, columns);

            var row = rows.First();
            var column = columns.First();

            return new AirlineSeat(row.Row, column.Column);
        }

        private static List<T> ParseLine<T>(BoardingCommandKind command, IEnumerable<T> lines)
        where T : IAirlinePoint
        {
            var items = lines.Count() / 2;
            switch (command)
            {
                case BoardingCommandKind.Left:
                case BoardingCommandKind.Front:
                    return lines.Take(items).ToList();

                case BoardingCommandKind.Right:
                case BoardingCommandKind.Back:
                    return lines.Skip(items).Take(items).ToList();

                default:
                    throw new NotImplementedException("Not implemented");
            }
        }
    }
}