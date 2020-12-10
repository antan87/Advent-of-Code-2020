using System.Collections.Generic;

namespace AdventOfCode2020.Customs.Models
{
    public record CustomsPerson(IEnumerable<CustomsAnswer> Answers);
}