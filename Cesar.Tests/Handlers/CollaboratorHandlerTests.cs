using System;
using Cesar.Domain.CesarContext.Commands.CollaboratorComands.Input;
using Cesar.Domain.CesarContext.Handlers;
using Cesar.Shared.utils;
using Cesar.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cesar.Tests.Handlers {
    [TestClass]
    public class CollaboratorHandlerTests {
        [TestMethod]
        public void ShoulRegisterCollaboratorWhenComandIsvalid () {
            var comand = new CreateCollaboratorComand ();
            comand.FirstName = "Diego";
            comand.LastName = "Rodrigo";
            comand.Document = "12345678909";
            comand.Email = "diego.rrfc@gmail.com";
            comand.Phone = "9994949345";
            comand.Salary = 2000;
            comand.Street = "rua cais do apolo";
            comand.ZipCode = "52140000";
            comand.birthDate = DateTime.Now.AddYears (-18);
            comand.City = "Recife";
            comand.Country = "Brasil";
            comand.District = "Zona sul";
            comand.JobTitle = "Desenvolvedor";
            comand.ProjectName = "Cesar seleção";
            comand.Number="10";

            var hd = new CollaboratorHandler (new MockCollaboratorRepository (), new MockEmailService ());
            hd.Handle(comand);
            Assert.AreEqual (hd.IsValid (), true);

        }
    }
}