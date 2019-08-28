using Cesar.Shared;
using Cesar.Shared.Entities;
using Cesar.Shared.utils;

namespace Cesar.Domain.CesarContext.ValueObjects
{
    public class Document : Notification
    {
        protected Document()
        {

        }
        public Document(string number)
        {
            Number = number;
            if (!Comparators.IsLengthEqualThan(number, Constraints.LengthDocument))
                AddNotification(nameof(Number), $"O número do documento possui {number.Length}. Ele precisa ter o tamanho igual a {Constraints.LengthDocument}");
        }
        public string Number { get; private set; }

        public class Constraints
        {
            public const int LengthDocument = 11;            
        }
        public override string ToString()
        {
            return Number;
        }
    }
}