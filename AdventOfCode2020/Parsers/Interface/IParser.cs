namespace AdventOfCode2020.Parsers.Interface
{
    public interface IParser<T>
    {
        T Parse(string value);
    }
}