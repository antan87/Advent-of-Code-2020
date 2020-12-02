using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventOfCode2020.Core.Interfaces
{
    public interface ICalenderDay
    {
        Task<IEnumerable<IResultTask>> GetResults();

        string GetName();
    }
}