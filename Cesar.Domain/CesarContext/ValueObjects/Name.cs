using Cesar.Shared;
using Cesar.Shared.Entities;
using Cesar.Shared.utils;

namespace Cesar.Domain.CesarContext.ValueObjects
{
    public class Name : Notification
    {
        private readonly int _MaxLengthFirstName = 15;
        private readonly int _MinLengthFirstName = 2;
        private readonly int _MinLengthLastName = 5;
        private readonly int _MaxLengthLastName = 50;

        public Name(string firstname, string lastName)
        {
            FirstName = firstname;
            LastName = lastName;

            if (!Comparators.IsLengthGranThan("FirstName", _MaxLengthFirstName))
                AddNotification("FirstName", $"O primeiro nome possui o tamanho {FirstName.Length}. Ele precisa ter o tamanho menor do que {_MaxLengthFirstName}");
            if (!Comparators.IsLengthLessThan("FirstName", _MinLengthFirstName))
                AddNotification("FirstName", $"O primeiro nome possui o tamanho {FirstName.Length}. Ele precisa ter o tamanho maior do que {_MinLengthFirstName}");
            if (!Comparators.IsLengthGranThan("LastName", _MaxLengthLastName))
                AddNotification("FirstName", $"O último nome possui o tamanho {FirstName.Length}. Ele precisa ter o tamanho menor do que {_MaxLengthFirstName}");
            if (!Comparators.IsLengthLessThan("LastName", _MinLengthLastName))
                AddNotification("FirstName", $"O último nome possui o tamanho {FirstName.Length}. Ele precisa ter o tamanho maior do que {_MinLengthFirstName}");
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}