using System.Collections.Generic;
using AdventOfCode2020.Calender.Day2.Policy.Interface;
using AdventOfCode2020.Calender.Day2.Policy.Models;
using AdventOfCode2020.Parsers.Interface;

namespace AdventOfCode2020.Calender.Day2.Policy
{
    public class PolicyParser<TPolicy> : IParser<PolicySet>
    where TPolicy : IPolicy
    {
        public PolicySet Parse(string value)
        {
            string[] parts = value.Split(":");
            string password = parts[1];

            var policy = GetPolicy(parts[0]);
            var condition = GetCondition(parts[0]);

            return new PolicySet(policy, condition, password);
        }

        private IPolicy GetPolicy(string input)
        {
            var policyString = input.Split(' ');

            var numbers = policyString[0].Split("-");

            var min = Parsers.Parsers.Int32Parser.Parse(numbers[0]);
            var max = Parsers.Parsers.Int32Parser.Parse(numbers[1]);

            return CreatePolicy(min, max);
        }

        private ICondition GetCondition(string input)
        {
            var policyString = input.Split(' ');

            return new LetterCondition(policyString[1].ToCharArray()[0]);
        }

        private TPolicy CreatePolicy(int number, int number2)
        {
            switch (typeof(TPolicy))
            {
                case var cls when cls == typeof(OccurrencePolicy):
                    return (TPolicy)(IPolicy)new OccurrencePolicy(number, number2);

                case var cls when cls == typeof(PositionPolicy):
                    return (TPolicy)(IPolicy)new PositionPolicy(new List<int> { number, number2 });

                default:
                    return default(TPolicy);
            }
        }
    }
}