using AdventOfCode2020.Core.Interfaces;

namespace AdventOfCode2020.Core.Models
{
    internal class StringResultTask : IResultTask
    {
        public StringResultTask(string description, string result)
        {
            this.Result = result;
            this.Description = description;
        }

        public string Result { get; }

        public string Description { get; }
    }
}