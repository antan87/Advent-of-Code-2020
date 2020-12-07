using System.Linq;
using AdventOfCode2020.Passport.Interfaces;

namespace AdventOfCode2020.Passport.Models.Rules
{
    public class RequiredPassportAttribute<TPassportAttribute> : IRequiredPassportAttributeRule
      where TPassportAttribute : IPassportAttribute
    {
        public bool Validate(Passport password)
        {
            return password.Attributes.Any(attribute => attribute.GetType() == typeof(TPassportAttribute));
        }
    }
}