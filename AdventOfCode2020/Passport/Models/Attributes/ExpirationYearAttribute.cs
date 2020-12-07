using AdventOfCode2020.Passport.Interfaces;

namespace AdventOfCode2020.Passport.Models.Attributes
{
    public record ExpirationYearAttribute(int Yaar) : IPassportAttribute;
}