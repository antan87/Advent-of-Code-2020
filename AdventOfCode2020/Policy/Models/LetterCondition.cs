using AdventOfCode2020.Calender.Policy.Interface;

namespace AdventOfCode2020.Calender.Policy.Models
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