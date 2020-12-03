using AdventOfCode2020.Calender.Day2.Policy.Interface;

namespace AdventOfCode2020.Calender.Day2.Policy.Models
{
    public class LetterCondition : ICondition
    {
        public LetterCondition(char letter)
        {
            Letter = letter;
        }

        public char Letter { get; }
    }
}