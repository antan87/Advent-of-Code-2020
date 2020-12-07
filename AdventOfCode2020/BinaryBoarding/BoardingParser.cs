using System;
using System.Linq;
using AdventOfCode2020.BinaryBoarding.Enums;
using Parser.Parsers.Interface;

namespace AdventOfCode2020.BinaryBoarding
{
    public class BoardingParser : IParser<BoardingCommandKind[]>
    {
        public BoardingCommandKind[] Parse(string value)
        {
            return value.Select(letter => GetCommandKind(letter)).ToArray();
        }

        private BoardingCommandKind GetCommandKind(char letter)
        {
            switch (letter)
            {
                case 'F':
                    return BoardingCommandKind.Front;

                case 'B':
                    return BoardingCommandKind.Back;

                case 'L':
                    return BoardingCommandKind.Left;

                case 'R':
                    return BoardingCommandKind.Right;

                default:
                    throw new NotImplementedException($"Not implemented parsing of letter {letter}");
            }
        }
    }
}