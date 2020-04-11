using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordStrength;


namespace PasswordStrengthTests
{
    [TestClass]
    public class ParseArgsTest
    {
        [TestMethod]
        public void TooFewArguments_ReturnFalse()
        {
            string[] stringArray = { "input", "string" };

            bool result = Program.ParseArgs(stringArray);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidArgumentsCount_ReturnTrue()
        {
            string[] stringArray = { "iPasfwqr" };

            bool result = Program.ParseArgs(stringArray);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EmptyArguments_ReturnFalse()
        {
            string[] stringArray = System.Array.Empty<string>();

            bool result = Program.ParseArgs(stringArray);
            Assert.IsFalse(result);
        }
    }



    [TestClass]
    public class CheckIfStringConsistOfEnglishCharactersAndDigitsTests
    {
        [TestMethod]
        public void PasswordConsistOnlyOf_Digits_ReturnTrue()
        {
            string password = "879654";
            Assert.IsTrue(Program.CheckIfStringConsistOfEnglishCharactersAndDigits(password));
        }

        [TestMethod]
        public void PasswordConsistOf_EnglishChars_ReturnTrue()
        {
            string password = "AwfqwWgqw";
            Assert.IsTrue(Program.CheckIfStringConsistOfEnglishCharactersAndDigits(password));
        }

        [TestMethod]
        public void PasswordConsistOf_OneChar_ReturnTrue()
        {
            string password = "a";
            Assert.IsTrue(Program.CheckIfStringConsistOfEnglishCharactersAndDigits(password));
        }

        [TestMethod]
        public void PasswordConsistOf_OneDigit_ReturnTrue()
        {
            string password = "5";
            Assert.IsTrue(Program.CheckIfStringConsistOfEnglishCharactersAndDigits(password));
        }

        [TestMethod]
        public void PasswordConsistOf_CyrillicChars_ReturnFalse()
        {
            string password = "ÏðÏàðîëü";
            Assert.IsFalse(Program.CheckIfStringConsistOfEnglishCharactersAndDigits(password));
        }

        [TestMethod]
        public void PasswordConsistOf_SpecialSymbols_ReturnFalse()
        {
            string password = "&^!@$&^!@*%&";
            Assert.IsFalse(Program.CheckIfStringConsistOfEnglishCharactersAndDigits(password));
        }

        [TestMethod]
        public void PasswordConsistOf_MixOfEnglishAndCyrillicChars_ReturnFalse()
        {
            string password = "HardPassÄà";
            Assert.IsFalse(Program.CheckIfStringConsistOfEnglishCharactersAndDigits(password));
        }

        [TestMethod]
        public void PasswordConsistOf_MixOfCharactersAndDigits_ReturnTrue()
        {
            string password = "hqQwr874gWQgasg5";
            Assert.IsTrue(Program.CheckIfStringConsistOfEnglishCharactersAndDigits(password));
        }

    }


    [TestClass]
    public class TestGetPasswordStrengthByCharactersCount
    {
        [TestMethod]
        public void PasswordConsistOnlyOf_LowerChars_28Return()
        {
            string password = "bgwqwag";
            Assert.AreEqual(28, Program.GetPasswordStrengthByCharactersCount(password));
        }

        [TestMethod]
        public void PasswordConsistOnlyOf_Digits_28Return()
        {
            string password = "1234567";
            Assert.AreEqual(28, Program.GetPasswordStrengthByCharactersCount(password));
        }

        [TestMethod]
        public void EmptyPassword_0Return()
        {
            string password = "";
            Assert.AreEqual(0, Program.GetPasswordStrengthByCharactersCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_MixCharsAndDigits_68Return()
        {
            string password = "Af76AFSfqwf&6fqwf";
            Assert.AreEqual(68, Program.GetPasswordStrengthByCharactersCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_CharsAndDigits_68Return()
        {
            string password = "Af76AFSfqwf&6fqwf";
            Assert.AreEqual(68, Program.GetPasswordStrengthByCharactersCount(password));
        }
    }

    [TestClass]
    public class TestGetPasswordStrengthByDigitCount
    {
        [TestMethod]
        public void EmptyPassword_0Return()
        {
            string password = "";
            Assert.AreEqual(0, Program.GetPasswordStrengthByDigitCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_OneDigit_4Return()
        {
            string password = "1";
            Assert.AreEqual(4, Program.GetPasswordStrengthByDigitCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_4Digits_16Return()
        {
            string password = "1543";
            Assert.AreEqual(16, Program.GetPasswordStrengthByDigitCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_4Letters_0Return()
        {
            string password = "astf";
            Assert.AreEqual(0, Program.GetPasswordStrengthByDigitCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_MixLettersAndDigits_12Return()
        {
            string password = "a7s1t5f";
            Assert.AreEqual(12, Program.GetPasswordStrengthByDigitCount(password));
        }
    }

    [TestClass]
    public class TestGetPasswordStrengthByUpperCharactersCount
    {
        [TestMethod]
        public void EmptyPassword()
        {
            string password = "";
            Assert.AreEqual(0, Program.GetPasswordStrengthByUpperLettersCount(password));
        }


        [TestMethod]
        public void PasswordConsistOf_8Digits_0Return()
        {
            string password = "23654987";
            Assert.AreEqual(0, Program.GetPasswordStrengthByUpperLettersCount(password));
        }


        [TestMethod]
        public void PasswordConsistOf_2UpperLetters5Digits_6Return()
        {
            string password = "2A5C9";
            Assert.AreEqual(6, Program.GetPasswordStrengthByUpperLettersCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_2Upper3LowerLetters2Digits_10Return()
        {
            string password = "2Af5cCa";
            Assert.AreEqual(10, Program.GetPasswordStrengthByUpperLettersCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_10UpperLetters2Digits_4Return()
        {
            string password = "YABCD26JEFAF";
            Assert.AreEqual(4, Program.GetPasswordStrengthByUpperLettersCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_2UpperChars_0Return()
        {
            string password = "UA";
            Assert.AreEqual(0, Program.GetPasswordStrengthByUpperLettersCount(password));
        }
    }

    [TestClass]
    public class GetPasswordStrengthByLowerCharactersCountTest
    {
        [TestMethod]
        public void EmptyPassword_0Return()
        {
            string password = "";
            Assert.AreEqual(0, Program.GetPasswordStrengthByLowerLettersCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_8Digits_0Return()
        {
            string password = "23654987";
            Assert.AreEqual(0, Program.GetPasswordStrengthByLowerLettersCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_2Upper3LowerLetters3Digits_10Return()
        {
            string password = "AaY1a8f4";
            Assert.AreEqual(10, Program.GetPasswordStrengthByLowerLettersCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_3LowerLetters_0Return()
        {
            string password = "asd";
            Assert.AreEqual(0, Program.GetPasswordStrengthByLowerLettersCount(password));
        }
    }

    [TestClass]
    public class TestGetPasswordStrengthByConsistsOnlyOfLetters
    {
        [TestMethod]
        public void EmptyPassword_0Return()
        {
            string password = "";
            Assert.AreEqual(0, Program.GetPasswordStrengthByConsistsOnlyOfLetters(password));
        }

        [TestMethod]
        public void PasswordConsistOf_6Digits_0Return()
        {
            string password = "654789";
            Assert.AreEqual(0, Program.GetPasswordStrengthByConsistsOnlyOfLetters(password));
        }

        [TestMethod]
        public void PasswordConsistOf_6Digits5Letters_0Return()
        {
            string password = "6a5L4w7A8F9";
            Assert.AreEqual(0, Program.GetPasswordStrengthByConsistsOnlyOfLetters(password));
        }

        [TestMethod]
        public void PasswordConsistOf_5Letters_5Return()
        {
            string password = "ajfQu";
            Assert.AreEqual(-5, Program.GetPasswordStrengthByConsistsOnlyOfLetters(password));
        }

    }


    [TestClass]
    public class TestGetPasswordStrengthByConsistsOnlyOfDigits
    {
        [TestMethod]
        public void EmptyPassword_0Return()
        {
            string password = "";
            Assert.AreEqual(0, Program.GetPasswordStrengthByConsistsOnlyOfDigits(password));
        }

        [TestMethod]
        public void PasswordConsistOf_6Digits_6Return()
        {
            string password = "654789";
            Assert.AreEqual(-6, Program.GetPasswordStrengthByConsistsOnlyOfDigits(password));
        }

        [TestMethod]
        public void PasswordConsistOf_6Digits5Letters_0Return()
        {
            string password = "6a5L4w7A8F9";
            Assert.AreEqual(0, Program.GetPasswordStrengthByConsistsOnlyOfDigits(password));
        }

        [TestMethod]
        public void PasswordConsistOf_5Letters_0Return()
        {
            string password = "ajfQu";
            Assert.AreEqual(0, Program.GetPasswordStrengthByConsistsOnlyOfDigits(password));
        }

    }

    [TestClass]
    public class TestGetPasswordStrengthByCharactersRepetitiveCount
    {
        [TestMethod]
        public void EmptyPassword_0Return()
        {
            string password = "";
            Assert.AreEqual(0, Program.GetPasswordStrengthByCharactersRepetitiveCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_NoRepeat_6Digits_0Return()
        {
            string password = "654789";
            Assert.AreEqual(0, Program.GetPasswordStrengthByCharactersRepetitiveCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_NoRepeat_6Digits5Letters_0Return()
        {
            string password = "6a5L4w7A8F9";
            Assert.AreEqual(0, Program.GetPasswordStrengthByCharactersRepetitiveCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_NoRepeat_5Letters_0Return()
        {
            string password = "ajfQu";
            Assert.AreEqual(0, Program.GetPasswordStrengthByCharactersRepetitiveCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_2Repeats_5Letters_2Return()
        {
            string password = "ajfau";
            Assert.AreEqual(-2, Program.GetPasswordStrengthByCharactersRepetitiveCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_3Repeats_5Digits_3Return()
        {
            string password = "a1f11";
            Assert.AreEqual(-3, Program.GetPasswordStrengthByCharactersRepetitiveCount(password));
        }

        [TestMethod]
        public void PasswordConsistOf_5Repeats_5Digits3Letters_5Return()
        {
            string password = "a51f11f";
            Assert.AreEqual(-5, Program.GetPasswordStrengthByCharactersRepetitiveCount(password));
        }

    }

    [TestClass]
    public class TestGetPasswordStrenght
    {

        [TestMethod]
        public void EmptyPassword_0Return()
        {
            string password = "";
            Assert.AreEqual(0, Program.GetPasswordStrenght(password));
        }

        [TestMethod]
        public void PasswordConsistOf_1Digit_7Return()
        {
            string password = "2";
            Assert.AreEqual(7, Program.GetPasswordStrenght(password));
        }

        [TestMethod]
        public void PasswordConsistOf_1LowerLetter_3Return()
        {
            string password = "a";
            Assert.AreEqual(3, Program.GetPasswordStrenght(password));
        }

        [TestMethod]
        public void PasswordConsistOf_1UpperLetter_3Return()
        {
            string password = "A";
            Assert.AreEqual(3, Program.GetPasswordStrenght(password));
        }

        [TestMethod]
        public void PasswordConsistOf_NoRepeat_4Upper3LowerLetters_35Return()
        {
            string password = "AbCdEfG";
            Assert.AreEqual(35, Program.GetPasswordStrenght(password));
        }

        [TestMethod]
        public void PasswordConsistOf_NoRepeat_4Upper3LowerLetters5Digits_35Return()
        {
            string password = "Ab4Cd16E5f7G";
            Assert.AreEqual(102, Program.GetPasswordStrenght(password));
        }

        [TestMethod]
        public void PasswordConsistOf_8Repeats_4Upper3LowerLetters5Digits_35Return()
        {
            string password = "Ab4Ab14E5b7A";
            Assert.AreEqual(94, Program.GetPasswordStrenght(password));
        }

        [TestMethod]
        public void PasswordConsistOf_NoRepeats_3UpperLetters3Digits_35Return()
        {
            string password = "1A2BC3";
            Assert.AreEqual(42, Program.GetPasswordStrenght(password));
        }

        [TestMethod]
        public void PasswordConsistOf_NoRepeats_3LowerLetters3Digits_35Return()
        {
            string password = "1a2bc3";
            Assert.AreEqual(42, Program.GetPasswordStrenght(password));
        }

        [TestMethod]
        public void PasswordConsistOf_10Repeats_5Lower6UpperLetters4Digits_35Return()
        {
            string password = "aA2ab1BcCkC1KK2";
            Assert.AreEqual(104, Program.GetPasswordStrenght(password));
        }


    }
}
