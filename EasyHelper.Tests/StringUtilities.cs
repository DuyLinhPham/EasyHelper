using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasyHelper;
namespace EasyHelper.Tests
{
    [TestClass]
    public class StringUtilities
    {
        [TestMethod]
        public void GetFirstCharacters()
        {
            const string dataFake = "This is sample";
            string result = EasyHelper.StringUtilities.GetFirstCharacters(dataFake);
            Assert.AreEqual("Tis",result);
        }

        [TestMethod]
        public void FindWord()
        {
            const string dataFake = "This is sample";
            const string wordToFind = "sample";
            string result = EasyHelper.StringUtilities.FindWord(dataFake,wordToFind);
            Assert.AreEqual("8,13", result);
        }
    }
}
