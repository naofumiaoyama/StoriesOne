using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stories.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Test.Stories.Data.Queries
{
    [TestClass]
  public class loginQueryTest
    {
        [TestMethod]
        public void  GetTest()
        {
            var query = new LoginQuery();
            var personalInfo = query.Get("naofumi.aoyama@gmail.com", "Dm10taQ/oG8bPpJtKFFOOA==");
            Assert.AreEqual(personalInfo.Result.LoginID, "naofumi.aoyama@gmail.com");
            Assert.AreEqual(personalInfo.Result.EncryptedPassword, "Dm10taQ/oG8bPpJtKFFOOA==");
            
        }
    }
}
