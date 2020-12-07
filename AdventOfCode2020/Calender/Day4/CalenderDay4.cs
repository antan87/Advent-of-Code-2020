using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.Core.Interfaces;
using AdventOfCode2020.Core.Models;
using AdventOfCode2020.Passport;
using AdventOfCode2020.Passport.Interfaces;
using AdventOfCode2020.Passport.Models.Attributes;
using AdventOfCode2020.Passport.Models.Rules;
using Parser.Parsers;

namespace AdventOfCode2020.Calender.Day4
{
    public class CalenderDay4 : ICalenderDay
    {
        public string GetName() => "Day 4: Passport Processing";

        public async Task<IEnumerable<IResultTask>> GetResults()
        {
            var result = await GetFirstTask();
            return new List<IResultTask> {
                result
            };
        }

        private async Task<StringResultTask> GetFirstTask()
        {
            string filePath = @"AdventOfCode2020.Calender.Day4.Input.txt";
            var passports = await ParseHelper.GetInput(new string[] { "\r\n\r\n" }, filePath, new PassportParser(), StringSplitOptions.RemoveEmptyEntries);

            var rules = new List<IPassportRule>
            {
                new RequiredPassportAttribute<BirthYearAttribute>(),
                new RequiredPassportAttribute<ExpirationYearAttribute>(),
                new RequiredPassportAttribute<EyeColorAttribute>(),
                new RequiredPassportAttribute<HairColorAttribute>(),
                new RequiredPassportAttribute<HeightAttribute>(),
                new RequiredPassportAttribute<IssueYearAttribute>(),
                new RequiredPassportAttribute<PassportIDAttribute>(),
            };

            var count = passports.Count(passport => PasswordValidator.Validate(passport, rules));

            return new StringResultTask("Part 1", $"Answer: {count}");
        }
    }
}