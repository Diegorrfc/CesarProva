using System;
using System.Text.RegularExpressions;

namespace Cesar.Shared.utils
{
    public static class Comparators
    {
        public static bool IsGreaterThan(int valueToCompare, int valueComparator)
        {
            return valueToCompare > valueComparator ? true : false;
        }
        public static bool IsGreaterThan(decimal valueToCompare, decimal valueComparator)
        {
            return valueToCompare > valueComparator ? true : false;
        }
        public static bool IsYearOldIsGreaterOrEqual18YearOld(DateTime date)
        {
            int valorToCompare = 18;
            DateTime dateNow = DateTime.Now;
            var years = dateNow.Subtract(date).TotalDays / 365.0;            
            return years > valorToCompare ? true : false;
        }
        public static bool IsLessThan(decimal valueToCompare, decimal valueComparator)
        {
            return valueToCompare < valueComparator ? true : false;
        }
        public static bool IsLessThan(int valueToCompare, int valueComparator)
        {
            return valueToCompare < valueComparator ? true : false;
        }
        public static bool IsEqual(int valueTocompare, int valueComparator)
        {
            return valueComparator == valueTocompare ? true : false;
        }
        public static bool IsLengthGranThan(string valueToCompare, int valueComparator)
        {
            return (valueToCompare?.Length > valueComparator && valueToCompare?.Length != null) ? true : false;
        }
        public static bool IsLengthLessThan(string valueToCompare, int valueComparator)
        {
            return (valueToCompare?.Length < valueComparator || valueToCompare?.Length == null) ? true : false;
        }
        public static bool IsLengthEqualThan(string valueToCompare, int valueComparator)
        {
            return (valueToCompare?.Length != valueComparator) ? false : true;
        }
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}