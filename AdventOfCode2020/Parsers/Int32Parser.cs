using AdventOfCode2020.Parsers.Interface;

namespace AdventOfCode2020.Parsers
{
    public  class Int32Parser : IParser<int>
    {
        public int Parse(string value) => int.Parse(value);
    }
}