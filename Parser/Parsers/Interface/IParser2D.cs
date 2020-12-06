namespace Parser.Parsers.Interface
{
    public interface IParser2D<T>
    {
        T[] Parse(int y, string value);
    }
}