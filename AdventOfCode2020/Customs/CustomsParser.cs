using System;
using System.Linq;
using AdventOfCode2020.Customs.Models;
using Parser.Parsers.Interface;

namespace AdventOfCode2020.Customs
{
    public class CustomsParser : IParser<CustomsGroup>
    {
        public CustomsGroup Parse(string value)
        {
            var personAnswers = value.Split(Environment.NewLine)
                                     .Select(personAnswers => new CustomsPerson(personAnswers
                                     .Select(answer => new CustomsAnswer(answer))));

            return new CustomsGroup(personAnswers);
        }
    }
}