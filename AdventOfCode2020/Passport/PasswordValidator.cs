using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Passport.Interfaces;

namespace AdventOfCode2020.Passport
{
    public static class PasswordValidator
    {
        public static bool Validate(Passport.Models.Passport passport, IEnumerable<IPassportRule> rules)
        {
            return rules.All(rule => rule.Validate(passport));
        }
    }
}