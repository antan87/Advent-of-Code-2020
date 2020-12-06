
using Parser.Parsers.Interface;

namespace Parser.Parsers
{
    public class StringParser : IParser<string>
    {
        public string Parse(string value) => value;
    }
}