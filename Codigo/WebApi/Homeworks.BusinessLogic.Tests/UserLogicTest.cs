using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homeworks.Domain;
using Homeworks.DataAccess.Interface;
using Moq;
using System.Collections.Generic;
using System;

namespace Homeworks.BusinessLogic.Tests
{
    [TestClass]
    public class UserLogicTest
    {
        [TestMethod]
        public void CreateValidUserTest()
        {
            var user = new User
            {
                UserName = "Pepe",
                Password = "Pass"
            };
            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(() => new List<User>());
            mock.Setup(m => m.Add(It.IsAny<User>()));
            mock.Setup(m => m.Save());
            var userLogic = new UserLogic(mock.Object);

            var result = userLogic.Create(user);

            mock.VerifyAll();
            Assert.AreEqual(user.UserName, result.UserName);
        }

        [ExpectedException(typeof(ArgumentException), "Ya existe el usuario.")]
        [TestMethod]
        public void CreateExistUserTest()
        {
            var user = new User
            {
                UserName = "Pepe",
                Password = "Pass"
            };
            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(() => new List<User>() { new User() { UserName="Pepe"}});
            
            var userLogic = new UserLogic(mock.Object);

            var result = userLogic.Create(user);

            mock.VerifyAll();
            Assert.AreEqual(user.UserName, result.UserName);
        }

        [TestMethod]
        public void GetValidUserTest()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = "Pepe",
                Password = "Pass"
            };
            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(user.Id)).Returns(user);
            var userLogic = new UserLogic(mock.Object);

            var result = userLogic.Get(user.Id);

            mock.VerifyAll();
            Assert.AreEqual(user.UserName, result.UserName);
        }
    }
}

