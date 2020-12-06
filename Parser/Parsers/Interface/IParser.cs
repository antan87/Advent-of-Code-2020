namespace Parser.Parsers.Interface
{
    public interface IParser<T>
    {
        T Parse(string value);
    }
}