using AdventOfCode2020.Passport.Interfaces;

namespace AdventOfCode2020.Passport.Models.Attributes
{
    public record IssueYearAttribute(int Year) : IPassportAttribute;
}