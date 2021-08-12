using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stories.Utility;

namespace Stories.Test.Stories.Utility
{
    [TestClass]
    public class EncryptDecryptTest
    {
        [TestMethod]
        public void EncryptTest()
        {
            var enc = EncryptDecrypt.Encrypt("Hello World");
            Assert.AreEqual("FtLmWWXLLD3LUhnqZpfJ2Y8SJmEdNTMu", enc);
        }
        
    }
}
