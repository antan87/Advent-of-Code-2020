namespace AdventOfCode2020.Calender.Day2.Policy.Interface
{
    public interface IPolicySet
    {
        public IPolicy Policy { get; }

        public ICondition Condition { get; }
        public string Password { get; }
    }
}