namespace AdventOfCode2020.Parsers.Interface
{
    internal interface IParser<T>
    {
        T Parse(string value);
    }
}