using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.BinaryBoarding;
using AdventOfCode2020.BinaryBoarding.Models;
using AdventOfCode2020.Core.Interfaces;
using AdventOfCode2020.Core.Models;
using Parser.Parsers;

namespace AdventOfCode2020.Calender.Day5
{
    public class CalenderDay5 : ICalenderDay
    {
        public string GetName() => "Day 5: Binary Boarding";

        public async Task<IEnumerable<IResultTask>> GetResults()
        {
            var result = await GetFirstTask();
            var result2 = await GetSecondTask();
            return new List<IResultTask>
            {
                result,
                result2
            };
        }

        private async Task<StringResultTask> GetFirstTask()
        {
            string filePath = @"AdventOfCode2020.Calender.Day5.Input.txt";
            var input = await ParseHelper.GetInput(Environment.NewLine, filePath, new BoardingParser());

            var seat = input.Select(commands => Boarder.Boarding(commands, 128, 8)).Max(seat => seat.Id);

            return new StringResultTask("Part 1", $"Answer: {seat}");
        }

        private async Task<StringResultTask> GetSecondTask()
        {
            string filePath = @"AdventOfCode2020.Calender.Day5.Input.txt";
            var input = await ParseHelper.GetInput(Environment.NewLine, filePath, new BoardingParser());

            var seats = input.Select(commands => Boarder.Boarding(commands, 128, 8));

            var missingSeats = new List<AirlineSeat>();
            for (int indexRow = 0; indexRow < 128; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < 8; indexColumn++)
                {
                    var result = seats.FirstOrDefault(seat => seat.Row == indexRow && seat.Column == indexColumn);
                    if (result == null)
                        missingSeats.Add(new AirlineSeat(indexRow, indexColumn));
                }
            }

            return new StringResultTask("Part 2", $"Answer: {seats.Count()}");
        }
    }
}