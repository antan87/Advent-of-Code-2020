using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Passport.Interfaces;
using AdventOfCode2020.Passport.Models.Attributes;
using Parser.Parsers;
using Parser.Parsers.Interface;

namespace AdventOfCode2020.Passport
{
    public class PassportParser : IParser<Passport.Models.Passport>
    {
        public Models.Passport Parse(string value)
        {
            var rows = value.Split(Environment.NewLine);
            List<IPassportAttribute> attributes = new List<IPassportAttribute>();
            for (int index = 0; index < rows.Length; index++)
                attributes.AddRange(rows[index].Split(" ").Select(keyValuePair => GetAttribute(keyValuePair)));

            return new Models.Passport(attributes);
        }

        private IPassportAttribute GetAttribute(string keyValuePair)
        {
            string[] parts = keyValuePair.Split(":");

            switch (parts[0])
            {
                case "byr":
                    return new BirthYearAttribute(ParserCreator.Int32Parser.Parse(parts[1]));

                case "iyr":
                    return new IssueYearAttribute(ParserCreator.Int32Parser.Parse(parts[1]));

                case "eyr":
                    return new ExpirationYearAttribute(ParserCreator.Int32Parser.Parse(parts[1]));

                case "hgt":
                    return new HeightAttribute(parts[1]);

                case "hcl":
                    return new HairColorAttribute(parts[1]);

                case "ecl":
                    return new EyeColorAttribute(parts[1]);

                case "pid":
                    return new PassportIDAttribute(parts[1]);

                case "cid":
                    return new CountryIDAttribute(parts[1]);

                default:
                    throw new NotImplementedException($"Missing implementation {parts[0]}");
            }
        }
    }
}