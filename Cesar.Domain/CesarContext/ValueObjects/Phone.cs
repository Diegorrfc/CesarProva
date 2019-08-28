using Cesar.Shared;
using Cesar.Shared.Entities;
using Cesar.Shared.utils;

namespace Cesar.Domain.CesarContext.ValueObjects
{
    public class Phone : Notification
    {
        private readonly int _MinimumLengthNumber = 6;
        private readonly int _MaximumLengthNumber = 12;
        public Phone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            if (Comparators.IsLengthLessThan(phoneNumber, _MinimumLengthNumber))
                AddNotification(nameof(PhoneNumber), $"O número do telefone {phoneNumber} é inválido. Ele possui o tamamanho menor do que {_MinimumLengthNumber}");
            else if (Comparators.IsLengthGranThan(phoneNumber, _MaximumLengthNumber))
                AddNotification(nameof(PhoneNumber), $"O número do telefone {phoneNumber} é inválido. Ele possui o tamamanho maior do que {_MaximumLengthNumber}");

        }
        public string PhoneNumber { get; private set; }
        public override string ToString()
        {
            return PhoneNumber;
        }

    }
}