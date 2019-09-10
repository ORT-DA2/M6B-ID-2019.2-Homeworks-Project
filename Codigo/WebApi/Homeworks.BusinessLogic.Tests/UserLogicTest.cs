using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homeworks.Domain;
using Homeworks.DataAccess.Interface;
using Moq;

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
                Password = "Argento"
            };
            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<User>()));
            mock.Setup(m => m.Save());
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
                UserName = "Hola",
                Password = "Hola"
            };
            var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
            mock
                .Setup(m => m.Get(user.Id))
                .Returns(user);
            var userLogic = new UserLogic(mock.Object);

            var result = userLogic.Get(user.Id);

            mock.VerifyAll();
            Assert.AreEqual(user.UserName, result.UserName);
        }
    }
}
