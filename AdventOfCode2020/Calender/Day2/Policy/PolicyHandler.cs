using System.Linq;
using AdventOfCode2020.Calender.Day2.Policy.Interface;
using AdventOfCode2020.Calender.Day2.Policy.Models;

namespace AdventOfCode2020.Calender.Day2.Policy
{
    public static class PolicyHandler
    {
        public static bool EvaluatePassword(IPolicySet policy)
        {
            return CheckPolicy(policy);
        }

        private static bool CheckPolicy(IPolicySet set)
        {
            switch (set.Policy)
            {
                case OccurrencePolicy policy when set.Condition is LetterCondition:
                    {
                        var letterCondition = (set.Condition as LetterCondition).Letter;

                        var occurrences = set.Password.Count(letter => letter == letterCondition);

                        return policy.Min <= occurrences && occurrences <= policy.Max;
                    }

                case PositionPolicy policy when set.Condition is LetterCondition:
                    {
                        char letterCondition = (set.Condition as LetterCondition).Letter;
                        var letterPositions = set.Password.Select((letter, index) => (letter, index: index )).Where(item => item.letter == letterCondition).ToList();

                        return letterPositions.Count(item => policy.Positions.Contains(item.index)) == 1;
                    }
                default:
                    return false;
            }
        }
    }
}