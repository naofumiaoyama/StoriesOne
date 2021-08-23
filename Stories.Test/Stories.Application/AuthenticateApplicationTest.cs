using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.Application;
using AutoMapper.Configuration;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace Stories.Test.Stories.Application
{
    [TestClass]
    public class AuthenticateApplicationTest
    {
        [TestMethod]
        public void AuthTest()
        {
            //var appSettings = ConfigurationManager.AppSettings;
            AuthenticateApplication authenticateApplication = new AuthenticateApplication();
            var personalInfo = authenticateApplication.Authenticate("naofumi.aoyama@gmail.com", "Dm10taQ/oG8bPpJtKFFOOA==");
            Assert.AreEqual(personalInfo.LoginID, "naofumi.aoyama@gmail.com");
            Assert.AreEqual(personalInfo.EncryptedPassword, "Dm10taQ/oG8bPpJtKFFOOA==");
            Assert.IsNotNull(personalInfo.Token);
        }

    }
}