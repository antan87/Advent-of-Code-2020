using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AdventOfCode2020.Parsers.Interface;

namespace AdventOfCode2020.Common
{
    public static class DataHelper
    {
        public async static Task<T[]> GetInput<T>(string separator, string resourceNamePath, IParser<T> parser)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceNamePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = await reader.ReadToEndAsync();
                return result.Split(separator).Select(number => parser.Parse(number)).ToArray();
            }
        }

        public async static Task<List<string>> GetStringsTestDataAsync(string resourceNamePath)
        {
            List<string> values = new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceNamePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                string nextLine = await reader.ReadLineAsync();
                while (!string.IsNullOrWhiteSpace(nextLine))
                {
                    values.Add(nextLine);
                    nextLine = await reader.ReadLineAsync();
                }

                return values;
            }
        }
    }
}