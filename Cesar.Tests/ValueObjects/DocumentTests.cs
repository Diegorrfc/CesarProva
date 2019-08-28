using Cesar.Domain.CesarContext.Entities;
using Cesar.Domain.CesarContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Cesar.Tests.ValueObjects {

    [TestClass]
    [TestCategory("ValueObject")]
    public class DocumentTests {
        [TestMethod]
        [DataRow ("1543234789045")]
        [DataRow ("12344567890234532")]
        [DataRow ("42344590")]
        [DataRow ("123456789023")]
        public void ShouldReturnNotificationWhenDocumentIsNotValid (string number) {
            var document = new Document (number);
            Assert.AreNotEqual (document.Notifications.Count, 0);
            Assert.AreEqual (document.IsValid (), false);
            Assert.AreEqual (document.IsInvalid (), true);
        }

        [TestMethod]
        [DataRow ("12345237890")]
        [DataRow ("12342367892")]
        [DataRow ("87834567895")]
        [DataRow ("90234567897")]
        public void ShouldReturnNotNotificationWhenDocumentIsValid (string number) {
            var document = new Document (number);
            Assert.AreEqual (document.Notifications?.Count, 0);
            Assert.AreEqual (document.IsValid (), true);
            Assert.AreEqual (document.IsInvalid (), false);
        }

    }
}