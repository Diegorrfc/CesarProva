using Cesar.Shared;
using Cesar.Shared.Entities;
using Cesar.Shared.utils;

namespace Cesar.Domain.CesarContext.ValueObjects
{
    public class Document : Notification
    {
        private readonly int _LengthDocument = 11;
        public Document(string number)
        {
            Number = number;
            if (!Comparators.IsLengthEqualThan(number, _LengthDocument))
                AddNotification(nameof(Number), $"O número do documento possui {number.Length}. Ele precisa ter o tamanho igual a {_LengthDocument}");
        }
        public string Number { get; private set; }

        public override string ToString()
        {
            return Number;
        }
    }
}