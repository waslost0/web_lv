using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translator.Models;
namespace TranslatorTest
{
    [TestClass]
    public class DictTest
    {
        Translator.Models.Translator dict = new Translator.Models.Translator("../../../dict.txt");

        [TestMethod]
        public void Transalte_EmptyWord_ReturnEmptyList()
        {
            string word = "";
            string result = dict.Transalte(word);
            Assert.AreEqual("", result);  
        }

        [TestMethod]
        public void Transalte_NotExistWord_ReturnEmptyList()
        {
            string word = "word";
            string result = dict.Transalte(word);
            Assert.AreEqual("", result);      
        }

        [TestMethod]
        public void Transalte_ExistEnglishWord_ReturnEmptyList()
        {
            string word = "also";
            string result = dict.Transalte(word);
            Assert.AreEqual("также", result);   
        }

        [TestMethod]
        public void Transalte_ExistRussinaWord_ReturnEmptyList()
        {
            string word = "также";
            string result = dict.Transalte(word);
            Assert.AreEqual("also", result);   
        }
    }
}
