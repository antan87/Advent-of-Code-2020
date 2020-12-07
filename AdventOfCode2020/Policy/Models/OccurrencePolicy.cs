using AdventOfCode2020.Calender.Policy.Interface;

namespace AdventOfCode2020.Calender.Policy.Models
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