using System;
using System.Collections.Generic;
using System.Text;
using Cesar.Domain.CesarContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cesar.Tests.Entities {
    [TestClass]
    [TestCategory ("Entities")]
    public class AddressTests {
        private string _wrongLessStreet = "rua";
        private string _wrongGreaterStreet = "raaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        private string _wrongLessNumber = null;
        private string _wrongLessDistrict = "recife";
        private string _wrongGreaterDistrict = "oooooooooooooooooooooooooooooooooo";
        private string _wrongLessCity = "die";
        private string _wrongGreaterCity = "oooooooooooooooooooooooooooooooooooo";
        private string _wrongGreaterCountry = "peqe";
        private string _wrongLessCountry = "peqkdafjjjjjdskdddddddddddddddddfd";
        private string _wrongLessZipCode = "zip";
        private string _wrongGreaterZipCode = "900909022342";
        public AddressTests () {

        }
        [TestMethod]
        public void ShouldReturnNotNotificationWhenAllPropertiesisIsValid()
        {
            int qtdNotifications = 0;

            var document = new Address(
                 ConstraintsCorrects.streetCorrect,
              ConstraintsCorrects.numberCorrect,
              ConstraintsCorrects.districtCorrect,
              ConstraintsCorrects.cityCorrect,
              ConstraintsCorrects.countryCorrect, ConstraintsCorrects.zipCodeCorrect);

            Assert.AreEqual(document.Notifications.Count, qtdNotifications);
            Assert.AreEqual(document.IsValid(), true);
            Assert.AreEqual(document.IsInvalid(), false);

        }
        [TestMethod]
        public void ShouldReturnSixNotificationWhenAllPropertiesisIsInvalid () {

            int qtdNotifications = 6;
            var document = new Address (_wrongGreaterStreet, _wrongLessNumber, _wrongGreaterDistrict, _wrongGreaterCity, _wrongGreaterCountry, _wrongGreaterZipCode);
            Assert.AreEqual (document.Notifications.Count, qtdNotifications);
            Assert.AreEqual (document.IsValid (), false);
            Assert.AreEqual (document.IsInvalid (), true);
        }

        [TestMethod]        
        public void ShouldReturnOneNotificationWhenZipCodeIsInValid () {

            int qtdNotifications = 1;
            
            var document = new Address (
                ConstraintsCorrects.streetCorrect,
             ConstraintsCorrects.numberCorrect, 
             ConstraintsCorrects.districtCorrect, 
             ConstraintsCorrects.cityCorrect,
             ConstraintsCorrects.countryCorrect, _wrongGreaterZipCode);
            
            Assert.AreEqual (document.Notifications.Count, qtdNotifications);
            Assert.AreEqual (document.IsValid (), false);
            Assert.AreEqual (document.IsInvalid (), true);
        }

        [TestMethod]      
        public void ShouldReturnOneNotificationWhenCountryContryisInvalid() {

            int qtdNotifications = 1;
            
            var document = new Address (
                ConstraintsCorrects.streetCorrect,
             ConstraintsCorrects.numberCorrect, 
             ConstraintsCorrects.districtCorrect, 
             ConstraintsCorrects.cityCorrect,
            _wrongGreaterCountry, ConstraintsCorrects.zipCodeCorrect);
            
            Assert.AreEqual (document.Notifications.Count, qtdNotifications);
            Assert.AreEqual (document.IsValid (), false);
            Assert.AreEqual (document.IsInvalid (), true);
        }

        [TestMethod]      
        public void ShouldReturnOneNotificationWhenCityIsInvalid() {

            int qtdNotifications = 1;
            
            var document = new Address (
                ConstraintsCorrects.streetCorrect,
             ConstraintsCorrects.numberCorrect, 
             ConstraintsCorrects.districtCorrect, 
             _wrongGreaterCity,
            ConstraintsCorrects.countryCorrect, ConstraintsCorrects.zipCodeCorrect);
            
            Assert.AreEqual (document.Notifications.Count, qtdNotifications);
            Assert.AreEqual (document.IsValid (), false);
            Assert.AreEqual (document.IsInvalid (), true);
        }

        [TestMethod]      
        public void ShouldReturnOneNotificationWhenDistrictIsInvalid() {

            int qtdNotifications = 1;
            
            var document = new Address (
                ConstraintsCorrects.streetCorrect,
             ConstraintsCorrects.numberCorrect, 
             _wrongGreaterDistrict, 
             ConstraintsCorrects.cityCorrect,
            ConstraintsCorrects.countryCorrect, ConstraintsCorrects.zipCodeCorrect);
            
            Assert.AreEqual (document.Notifications.Count, qtdNotifications);
            Assert.AreEqual (document.IsValid (), false);
            Assert.AreEqual (document.IsInvalid (), true);
        }
        [TestMethod]
        public void ShouldReturnOneNotificationWhenNumberIsInvalid() {

            int qtdNotifications = 1;
            
            var document = new Address (
                ConstraintsCorrects.streetCorrect,
             _wrongLessNumber, 
             ConstraintsCorrects.districtCorrect, 
             ConstraintsCorrects.cityCorrect,
            ConstraintsCorrects.countryCorrect, ConstraintsCorrects.zipCodeCorrect);
            
            Assert.AreEqual (document.Notifications.Count, qtdNotifications);
            Assert.AreEqual (document.IsValid (), false);
            Assert.AreEqual (document.IsInvalid (), true);
        }
        [TestMethod]
        public void ShouldReturnOneNotificationWhenStreetIsInvalid() {

            int qtdNotifications = 1;
            
            var document = new Address (
                _wrongGreaterStreet,
             ConstraintsCorrects.numberCorrect, 
             ConstraintsCorrects.districtCorrect, 
             ConstraintsCorrects.cityCorrect,
            ConstraintsCorrects.countryCorrect, ConstraintsCorrects.zipCodeCorrect);
            
            Assert.AreEqual (document.Notifications.Count, qtdNotifications);
            Assert.AreEqual (document.IsValid (), false);
            Assert.AreEqual (document.IsInvalid (), true);
        }

        public static class ConstraintsCorrects{
            public const string streetCorrect = "São Paulo";
            public const string numberCorrect = "100";
            public const string districtCorrect = "Parnamirim";
            public const string cityCorrect = "São paulo";
            public const string countryCorrect = "Brasil";
            public const string zipCodeCorrect = "42102002";
        }
    }
}