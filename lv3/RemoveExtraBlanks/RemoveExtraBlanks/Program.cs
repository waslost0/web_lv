using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RemoveExtraBlanks
{
    public static class Program
    { 
        public static void Main(string[] args)
        {
            if (!ParseArgs(args))
            {
                Console.WriteLine("Invalid arguments count.\nUsage RemoveExtraBlanks.exe <inputFile> <outputFile>");
                return;
            }

            string inputFile = args[0];
            string outputFile = args[1];


            if (!CheckFiles(inputFile, outputFile)) return;

            string line;

            using (StreamReader reader = new StreamReader(inputFile))
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    line = TrimAndRemoveExtraBlanks(line);
                    writer.WriteLine(line);
                }
            }
        }

        public static string TrimAndRemoveExtraBlanks(string inputString)
        {
            string result= TrimString(inputString);
            result = RemoveExtraBlanks(result);
            return result;
        }

        public static string TrimString(string inputString, char[] charsToTrim = null)
        {
            return inputString.Trim(charsToTrim);
        }

        public static string RemoveExtraBlanks(string inputString)
        {
            string pattern = @"[ \t]+";
            string replacement = " ";
            return Regex.Replace(inputString, pattern, replacement);
        }

        public static bool CheckFiles(string inputFile, string outputFile)
        {
            if (inputFile == outputFile)
            {
                Console.WriteLine("Files cannot be equal.");
                return false;
            }

            if (!File.Exists(inputFile))
            {
                Console.WriteLine($"File {inputFile} does not exist.");
                return false;
            }
            else if (!File.Exists(outputFile))
            {
                using (File.CreateText(outputFile)) { }
                Console.WriteLine($"File {outputFile} does not exist. Was created.");
                return true;

            }
            return true;
        }

        public static bool ParseArgs(string[] args)
        {
            if (args.Length != 2)
                return false;
            return true;
        }
    }
}
