using Cesar.Domain.CesarContext.Entities;
using Cesar.Domain.CesarContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Cesar.Tests.ValueObjects {
    [TestClass]
    [TestCategory("ValueObject")]
    public class PhoneTests {
        [TestMethod]
        [DataRow ("1234567890982")]
        [DataRow ("98765431246762")]
        [DataRow ("887732889296999")]
        [DataRow ("748998382829309949")]
        public void ShouldReturnNotificationWhenPhoneNumberGrandLenght12 (string phone) {
            var document = new Phone (phone);
            Assert.AreNotEqual (document.Notifications.Count, 0);
            Assert.AreEqual (document.IsValid (), false);
            Assert.AreEqual (document.IsInvalid (), true);
        }

        [TestMethod]
        [DataRow ("12345")]
        [DataRow ("1234")]
        [DataRow ("123")]
        [DataRow ("12")]
        public void ShouldReturnNotificationWhenPhoneNumberLessLenght6 (string phone) {
            var document = new Phone (phone);
            Assert.AreNotEqual (document.Notifications.Count, 0);
            Assert.AreEqual (document.IsValid (), false);
            Assert.AreEqual (document.IsInvalid (), true);
        }

        [TestMethod]
        [DataRow ("999999")]
        [DataRow ("73628304")]
        [DataRow ("17393049352")]
        [DataRow ("172930404-0")]
        public void ShouldReturnNotNotificationWhenPhoneNumberIsValid (string phoneNumber) {
            var document = new Phone (phoneNumber);
            Assert.AreEqual (document.Notifications?.Count, 0);
            Assert.AreEqual (document.IsValid (), true);
            Assert.AreEqual (document.IsInvalid (), false);
        }
    }
}