using System;
using Cesar.Domain.CesarContext.Entities;
using Cesar.Domain.CesarContext.Enums;
using Cesar.Domain.CesarContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cesar.Tests.Entities {
    [TestClass]
    [TestCategory("Entities")]
    public class CollaboratorTests {
        private Name _name;
        private Document _document;
        private Email _email;
        private Phone _phone;
        private Address _addsress;
        private decimal _salary;
        private string _projectName;
        private DateTime _birthDate;
        private string _jobTitle ="Desenvolvedor";

        public CollaboratorTests () {
            _name = new Name ("Diego", "Rodrigo");
            _document = new Document ("12345678908");
            _email = new Email ("diego.rrfc@gmail.com");
            _phone = new Phone ("999999993");
            _addsress = new Address ("Rua cais do apolo", "222", "recife antigo", "Recife", "Brasil", "52160000");
            _salary = 10000;
            _projectName = "Cesar Educação";
            _birthDate = DateTime.Now.AddYears (18);
            
        }
        
        [TestMethod]
        public void ShoudCollaboratorIsValid () {
            bool collaboratorIsvalid = true;
            var colab = new Collaborator (
                _name, _document, _email,
                _phone, _addsress, _salary,
                _projectName, _birthDate, _jobTitle);

            bool valid = colab.IsValid ();

            Assert.AreEqual (valid, collaboratorIsvalid);
        }
        [TestMethod]
        public void ShoudReturnOneNotificationWhenYerOldCollaboratorIsLess18yers()
        {
            DateTime yerOld = DateTime.UtcNow.AddYears(-10);
            bool collaboratorIsvalid = true;
            var colab = new Collaborator(
                _name, _document, _email,
                _phone, _addsress, _salary,
                _projectName, yerOld, _jobTitle);

            bool valid = colab.IsValid();

            Assert.AreEqual(valid, collaboratorIsvalid);
        }

        [TestMethod]
        public void ShoudRetunOneNotificationWhenSalaryIsLess1000 () {
            decimal salary = 900;
            int qtdNotifications = 1;
            var colab = new Collaborator (
                _name, _document, _email,
                _phone, _addsress, salary,
                _projectName, _birthDate, _jobTitle);

            bool valid = colab.IsValid ();
            Assert.AreEqual (colab.Notifications.Count, qtdNotifications);
            Assert.AreEqual (valid, false);
        }
        [TestMethod]
        public void ShoudRetunOneNotificationWhenProjectNameIsLess2 () {
            string projectName = "a";
            int qtdNotifications = 1;
            var colab = new Collaborator (
                _name, _document, _email,
                _phone, _addsress, _salary,
                projectName, _birthDate, _jobTitle);

            bool valid = colab.IsValid ();
            Assert.AreEqual (colab.Notifications.Count, qtdNotifications);
            Assert.AreEqual (valid, false);
        }
        [TestMethod]
        public void ShoudRetunOneNotificationWhenProjectNameIsGreater10 () {
            string projectName = "projetomaiordoque10fimjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj";
            int qtdNotifications = 1;
            var colab = new Collaborator (
                _name, _document, _email,
                _phone, _addsress, _salary,
                projectName, _birthDate, _jobTitle);

            bool valid = colab.IsValid ();
            Assert.AreEqual (colab.Notifications.Count, qtdNotifications);
            Assert.AreEqual (valid, false);
        }
        [TestMethod]
        public void ShoudRetunTwoNotificationWhenProjectNameIsGreater10AndSalaryIsless100 () {
            string projectName = "projetomaiordoque10fimooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo";
            decimal salary = 900;
            int qtdNotifications = 2;
            var colab = new Collaborator (
                _name, _document, _email,
                _phone, _addsress, salary,
                projectName, _birthDate, _jobTitle);

            bool valid = colab.IsValid ();
            Assert.AreEqual (colab.Notifications.Count, qtdNotifications);
            Assert.AreEqual (valid, false);
        }


    }
}