using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftTeam.SoftBar.Core.Misc;

namespace SoftTeam.SoftBar.Test
{
    [TestClass]
    public class StringExtensionTest
    {
        #region NumberOfLines
        [TestMethod]
        public void NOLEmptyStringTest()
        {
            string test = string.Empty;

            var nol = test.NumberOfLines();

            Assert.AreEqual(0, nol);
        }

        [TestMethod]
        public void NOLEmptyStringTest2()
        {
            string test = "";

            var nol = test.NumberOfLines();

            Assert.AreEqual(0, nol);
        }

        [TestMethod]
        public void NOLSimpleStringTest()
        {
            string test = "Simple string";

            var nol = test.NumberOfLines();

            Assert.AreEqual(1, nol);
        }

        [TestMethod]
        public void NOLMultiLineStringTest()
        {
            string test = "Multi line string\nwith several\nrows!!";

            var nol = test.NumberOfLines();

            Assert.AreEqual(3, nol);
        }
        #endregion

        #region RestrictSize
        [TestMethod]
        public void RSEmptyStringTest()
        {
            string test = string.Empty;

            test = test.RestrictSize();

            Assert.AreEqual(string.Empty, test);
        }

        [TestMethod]
        public void RSEmptyStringTest2()
        {
            string test = "";

            test = test.RestrictSize();

            Assert.AreEqual(string.Empty, test);
        }

        [TestMethod]
        public void RSNotRestrictedTest()
        {
            string test = "Short text";

            test = test.RestrictSize();

            Assert.AreEqual("Short text", test);
        }

        [TestMethod]
        public void RSShortRestrictedTest()
        {
            string test = "Short text";

            test = test.RestrictSize(1,8);

            Assert.AreEqual("Short te", test);
        }

        [TestMethod]
        public void RSMultilineTest()
        {
            string test = "A longer test that will be restricted\nbecause it is way to long\nand it basically will never\nend even if I want it too!!";

            test = test.RestrictSize();

            Assert.AreEqual("A longer test that w\nbecause it is way to\nand it basically wil", test);
        }
        #endregion
    }
}
