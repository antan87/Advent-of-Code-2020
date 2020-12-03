using AdventOfCode2020.Calender.Day2.Policy.Interface;

namespace AdventOfCode2020.Calender.Day2.Policy.Models
{
    public class OccurrencePolicy : IPolicy
    {
        public OccurrencePolicy(int min, int max)
        {
            Max = max;
            Min = min;
        }

        public int Max { get; }
        public int Min { get; }
    }
}