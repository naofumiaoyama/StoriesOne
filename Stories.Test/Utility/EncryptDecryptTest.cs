using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stories.Utility;

namespace Stories.Test.Utility
{
    [TestClass]
    public class EncryptDecryptTest
    {
        [TestMethod]
        public void EncryptTest()
        {
            var enc = EncryptDecrypt.Encrypt("Hello World");
            Assert.AreEqual("12a1n2YbraKP4vndygkukQ==", enc);
        }
        [TestMethod]
        public void DecryptTest()
        {
            var dec = EncryptDecrypt.Decrypt("12a1n2YbraKP4vndygkukQ==");
            Assert.AreEqual(dec, "Hello World");
        }
    }
}
