using Cesar.Domain.CesarContext.Entities;
using Cesar.Domain.CesarContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cesar.Tests.ValueObjects {
    [TestClass]
    [TestCategory("ValueObject")]
    public class EmailTest {

        [TestMethod]
        [DataRow ("diego.rrfc.gmail.com")]       
        [DataRow ("exemplo.felix@uol")]
        [DataRow ("juiz.coisa@you.")]
        [DataRow ("@you.com")]
        [DataRow ("@you..br")]
        [DataRow ("@you.br")]
        [DataRow ("DIEGO.RRFC@GMAIL.COM.")]
        public void ShouldReturnNotificationWhenDocumentIsNotValid (string email) {
            var document = new Email (email);
            Assert.AreNotEqual (document.Notifications.Count, 0);
            Assert.AreEqual (document.IsValid (), false);
            Assert.AreEqual (document.IsInvalid (), true);
        }

        [TestMethod]
        [DataRow ("diego.rrfc@gmail.com")]
        [DataRow ("casa@diego.com.br")]
        [DataRow ("exemplo.felix@uol.com")]
        [DataRow ("juiz.coisa@you.com")]
        public void ShouldReturnNotNotificationWhenDocumentIsValid (string email) {
            var document = new Email (email);
            Assert.AreEqual (document.Notifications?.Count, 0);
            Assert.AreEqual (document.IsValid (), true);
            Assert.AreEqual (document.IsInvalid (), false);
        }
    }
}