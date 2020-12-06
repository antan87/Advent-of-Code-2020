using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.Calender.Day2.Policy;
using AdventOfCode2020.Calender.Day2.Policy.Models;
using AdventOfCode2020.Core.Interfaces;
using AdventOfCode2020.Core.Models;
using Parser.Parsers;

namespace AdventOfCode2020.Calender.Day2
{
    public class CalenderDay2 : ICalenderDay
    {
        public string GetName() => "Day 2: Password Philosophy";

        public async Task<IEnumerable<IResultTask>> GetResults()
        {
            var result = await GetFirstTask();
            var result2 = await GetSecondTask();
            return new List<IResultTask> { result, result2 };
        }

        private async Task<StringResultTask> GetFirstTask()
        {
            string filePath = @"AdventOfCode2020.Calender.Day2.Input.txt";
            PolicySet[] policies = await ParseHelper.GetInput<PolicySet>(Environment.NewLine, filePath, new PolicyParser<OccurrencePolicy>());

            var count = policies.Count(policy => PolicyHandler.EvaluatePassword(policy));

            return new StringResultTask("Part 1", $"Answer: {count}");
        }

        private async Task<StringResultTask> GetSecondTask()
        {
            string filePath = @"AdventOfCode2020.Calender.Day2.Input.txt";
            PolicySet[] policies = await ParseHelper.GetInput<PolicySet>(Environment.NewLine, filePath, new PolicyParser<PositionPolicy>());

            var count = policies.Count(policy => PolicyHandler.EvaluatePassword(policy));

            return new StringResultTask("Part 1", $"Answer: {count}");
        }
    }
}