using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoveExtraBlanks;
using System.IO;

namespace RemoveExtraBlanksTests
{
    [TestClass]
    public class ParseArgsTest
    {

        [TestMethod]
        public void InvalidArgumentsCount()
        {
            string[] stringArray = { "input.txt", "o.txt" };

            bool result = Program.ParseArgs(stringArray);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TooFewArguments()
        {
            string[] stringArray = { "input.txt", "o.txt" , "string"};

            bool result = Program.ParseArgs(stringArray);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidArgumentsCount()
        {
            string[] stringArray = { "input.txt", "output.txt" };

            bool result = Program.ParseArgs(stringArray);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EmptyArguments()
        {
            string[] stringArray = System.Array.Empty<string>();

            bool result = Program.ParseArgs(stringArray);
            Assert.IsFalse(result);
        }


    }

    [TestClass]
    public class FilesTest
    {
        private const string inputFileName = "input.txt";
        private const string outputFileName = "output.txt";

        [TestMethod]
        public void BothFilesExist()
        {
            using (File.CreateText(inputFileName)) { }

            bool result = Program.CheckFiles(inputFileName, outputFileName);
            Assert.IsTrue(result);
            File.Delete(inputFileName);
            File.Delete(outputFileName);
        }


        [TestMethod]
        public void OutputFileDoesNotExist()
        {
            using (File.CreateText(inputFileName)) { }

            bool result = Program.CheckFiles(inputFileName, outputFileName);
            Assert.IsTrue(result);
            Assert.IsTrue(File.Exists(outputFileName));

            File.Delete(inputFileName);
            File.Delete(outputFileName);
        }


        [TestMethod]
        public void InputFileDoesNotExist()
        {
            bool result = Program.CheckFiles(inputFileName, outputFileName);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void FileNamesAreEqual()
        {
            bool result = Program.CheckFiles(inputFileName, inputFileName);
            Assert.IsFalse(result);
        }
    }


    [TestClass]
    public class TrimStringTest
    {

        [TestMethod]
        public void SpaceOnStartAndEnd()
        {
            string stringToTrim = " Hello, there ";

            Assert.AreEqual("Hello, there", Program.TrimString(stringToTrim));
        }

        [TestMethod]
        public void TabOnStartAndEnd()
        {
            string stringToTrim = "\tHello, there\t";

            Assert.AreEqual("Hello, there", Program.TrimString(stringToTrim));
        }
        [TestMethod]
        public void MixOfTabsAndSapcesOnStartAndEndOfString()
        {
            string stringToTrim = "\t \t     \tHello, there\t   \t\t  ";

            Assert.AreEqual("Hello, there", Program.TrimString(stringToTrim));
        }
        [TestMethod]
        public void EmptyString()
        {
            string stringToTrim = "";

            Assert.AreEqual("", Program.TrimString(stringToTrim));
        }
        [TestMethod]
        public void StringConsistTabs()
        {
            string stringToTrim = "\t\t\t";

            Assert.AreEqual("", Program.TrimString(stringToTrim));
        }
    }


    [TestClass]
    public class RemoveExtraBlanksTest
    {
        [TestMethod]
        public void EmptyString()
        {
            string inputString = "";
            Assert.AreEqual("", Program.RemoveExtraBlanks(inputString));
        }


        [TestMethod]
        public void InputStringIsOneSpace()
        {
            string inputString = " ";
            Assert.AreEqual(" ", Program.RemoveExtraBlanks(inputString));
        }

        [TestMethod]
        public void MultipleLinesStringAndMixOfSpacesAndTabs()
        {
            string inputString = " String   with         \nmultiple            lines ";
            Assert.AreEqual(" String with \nmultiple lines ", Program.RemoveExtraBlanks(inputString));
        }

        [TestMethod]
        public void NormalStringWithoutDuplicatesOfSpacesAndTabs()
        {
            string inputString = "Just noraml string.";
            Assert.AreEqual("Just noraml string.", Program.RemoveExtraBlanks(inputString));
        }

        [TestMethod]
        public void NormalSngWithoutDuplicatesOfSpacesAndTabs()
        {
            string inputString = "Just noraml string.";
            Assert.AreEqual("Just noraml string.", Program.RemoveExtraBlanks(inputString));
        }


    }
}
