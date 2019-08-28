using Cesar.Shared;
using Cesar.Shared.Entities;
using Cesar.Shared.utils;

namespace Cesar.Domain.CesarContext.ValueObjects
{
    public class Name : Notification
    {
        private readonly int _MaxLengthFirstName = 15;
        private readonly int _MinLengthFirstName = 5;
        private readonly int _MinLengthLastName = 5;
        private readonly int _MaxLengthLastName = 30;

        public Name(string firstname, string lastName)
        {
            FirstName = firstname;
            LastName = lastName;

            if (Comparators.IsLengthGranThan(FirstName, _MaxLengthFirstName))
                AddNotification(nameof(FirstName), $"O primeiro nome possui o tamanho {FirstName.Length}. Ele precisa ter o tamanho menor do que {_MaxLengthFirstName}");
            else if (Comparators.IsLengthLessThan(FirstName, _MinLengthFirstName))
                AddNotification(nameof(FirstName), $"O primeiro nome possui o tamanho {FirstName.Length}. Ele precisa ter o tamanho maior do que {_MinLengthFirstName}");
            if (Comparators.IsLengthGranThan(LastName, _MaxLengthLastName))
                AddNotification(nameof(LastName), $"O último nome possui o tamanho {FirstName.Length}. Ele precisa ter o tamanho menor do que {_MaxLengthFirstName}");
            else if (Comparators.IsLengthLessThan(LastName, _MinLengthLastName))
                AddNotification(nameof(LastName), $"O último nome possui o tamanho {FirstName.Length}. Ele precisa ter o tamanho maior do que {_MinLengthFirstName}");
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}