using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PasswordStrength
{
    public static class Program
    {
        static int Main(string[] args)
        {
            if (!ParseArgs(args))
            {
                Console.WriteLine("Invalid arguments count.\nUsage RemoveExtraBlanks.exe <input string>");
                return 1;
            }


            string password = args[0];
            if (!CheckIfStringConsistOfEnglishCharactersAndDigits(password))
            {
                Console.WriteLine("Password must consist of English characters and/or digits.");
                return 1;
            }

            if (password.Length == 0)
            {
                Console.WriteLine("Password can not be empty!");
                return 1;
            }

            int passStr = GetPasswordStrenght(password);
            Console.WriteLine(passStr);


            return 0;
        }

        public static int GetPasswordStrenght(string password)
        {
            int passwordStrenght = 0;
            passwordStrenght += GetPasswordStrengthByCharactersCount(password);
            passwordStrenght += GetPasswordStrengthByDigitCount(password);
            passwordStrenght += GetPasswordStrengthByUpperLettersCount(password);
            passwordStrenght += GetPasswordStrengthByLowerLettersCount(password);
            passwordStrenght += GetPasswordStrengthByConsistsOnlyOfLetters(password);
            passwordStrenght += GetPasswordStrengthByConsistsOnlyOfDigits(password);
            passwordStrenght += GetPasswordStrengthByCharactersRepetitiveCount(password);

            return passwordStrenght;
        }

        public static bool CheckIfStringConsistOfEnglishCharactersAndDigits(string line)
        {
            Regex regex = new Regex("^[a-zA-Z0-9_]+$");
            if (regex.IsMatch(line)) return true;
            return false;
        }

        public static bool ParseArgs(string[] args)
        {
            if (args.Length != 1)
                return false;
            return true;
        }

        public static int GetPasswordStrengthByCharactersRepetitiveCount(string line)
        {
            if (line.Length == 0) return 0;

            string lineWithoutRepetitiveCharacters = new string(line.Distinct().ToArray());
            int passwordStrength = 0;
            var characterDict = line.GetCharacterCountDict();

            foreach (var character in lineWithoutRepetitiveCharacters)
            {
                if (characterDict.TryGetValue(character, out int value))
                {
                    if (value > 1)
                        passwordStrength += value;
                }
            }
            return -passwordStrength;
        }

        public static int GetPasswordStrengthByCharactersCount(string line)
        {
            return line.Length * 4;
        }

        public static int GetPasswordStrengthByDigitCount(string line)
        {
            return line.Count(char.IsDigit) * 4;
        }

        public static int GetPasswordStrengthByUpperLettersCount(string line)
        {
            int upperLetterCount = line.Count(char.IsUpper);
            if (upperLetterCount != 0)
            {
                return (line.Length - upperLetterCount) * 2;
            }
            return 0;
        }

        public static int GetPasswordStrengthByLowerLettersCount(string line)
        {
            int lowerLetterCount = line.Count(char.IsLower);
            if (lowerLetterCount != 0)
            {
                return (line.Length - lowerLetterCount) * 2;
            }
            return 0;
        }

        public static int GetPasswordStrengthByConsistsOnlyOfLetters(string line)
        {
            int lowerLetterCount = line.Count(char.IsLetter);
            if (lowerLetterCount == line.Length)
            {
                return -line.Length;
            }
            return 0;
        }

        public static int GetPasswordStrengthByConsistsOnlyOfDigits(string line)
        {
            int lowerLetterCount = line.Count(char.IsDigit);
            if (lowerLetterCount == line.Length)
            {
                return -line.Length;
            }
            return 0;
        }

        public static Dictionary<char, int> GetCharacterCountDict(this string text) =>
            text.GroupBy(c => c).OrderBy(c => c.Key).ToDictionary(grp => grp.Key, grp => grp.Count());
    }
}
