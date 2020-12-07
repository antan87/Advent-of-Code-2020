using System.Collections.Generic;
using AdventOfCode2020.Passport.Interfaces;

namespace AdventOfCode2020.Passport.Models
{
    public record Passport(IEnumerable<IPassportAttribute> Attributes);
}