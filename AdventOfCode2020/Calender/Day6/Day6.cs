using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.Core.Interfaces;
using AdventOfCode2020.Core.Models;
using AdventOfCode2020.Customs;
using AdventOfCode2020.Customs.Models;
using Parser.Parsers;

namespace AdventOfCode2020.Calender.Day6
{
    public class CalenderDay6 : ICalenderDay
    {
        public string GetName() => "Day 5: Binary Boarding";

        public async Task<IEnumerable<IResultTask>> GetResults()
        {
            var result = await GetFirstTask();
            return new List<IResultTask>
            {
                result
            };
        }

        private async Task<StringResultTask> GetFirstTask()
        {
            string filePath = @"AdventOfCode2020.Calender.Day6.Input.txt";
            var groups = await ParseHelper.GetInput(new string[] { "\r\n\r\n" }, filePath, new CustomsParser(), StringSplitOptions.RemoveEmptyEntries);

            List<int> count = new List<int>();
            foreach (var group in groups)
            {
                IEnumerable<CustomsAnswer>? answers = group.Persons.SelectMany(person => person.Answers);
                count.Add(answers.Distinct().Count());
            }

            return new StringResultTask("Part 1", $"Answer: {count.Sum()}");
        }
    }
}