using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckIdentifier;


namespace CheckIdentifierTest
{
    [TestClass]
    public class ParseArgsTest
    {

        [TestMethod]
        public void InvalidArgumentsCount()
        {
            string[] stringArray = { "User_id", "username1" };


            bool result = Program.ParseArgs(stringArray);


            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidArgumentsCount()
        {
            string[] stringArray = { "username" };


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
    public class CheckIdentifierTest
    {

        [TestMethod]
        public void EmptyIdentifier()
        {
            IsIdentifier checkIdentifier = new IsIdentifier();
            bool result = checkIdentifier.IsValidIdentifier("");
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void StartWithOneDigit()
        {
            IsIdentifier checkIdentifier = new IsIdentifier();
            bool result = checkIdentifier.IsValidIdentifier("1abc");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OneDigitIdentifier()
        {
            IsIdentifier checkIdentifier = new IsIdentifier();
            bool result = checkIdentifier.IsValidIdentifier("1");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WithSpecialSymbol()
        {
            IsIdentifier checkIdentifier = new IsIdentifier();
            bool result = checkIdentifier.IsValidIdentifier("Userna$me");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StartWithUpperCharacter()
        {
            IsIdentifier checkIdentifier = new IsIdentifier();
            bool result = checkIdentifier.IsValidIdentifier("Usern123ame");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StartWithLowerCharacter()
        {
            IsIdentifier checkIdentifier = new IsIdentifier();
            bool result = checkIdentifier.IsValidIdentifier("usern123ame");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SingleCharacter()
        {
            IsIdentifier checkIdentifier = new IsIdentifier();
            bool result = checkIdentifier.IsValidIdentifier("a");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SingleUpperCharacter()
        {
            IsIdentifier checkIdentifier = new IsIdentifier();
            bool result = checkIdentifier.IsValidIdentifier("U");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CyrillicCharcter()
        {
            IsIdentifier checkIdentifier = new IsIdentifier();
            bool result = checkIdentifier.IsValidIdentifier("�");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CyrillicString()
        {
            IsIdentifier checkIdentifier = new IsIdentifier();
            bool result = checkIdentifier.IsValidIdentifier("�������");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InputStringIncludeCyrilliCharacter()
        {
            IsIdentifier checkIdentifier = new IsIdentifier();
            bool result = checkIdentifier.IsValidIdentifier("usr�ame");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SpaceCharacter()
        {
            IsIdentifier checkIdentifier = new IsIdentifier();
            bool result = checkIdentifier.IsValidIdentifier(" ");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BadCharIndexPositionOne()
        {
            IsIdentifier checkIdentifier = new IsIdentifier();
            checkIdentifier.IsValidIdentifier("&");
            Assert.AreEqual(1, checkIdentifier.InvalidIndex);
        }

        [TestMethod]
        public void BadCharIndexPositionFive()
        {
            IsIdentifier checkIdentifier = new IsIdentifier();
            checkIdentifier.IsValidIdentifier("user&");
            Assert.AreEqual(5, checkIdentifier.InvalidIndex);
        }
    }
}
