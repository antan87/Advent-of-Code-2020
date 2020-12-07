using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Parser.Parsers.Interface;

namespace Parser.Parsers
{
    public static class ParseHelper
    {
        public async static Task<T[]> GetInput<T>(string separator, string resourceNamePath, IParser<T> parser, StringSplitOptions stringSplitOptions = StringSplitOptions.None)
        {
            string assembly = resourceNamePath.Split('.')[0];
            using (Stream? stream = Assembly.LoadFrom(assembly).GetManifestResourceStream(resourceNamePath))
            using (StreamReader reader = new StreamReader(stream!))
            {
                string result = await reader.ReadToEndAsync();
                return Parse(new string[] { separator }, parser, result, stringSplitOptions);
            }
        }

        public async static Task<T[]> GetInput<T>(string[]seperators , string resourceNamePath, IParser<T> parser, StringSplitOptions stringSplitOptions = StringSplitOptions.None)
        {
            string assembly = resourceNamePath.Split('.')[0];
            using (Stream? stream = Assembly.LoadFrom(assembly).GetManifestResourceStream(resourceNamePath))
            using (StreamReader reader = new StreamReader(stream!))
            {
                string result = await reader.ReadToEndAsync();
                return Parse(seperators, parser, result, stringSplitOptions);
            }
        }

        private static T[] Parse<T>(string[] separators, IParser<T> parser, string? input, StringSplitOptions stringSplitOptions = StringSplitOptions.None)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new T[0];

            return input.Split(separators, stringSplitOptions).Select(number => parser.Parse(number)).ToArray();
        }

        private static T[] Parse<T>(IParser2D<T> parser, string? input, int y)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Array.Empty<T>();

            return parser.Parse(y, input);
        }

        public async static Task<IEnumerable<T>> GetInput<T>(string resourceNamePath, IParser2D<T> parser)
        {
            List<string> inputRows = new List<string>();

            string assembly = resourceNamePath.Split('.')[0];
            using (Stream? stream = Assembly.LoadFrom(assembly).GetManifestResourceStream(resourceNamePath))
            using (StreamReader reader = new StreamReader(stream!))
            {
                string? nextLine = await reader.ReadLineAsync();
                if (!string.IsNullOrWhiteSpace(nextLine))
                    inputRows.Add(nextLine);

                while (!string.IsNullOrWhiteSpace(nextLine))
                {
                    nextLine = await reader.ReadLineAsync();
                    if (!string.IsNullOrWhiteSpace(nextLine))
                        inputRows.Add(nextLine);
                }
            }

            inputRows.Reverse();

            return inputRows.Select((input, y) => parser.Parse(y, input)).SelectMany(item => item);
        }

        private static T[,] CreateRectangularArray<T>(IList<T[]> arrays)
        {
            int minorLength = arrays[0].Length;
            T[,] ret = new T[arrays.Count, minorLength];
            for (int i = 0; i < arrays.Count; i++)
            {
                var array = arrays[i];
                if (array.Length != minorLength)
                {
                    throw new ArgumentException
                        ("All arrays must be the same length");
                }
                for (int j = 0; j < minorLength; j++)
                    ret[i, j] = array[j];
            }

            return ret;
        }
    }
}