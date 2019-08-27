using System.Text.RegularExpressions;
using Cesar.Shared;
using Cesar.Shared.Entities;
using Cesar.Shared.utils;

namespace Cesar.Domain.CesarContext.ValueObjects
{
    public class Email : Notification
    {
        public Email(string address)
        {
            Address = address;
            if (!Comparators.IsValidEmail(Address))
                AddNotification("Email", $"O e-mail {Address} não possui um formato válido");
        }
        public string Address { get; private set; }
        public override string ToString()
        {
            return Address;
        }

    }
}