using Parser.Parsers.Interface;

namespace Parser.Parsers
{
    public class Int32Parser : IParser<int>
    {
        public int Parse(string value) => int.Parse(value);
    }
}