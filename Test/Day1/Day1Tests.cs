using AdventOfCode2020.Calender.Day1;
using Xunit;

namespace Test.Day1
{
    public class Day1Tests
    {
        [Theory]
        [InlineData(new int[] { 1721, 979, 366, 299, 675, 1456 }, 2020, 2, 514579)]
        [InlineData(new int[] { 1721, 979, 366, 299, 675, 1456 }, 2020, 3, 241861950)]
        public void CalenderDay1_ProductsOfSum(int[] numbers, int sum, int iterations, int expectedResult)
        {
            var result = CalenderDay1.Operation(numbers, sum, iterations);

            Assert.Equal(expectedResult, result);
        }
    }
}