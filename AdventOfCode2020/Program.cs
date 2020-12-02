using System.Threading.Tasks;

namespace AdventOfCode2020
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            await new CalenderController().OpenCalender();
        }
    }
}