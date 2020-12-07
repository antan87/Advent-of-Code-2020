using System.Collections.Generic;
using AdventOfCode2020.BinaryBoarding;
using AdventOfCode2020.BinaryBoarding.Enums;
using Xunit;

namespace Test.Day5
{
    public class BoarderTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void Boarder_Boarding(BoardingCommandKind[] commands, int rows, int column, int expectedResult)
        {
            var result = Boarder.Boarding(commands, rows, column);

            Assert.Equal(expectedResult, result.Id);
        }

        public static IEnumerable<object[]> TestData
        {
            get
            {
                return new List<object[]>
                {
                    new object[] {
                        new BoardingCommandKind[] { BoardingCommandKind.Front,
            BoardingCommandKind.Back,
            BoardingCommandKind.Front,
            BoardingCommandKind.Back,
            BoardingCommandKind.Back,
            BoardingCommandKind.Front,
            BoardingCommandKind.Front,
            BoardingCommandKind.Right,
            BoardingCommandKind.Left,
            BoardingCommandKind.Right}, 128, 8, 357 },
                };
            }
        }
    }
}