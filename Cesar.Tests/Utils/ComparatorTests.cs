using Cesar.Shared.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Cesar.Tests.Utils {
    [TestClass]
    [TestCategory("Utils")]
    public class ComparatorTests {
        [TestMethod]
        [DataRow (10, 15)]
        [DataRow (-10, -9)]
        [DataRow (0, 10)]
        public void ShouldReturnFalseWhenValueToCompareIsLessValueComparator (int valueToCompare, int ValueComparator) {
            bool result = Comparators.IsGranThan (valueToCompare, ValueComparator);
            Assert.AreEqual (result, false);
        }

        [TestMethod]
        [DataRow (15, 10)]
        [DataRow (-9, -10)]
        [DataRow (10, 0)]
        public void ShouldReturnTrueWhenValueToCompareIsLessValueComparator (int valueToCompare, int ValueComparator) {
            bool result = Comparators.IsGranThan (valueToCompare, ValueComparator);
            Assert.AreEqual (result, true);
        }

        [TestMethod]
        [DataRow (34, 15)]
        [DataRow (12, 46)]
        [DataRow (1, 2)]
        public void ShouldReturnFalseWhenValueToCompareIsEqualValueComparator (int valueToCompare, int ValueComparator) {
            bool result = Comparators.IsEqual (valueToCompare, ValueComparator);
            Assert.AreEqual (result, false);
        }

        [TestMethod]
        [DataRow (10, 10)]
        [DataRow (5, 5)]
        [DataRow (-10, -10)]
        public void ShouldReturnTrueWhenValueToCompareIsEqualValueComparator (int valueToCompare, int ValueComparator) {
            bool result = Comparators.IsEqual (valueToCompare, ValueComparator);
            Assert.AreEqual (result, true);
        }

        [TestMethod]
        [DataRow ("Diego", 10)]
        [DataRow ("Cesar", 6)]
        [DataRow ("Cachorro", 7)]
        public void ShouldReturnFalseWhenValueToCompareLengthIsNotEqualWithValueComparator (string valueToCompare, int ValueComparator) {
            bool result = Comparators.IsLengthEqualThan (valueToCompare, ValueComparator);
            Assert.AreEqual (result, false);
        }

        [TestMethod]
        [DataRow ("Diego", 5)]
        [DataRow ("Cesar",5)]
        [DataRow ("Cachorro", 8)]
        public void ShouldReturnTrueWhenValueToCompareLengthIsEqualWithValueComparator (string valueToCompare, int ValueComparator) {
            bool result = Comparators.IsLengthEqualThan (valueToCompare, ValueComparator);
            Assert.AreEqual (result, true);
        }

        [TestMethod]
        [DataRow ("POrto Digital", 15)]
        [DataRow ("Recife antigo", 16)]
        [DataRow ("Boa viagem", 20)]
        public void ShouldReturnFalseWhenValueToCompareLengthIsLessValueComparator (string valueToCompare, int ValueComparator) {
            bool result = Comparators.IsLengthGranThan (valueToCompare, ValueComparator);
            Assert.AreEqual (result, false);
        }
        [TestMethod]
        [DataRow ("POrto Digital", 3)]
        [DataRow ("Recife antigo", 6)]
        [DataRow ("Boa viagem", 7)]
        public void ShouldReturnTrueWhenValueToCompareLengthIsGranValueComparator (string valueToCompare, int ValueComparator) {
            bool result = Comparators.IsLengthGranThan (valueToCompare, ValueComparator);
            Assert.AreEqual (result, true);
        }

        [TestMethod]
        [DataRow ("Caetano veloso", 12)]
        [DataRow ("Djavan", 5)]
        [DataRow ("Queen", 3)]
        public void ShouldReturnFalseWhenValueToCompareLenghIsGrandValueComparator (string valueToCompare, int ValueComparator) {
            bool result = Comparators.IsLengthLessThan (valueToCompare, ValueComparator);
            Assert.AreEqual (result, false);
        }
        [TestMethod]
        [DataRow ("Caetano veloso", 34)]
        [DataRow ("Djavan", 14)]
        [DataRow ("Queen", 9)]
        public void ShouldReturnTrueWhenValueToCompareLenghIsLessValueComparator (string valueToCompare, int ValueComparator) {
            bool result = Comparators.IsLengthLessThan (valueToCompare, ValueComparator);
            Assert.AreEqual (result, true);
        }

        [TestMethod]
        [DataRow (230, 15)]
        [DataRow (-6, -7)]
        [DataRow (11, 10)]
        public void ShouldReturnFalseWhenValueToCompareIsGrandValueComparator (int valueToCompare, int ValueComparator) {
            bool result = Comparators.IsLessThan (valueToCompare, ValueComparator);
            Assert.AreEqual (result, false);
        }
         [TestMethod]
        [DataRow (15, 56)]
        [DataRow (-6, -4)]
        [DataRow (4, 10)]
        public void ShouldReturntrueWhenValueToCompareIsLessValueComparator (int valueToCompare, int ValueComparator) {
            bool result = Comparators.IsLessThan (valueToCompare, ValueComparator);
            Assert.AreEqual (result, true);
        }

        [TestMethod]
        [DataRow ("diego.rrfc@gmailm")]
        [DataRow ("drrfc@ecomp.")]
        [DataRow ("imaginario@uol.com.")]
        [DataRow ("@uol.com.br")]
        [DataRow ("imagin-ariouo-oil.com.br.")]
        public void ShouldReturnFalseWhenEmailIsInvalid (string email) {
            bool result = Comparators.IsValidEmail (email);
            Assert.AreEqual (result, false);
        }

        [TestMethod]
        [DataRow ("diego.rrfc@gmail.com")]
        [DataRow ("drrfc@ecomp.poli.br")]
        [DataRow ("imaginario@uol.com")]
        [DataRow ("imagin-ario@uol.com.br")]
        [DataRow ("imagin-ario@uo-oil.com.br")]
        public void ShouldReturntrueWhenEmailIsValid (string email) {
            bool result = Comparators.IsValidEmail (email);
            Assert.AreEqual (result, true);
        }

    }
}