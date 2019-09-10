using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homeworks.Domain;
using Homeworks.WebApi.Controllers;
using Homeworks.BusinessLogic.Interface;
using Moq;
using Homeworks.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homeworks.WebApi.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void CreateValidUserTest()
        {
            var user = new UserModel
            {
                Id = Guid.NewGuid(),
                UserName = "Pepe",
                Password = "Argento"
            };
            var mock = new Mock<ILogic<User>>(MockBehavior.Strict);
            mock.Setup(m => m.Create(It.IsAny<User>())).Returns(user.ToEntity());
            var controller = new UsersController(mock.Object);

            var result = controller.Post(user);
            var okResult = result as OkObjectResult;
            var model = okResult.Value as string;

            mock.VerifyAll();
            Assert.AreEqual("Se genero un usuario con el id: "+user.Id, model);
        }
    }
}
