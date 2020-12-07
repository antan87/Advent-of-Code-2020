using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventOfCode2020.Calender.Day2;
using AdventOfCode2020.Calender.Day3;
using AdventOfCode2020.Calender.Day4;
using AdventOfCode2020.Core.Interfaces;
using AdventOfCode2020.Core.Models;

namespace AdventOfCode2020
{
    public class CalenderController
    {
        public async Task OpenCalender()
        {
            List<ICalenderDay> days = GetCalenderDays();
            foreach (ICalenderDay calenderDay in days)
            {
                PrintCalenderDayMetaDataHeader(calenderDay);
                var results = await calenderDay.GetResults();
                foreach (var result in results)
                    await HandleResultTask(result);

                PrintCalenderDayMetaDataFooter(calenderDay);
            }
        }

        private List<ICalenderDay> GetCalenderDays()
        {
            return new List<ICalenderDay>
            {
                //new CalenderDay1(),
                //new CalenderDay2(),
                new CalenderDay3(),
                //new CalenderDay4()

            };
        }

        private void PrintCalenderDayMetaDataHeader(ICalenderDay calenderDay)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"----------- {calenderDay.GetName()} -----------");
            Console.WriteLine();
        }

        private void PrintCalenderDayMetaDataFooter(ICalenderDay calenderDay)
        {
            Console.WriteLine();
            Console.WriteLine($"-----------  -----------");
            Console.WriteLine();
            Console.WriteLine();
        }

        private Task HandleResultTask(IResultTask result)
        {
            switch (result)
            {
                case StringResultTask stringResult:
                    HandleStringResult(stringResult);
                    break;
            }

            return Task.CompletedTask;
        }

        private void HandleStringResult(StringResultTask result)
        {
            Console.WriteLine($"----------- {result.Description} -----------");
            Console.WriteLine();
            Console.WriteLine(result.Result);
            Console.WriteLine();
            Console.WriteLine($"----------- -----------");
        }
    }
}