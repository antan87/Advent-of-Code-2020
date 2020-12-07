namespace AdventOfCode2020.Passport.Interfaces
{
    public interface IPassportRule
    {
        bool Validate(Passport.Models.Passport password);
    }
}