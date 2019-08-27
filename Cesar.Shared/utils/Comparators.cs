using System.Text.RegularExpressions;

namespace Cesar.Shared.utils
{
    public static class Comparators
    {
        public static bool IsGranThan(int valueToCompare, int valueComparator)
        {
            return valueToCompare > valueComparator ? true : false;            
        }
        public static bool IsGranThan(decimal valueToCompare, decimal valueComparator)
        {
            return valueToCompare > valueComparator ? true : false;            
        }
        public static bool IsLessThan(decimal valueToCompare, decimal valueComparator)
        {
            return !IsGranThan(valueToCompare, valueComparator);
        }
        public static bool IsLessThan(int valueToCompare, int valueComparator)
        {
            return !IsGranThan(valueToCompare, valueComparator);
        }
        public static bool IsEqual(int valueTocompare, int valueComparator)
        {
            return valueComparator == valueTocompare ? true : false;
        }
        public static bool IsLengthGranThan(string valueToCompare, int valueComparator)
        {
            return valueToCompare.Length > valueComparator ? true : false;
        }
        public static bool IsLengthLessThan(string valueToCompare, int valueComparator)
        {
            return !IsLengthGranThan(valueToCompare, valueComparator);
        }
        public static bool IsLengthEqualThan(string valueToCompare, int valueComparator)
        {
            return valueToCompare.Length == valueComparator ? true : false;
        }
        public static bool IsValidEmail(string email)
        {            
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}