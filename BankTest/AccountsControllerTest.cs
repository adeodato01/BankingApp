using BankingAppMarch;
using BankUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BankTest
{
    [TestClass]
    public class AccountsControllerTest
    {
        [TestMethod]
        public void TestIndexViewWithNoLogin()
        {
            //AAA Arrange, Act and Assert
            //Arrange
            var controller = new AccountsController();

            //Act and Assert
            Assert.ThrowsException<NullReferenceException>(() => controller.Index());

        }
        [TestMethod]
        public void TestIndexViewWithEmptyLogin()
        {
            //Arrange
            var controller = new AccountsController();
            controller.UserName = string.Empty;

            //Act and Assert
            Assert.ThrowsException<NullReferenceException>(() => controller.Index());
        }
        [TestMethod]
        public void TestIndexViewWithLogin()
        {
            //Arrange
            var controller = new AccountsController();
            controller.UserName = "test@test.com";

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            var accounts = (IEnumerable<Account>)result.ViewData.Model;
            var count = 0;
            foreach (var account in accounts)
            {
                count++;
            }
            Assert.AreEqual<int>(3, count);
        }
    }
}
