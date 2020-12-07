using AdventOfCode2020.Calender.Policy.Interface;

namespace AdventOfCode2020.Calender.Policy.Models
{
    public class PolicySet : IPolicySet
    {
        public PolicySet(IPolicy policy, ICondition condition, string password)
        {
            Policy = policy;
            Condition = condition;
            Password = password;
        }

        public IPolicy Policy { get; }

        public ICondition Condition { get; }
        public string Password { get; }
    }
}