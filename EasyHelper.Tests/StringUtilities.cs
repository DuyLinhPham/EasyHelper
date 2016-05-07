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
            string dataFake = "This is sample";
            string result = EasyHelper.StringUtilities.GetFirstCharacters(dataFake);
            Assert.AreEqual("Tis",result);
        }
    }
}
