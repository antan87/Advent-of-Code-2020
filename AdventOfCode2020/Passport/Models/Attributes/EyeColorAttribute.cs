using AdventOfCode2020.Passport.Interfaces;

namespace AdventOfCode2020.Passport.Models.Attributes
{
    public record EyeColorAttribute(string Color) : IPassportAttribute;
}