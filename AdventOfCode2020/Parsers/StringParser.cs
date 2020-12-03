using AdventOfCode2020.Parsers.Interface;

namespace AdventOfCode2020.Parsers
{
    public class StringParser : IParser<string>
    {
        public string Parse(string value) => value;
    }
}