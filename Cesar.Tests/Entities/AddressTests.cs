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
        private string _wrongGranStreet = "raaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        private string _wrongLessNumber = null;
        private string _wrongLessDistrict = "recife";
        private string _wrongGranDistrict = "oooooooooooooooooooooooooooooooooo";
        private string _wrongLessCity = "die";
        private string _wrongGranCity = "oooooooooooooooooooooooooooooooooooo";
        private string _wrongGrandCountry = "peqe";
        private string _wrongLessCountry = "peqkdafjjjjjdskdddddddddddddddddfd";
        private string _wrongLessZipCode = "zip";
        private string _wrongGranZipCode = "900909022342";
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
            var document = new Address (_wrongGranStreet, _wrongLessNumber, _wrongGranDistrict, _wrongGranCity, _wrongGrandCountry, _wrongGranZipCode);
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
             ConstraintsCorrects.countryCorrect, _wrongGranZipCode);
            
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
            _wrongGrandCountry, ConstraintsCorrects.zipCodeCorrect);
            
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
             _wrongGranCity,
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
             _wrongGranDistrict, 
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
                _wrongGranStreet,
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