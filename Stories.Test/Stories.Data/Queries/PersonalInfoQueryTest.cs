using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.Data.Queries;

namespace Stories.Test.Stories.Data.Queries
{
    [TestClass]
    public class PersonalInfoQueryTest
    {

        [TestMethod]
        public async Task GetTest()
        {
            var query = new PersonalInfoQuery();
            var personalInfo = await query.Get(Guid.Parse("872A275C-283E-4161-A9C8-08D94E9FFD43"));
            Assert.AreEqual(personalInfo.LoginID, "naofumi.aoyama@gmail.com");
            Assert.AreEqual(personalInfo.EncryptedPassword, "Dm10taQ/oG8bPpJtKFFOOA==");
            
        }
    }
}      
