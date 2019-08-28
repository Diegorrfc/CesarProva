using System.Text.RegularExpressions;
using Cesar.Shared;
using Cesar.Shared.Entities;
using Cesar.Shared.utils;

namespace Cesar.Domain.CesarContext.ValueObjects
{
    public class Email : Notification
    {
        protected Email()
        {

        }
        public Email(string address)
        {
            Address = address;
            if (!Comparators.IsValidEmail(Address))
                AddNotification("E-mail", $"O e-mail {Address} não possui um formato válido");
        }
        public class Constraints
        {
            public const int LengthEmail = 500;
        }
        public string Address { get; private set; }
        public override string ToString()
        {
            return Address;
        }

    }
}