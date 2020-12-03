using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.Common;
using AdventOfCode2020.Core.Interfaces;
using AdventOfCode2020.Core.Models;

namespace AdventOfCode2020.Calender.Day1
{
    public class CalenderDay1 : ICalenderDay
    {
        public string GetName() => "Day 1: Report Repair";

        public async Task<IEnumerable<IResultTask>> GetResults()
        {
            var result = await GetFirstTask();
            var result2 = await GetSecondTask();
            return new List<IResultTask> { result, result2 };
        }

        private async Task<StringResultTask> GetFirstTask()
        {
            string filePath = @"AdventOfCode2020.Calender.Day1.Input.txt";
            int[] numbers = await DataHelper.GetInput(Environment.NewLine, filePath, Parsers.Parsers.Int32Parser);

            var number = Operation(numbers, 2020, 2);

            var result = new StringResultTask("Part One", $"Answer: {number}");

            return result;
        }

        private async Task<StringResultTask> GetSecondTask()
        {
            string filePath = @"AdventOfCode2020.Calender.Day1.Input.txt";
            int[] numbers = await DataHelper.GetInput(Environment.NewLine, filePath, Parsers.Parsers.Int32Parser);

            var number = Operation(numbers, 2020, 3);

            var result = new StringResultTask("Part Two", $"Answer: {number}");

            return result;
        }

        public static int Operation(int[] elements, int sumNumber, int iterations)
        {
            for (int pointer = 0; pointer < elements.Length; pointer++)
            {
                var number = ComposeNumbers(elements, iterations - 1, pointer, sumNumber, sumNumber);
                if (number.HasValue)
                    return number.Value;
            }

            return 0;
        }

        private static int? ComposeNumbers(int[] elements, int iteration, int index, int remaningAmount, int sumToReach)
        {
            if (index == elements.Length)
                return null;

            int currentNumber = elements[index];
            int temRemaningAmount = remaningAmount - currentNumber;
            if (temRemaningAmount < 0)
                return null;

            if (iteration - 1 == 0)
            {
                (int item, int index) foundNumber = elements.Select((item, index) => (item, index)).FirstOrDefault(item => item.index > index && item.item == temRemaningAmount);
                if (foundNumber.item != 0)
                    return currentNumber * foundNumber.item;

                return null;
            }

            for (int pointer = index + 1; pointer < elements.Length; pointer++)
            {
                var number = ComposeNumbers(elements, iteration - 1, pointer, temRemaningAmount, sumToReach);
                if (number.HasValue)
                    return number * currentNumber;
            }

            return null;
        }
    }
}