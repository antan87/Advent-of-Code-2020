namespace AdventOfCode2020.Calender.Policy.Interface
{
    public interface IPolicySet
    {
        public IPolicy Policy { get; }

        public ICondition Condition { get; }
        public string Password { get; }
    }
}