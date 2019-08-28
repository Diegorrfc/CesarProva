using Cesar.Domain.CesarContext.Entities;
using Cesar.Domain.CesarContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cesar.Tests.ValueObjects
{
    [TestClass]
    [TestCategory("ValueObject")]
    public class NameTests
    {
        private static readonly string _LastNameValid = "Rodrigo";
        private static readonly string _FirstNameValid = "Diego";

        public NameTests()
        {

        }

        [TestMethod]
        [DataRow("ddie")]
        [DataRow("dieg")]
        [DataRow("jaie")]
        public void ShouldReturnOneNotificationWhenFirstNameLessLength5AndLastNameValid(string firstName)
        {
            int qtdNotifications = 1;
            var document = new Name(firstName, _LastNameValid);
            Assert.AreEqual(document.Notifications.Count, qtdNotifications);
            Assert.AreEqual(document.IsValid(), false);
            Assert.AreEqual(document.IsInvalid(), true);
        }

        [TestMethod]
        [DataRow("d")]
        [DataRow("dieg")]
        [DataRow("jai")]
        public void ShouldReturnOneNotificationWhenLastNameLessLength5AndLastNameValid(string lastname)
        {
            int qtdNotifications = 1;
            var document = new Name(_FirstNameValid, lastname);
            Assert.AreEqual(document.Notifications.Count, qtdNotifications);
            Assert.AreEqual(document.IsValid(), false);
            Assert.AreEqual(document.IsInvalid(), true);
        }

        [TestMethod]
        [DataRow("diegorodrigoromaosossosos")]
        [DataRow("diegasdfiasndfnasndfn")]
        [DataRow("jaiasdfnscdckjaskjdfjkakfka")]
        public void ShouldReturnNotificationWhenFirstNameGrandThan15LengthAndLastNameIsValid(string firstName)
        {
            int qtdNotifications = 1;
            var document = new Name(firstName, _LastNameValid);
            Assert.AreEqual(document.Notifications.Count, qtdNotifications);
            Assert.AreEqual(document.IsValid(), false);
            Assert.AreEqual(document.IsInvalid(), true);
        }

        [TestMethod]
        [DataRow("diegorodrigoromaosossososadfsssssssssssssssssssssssssssssrewrtret")]
        [DataRow("diegasdfiasndfnasndfdsgfsdgffdfdddddddddddddddddddddddddddddddddddddddddfn")]
        [DataRow("jaiasdfnscdckjaskjsdfgsfalsjfhasifjnasjdfnjasndjsdanfjkdsajfhsadfjadskfdfjkakfka")]
        public void ShouldReturnNotificationWhenLastNameGrandThan30LengthAndFirstNameIsValid(string lastName)
        {
            int qtdNotifications = 1;
            var document = new Name(_FirstNameValid, lastName);
            Assert.AreEqual(document.Notifications.Count, qtdNotifications);
            Assert.AreEqual(document.IsValid(), false);
            Assert.AreEqual(document.IsInvalid(), true);
        }

        [TestMethod]
        public void ShouldReturnNotNotificationWhenFirstNameAndLastNameIsValid()
        {
            int qtdNotifications = 0;
            var document = new Name(_FirstNameValid, _LastNameValid);
            Assert.AreEqual(document.Notifications.Count, qtdNotifications);
            Assert.AreEqual(document.IsValid(), true);
            Assert.AreEqual(document.IsInvalid(), false);
        }
    }
}