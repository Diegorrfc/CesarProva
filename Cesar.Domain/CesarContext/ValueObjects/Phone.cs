using Cesar.Shared;
using Cesar.Shared.Entities;
using Cesar.Shared.utils;

namespace Cesar.Domain.CesarContext.ValueObjects
{
    public class Phone : Notification
    {
        protected Phone() { }
        public Phone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            if (Comparators.IsLengthLessThan(phoneNumber, Constraints.MinimumLengthNumber))
                AddNotification(nameof(PhoneNumber), $"O número do telefone {phoneNumber} é inválido. Ele possui o tamamanho menor do que {Constraints.MinimumLengthNumber}");
            else if (Comparators.IsLengthGranThan(phoneNumber, Constraints.MaximumLengthNumber))
                AddNotification(nameof(PhoneNumber), $"O número do telefone {phoneNumber} é inválido. Ele possui o tamamanho maior do que {Constraints.MaximumLengthNumber}");

        }
        public string PhoneNumber { get; private set; }
        public class Constraints
        {
            public const int MinimumLengthNumber = 6;
            public const int MaximumLengthNumber = 12;
        }
        public override string ToString()
        {           
            return PhoneNumber;
        }

    }
}