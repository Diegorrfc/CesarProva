using Cesar.Shared;
using Cesar.Shared.Entities;
using Cesar.Shared.utils;

namespace Cesar.Domain.CesarContext.ValueObjects
{
    public class Name : Notification
    {
        protected Name()
        {

        }
        public Name(string firstname, string lastName)
        {
            FirstName = firstname;
            LastName = lastName;

            if (Comparators.IsLengthGranThan(FirstName, Constraints.MaxLengthFirstName))
                AddNotification(nameof(FirstName), $"O primeiro nome possui o tamanho {FirstName.Length}. Ele precisa ter o tamanho menor do que {Constraints.MaxLengthFirstName}");
            else if (Comparators.IsLengthLessThan(FirstName, Constraints.MinLengthFirstName))
                AddNotification(nameof(FirstName), $"O primeiro nome possui o tamanho {FirstName.Length}. Ele precisa ter o tamanho maior do que {Constraints.MinLengthFirstName}");
            if (Comparators.IsLengthGranThan(LastName, Constraints.MaxLengthLastName))
                AddNotification(nameof(LastName), $"O último nome possui o tamanho {FirstName.Length}. Ele precisa ter o tamanho menor do que {Constraints.MaxLengthFirstName}");
            else if (Comparators.IsLengthLessThan(LastName, Constraints.MinLengthLastName))
                AddNotification(nameof(LastName), $"O último nome possui o tamanho {FirstName.Length}. Ele precisa ter o tamanho maior do que {Constraints.MinLengthFirstName}");
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public class Constraints
        {
            public const int MaxLengthFirstName = 15;
            public const int MinLengthFirstName = 5;
            public const int MinLengthLastName = 5;
            public const int MaxLengthLastName = 30;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}