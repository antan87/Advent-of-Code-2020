﻿using AdventOfCode2020.Calender.Day1;
using Xunit;

namespace Test.Day1
{
    public class Day1Tests
    {
        [Theory]
        [InlineData(new int[] { 11, 15, 3, 1, 8, 7 }, 30, 3, 840)]
        public void CalenderDay1_ProductsOfSum(int[] numbers, int sum, int iterations, int expectedResult)
        {
            var result = CalenderDay1.Operation(numbers, sum, iterations);

            Assert.Equal(expectedResult, result);
        }
    }
}