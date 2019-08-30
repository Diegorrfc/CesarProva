using Cesar.Shared;
using Cesar.Shared.Entities;
using Cesar.Shared.utils;
using System;

namespace Cesar.Domain.CesarContext.Entities
{
    public class Address : Entity
    {
        protected Address() { }
        public Address(string street, string number, string district, string city, string country, string zipCode)
        {
            Street = street;
            Number = number;
            District = district;
            City = city;
            Country = country;
            ZipCode = zipCode;
            _validations();

        }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        //public Guid IdCollaborator { get; private set; }
        public virtual Collaborator Collaborator { get; private set; }
        public override string ToString()
        {
            return $"{Street} {Number}, {City} - {Country}";
        }
        public class Constraints
        {
            public const int MaximumLengthStreet = 30;
            public const int MinimumLengthStreet = 5;
            public const int MaximumLengthNumber = 12;
            public const int MinimumLengthNumber = 1;
            public const int MinimumLengthDistrict = 5;
            public const int MaximumLengthDistrict = 15;
            public const int MinimumLengthCity = 3;
            public const int MaximumLengthCity = 15;
            public const int MinimumLengthCountry = 5;
            public const int MaximumLengthCountry = 15;
            public const int MinimumLengthZipCode = 4;
            public const int MaximumLengthZipCode = 11;            
        }
        private void _validations()
        {
            if (Comparators.IsLengthLessThan(Street, Constraints.MinimumLengthStreet))
                AddNotification(nameof(Street), $"O rua {Street} é inválido. Ele possui o tamamanho menor do que {Constraints.MinimumLengthStreet}");

            else if (Comparators.IsLengthGranThan(Street, Constraints.MaximumLengthStreet))
                AddNotification(nameof(Street), $"O rua {Street} é inválido. Ele possui o tamamanho maior do que {Constraints.MaximumLengthStreet}");

            if (Comparators.IsLengthLessThan(Number, Constraints.MinimumLengthNumber))
                AddNotification(nameof(Number), $"O número {Number} é inválido. Ele possui o tamamanho menor do que {Constraints.MinimumLengthNumber}");

            else if (Comparators.IsLengthGranThan(Number, Constraints.MaximumLengthNumber))
                AddNotification(nameof(Number), $"O número {Number} é inválido. Ele possui o tamamanho maior do que {Constraints.MaximumLengthNumber}");

            if (Comparators.IsLengthLessThan(District, Constraints.MinimumLengthDistrict))
                AddNotification(nameof(District), $"O Distrito {District} é inválido. Ele possui o tamamanho menor do que {Constraints.MinimumLengthDistrict}");
            else if (Comparators.IsLengthGranThan(District, Constraints.MaximumLengthDistrict))
                AddNotification(nameof(District), $"O Distrito {District} é inválido. Ele possui o tamamanho maior do que {Constraints.MaximumLengthDistrict}");

            if (Comparators.IsLengthLessThan(City, Constraints.MinimumLengthCity))
                AddNotification(nameof(City), $"A Cidade {City} é inválido. Ele possui o tamamanho menor do que {Constraints.MinimumLengthCity}");
            else if (Comparators.IsLengthGranThan(City, Constraints.MaximumLengthCity))
                AddNotification(nameof(City), $"A Cidade {City} é inválido. Ele possui o tamamanho maior do que {Constraints.MaximumLengthCity}");

            if (Comparators.IsLengthLessThan(Country, Constraints.MinimumLengthCountry))
                AddNotification(nameof(Country), $"O Pais {Country} é inválido. Ele possui o tamamanho menor do que {Constraints.MinimumLengthCountry}");
            else if (Comparators.IsLengthGranThan(Country, Constraints.MaximumLengthCountry))
                AddNotification(nameof(Country), $"O Pais {Country} é inválido. Ele possui o tamamanho maior do que {Constraints.MaximumLengthCountry}");

            if (Comparators.IsLengthLessThan(ZipCode, Constraints.MinimumLengthZipCode))
                AddNotification(nameof(ZipCode), $"O Código Postal {ZipCode} é inválido. Ele possui o tamamanho menor do que {Constraints.MinimumLengthZipCode}");
            else if (Comparators.IsLengthGranThan(ZipCode, Constraints.MaximumLengthZipCode))
                AddNotification(nameof(ZipCode), $"O Código Postal {ZipCode} é inválido. Ele possui o tamamanho maior do que {Constraints.MaximumLengthZipCode}");

        }
    }
}