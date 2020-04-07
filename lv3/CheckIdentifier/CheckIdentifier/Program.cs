using System;

namespace CheckIdentifier
{
    public static class Program
    {
        private static bool idResult;

        public static void Main(string[] args)
        {
            if (!ParseArgs(args))
            {
                Console.WriteLine("Invalid arguments count.\nUsage CheckIdentifier.exe <input string>");
                return;
            }

            IsIdentifier isIdentifier = new IsIdentifier();
            idResult = isIdentifier.IsValidIdentifier(args[0]);

            if (idResult)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                if (isIdentifier.IsEmpty)
                {
                    Console.WriteLine($"No\nEmpty input");
                    return;
                }

                Console.WriteLine($"No\nBad char at {isIdentifier.InvalidIndex} position.");
            }
        }

        public static bool ParseArgs(string[] args)
        {
            if (args.Length != 1)
                return false;
            return true;
        }
    }
}
