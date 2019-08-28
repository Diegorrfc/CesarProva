using Cesar.Shared;
using Cesar.Shared.Entities;
using Cesar.Shared.utils;

namespace Cesar.Domain.CesarContext.Entities
{
    public class Address : Entity
    {        
        private readonly int _MaximumLengthStreet = 15;
        private readonly int _MinimumLengthStreet = 5;
        private readonly int _MaximumLengthNumber = 30;
        private readonly int _MinimumLengthNumber = 0;
        private readonly int _MinimumLengthDistrict = 7;
        private readonly int _MaximumLengthDistrict = 15;
        private readonly int _MinimumLengthCity = 3;
        private readonly int _MaximumLengthCity = 10;
        private readonly int _MinimumLengthCountry = 5;
        private readonly int _MaximumLengthCountry = 10;
        private readonly int _MinimumLengthZipCode = 4;
        private readonly int _MaximumLengthZipCode = 11;
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

        public override string ToString()
        {
            return $"{Street} {Number}, {City} - {Country}";
        }
        private void _validations()
        {
            if (Comparators.IsLengthLessThan(Street, _MinimumLengthStreet))
                AddNotification(nameof(Street), $"O rua {Street} é inválido. Ele possui o tamamanho menor do que {_MinimumLengthStreet}");

            else if (Comparators.IsLengthGranThan(Street, _MaximumLengthStreet))
                AddNotification(nameof(Street), $"O rua {Street} é inválido. Ele possui o tamamanho maior do que {_MaximumLengthStreet}");

            if (Comparators.IsLengthLessThan(Number, _MinimumLengthNumber))
                AddNotification(nameof(Number), $"O número {Number} é inválido. Ele possui o tamamanho menor do que {_MinimumLengthNumber}");

            else if (Comparators.IsLengthGranThan(Number, _MaximumLengthNumber))
                AddNotification(nameof(Number), $"O número {Number} é inválido. Ele possui o tamamanho maior do que {_MaximumLengthNumber}");

            if (Comparators.IsLengthLessThan(District, _MinimumLengthDistrict))
                AddNotification(nameof(District), $"O Distrito {District} é inválido. Ele possui o tamamanho menor do que {_MinimumLengthDistrict}");
            else if (Comparators.IsLengthGranThan(District, _MaximumLengthDistrict))
                AddNotification(nameof(District), $"O Distrito {District} é inválido. Ele possui o tamamanho maior do que {_MaximumLengthDistrict}");

            if (Comparators.IsLengthLessThan(City, _MinimumLengthCity))
                AddNotification(nameof(City), $"A Cidade {City} é inválido. Ele possui o tamamanho menor do que {_MinimumLengthCity}");
            else if (Comparators.IsLengthGranThan(City, _MaximumLengthCity))
                AddNotification(nameof(City), $"A Cidade {City} é inválido. Ele possui o tamamanho maior do que {_MaximumLengthCity}");

            if (Comparators.IsLengthLessThan(Country, _MinimumLengthCountry))
                AddNotification(nameof(Country), $"O Pais {Country} é inválido. Ele possui o tamamanho menor do que {_MinimumLengthCountry}");
            else if (Comparators.IsLengthGranThan(Country, _MaximumLengthCountry))
                AddNotification(nameof(Country), $"O Pais {Country} é inválido. Ele possui o tamamanho maior do que {_MaximumLengthCountry}");

            if (Comparators.IsLengthLessThan(ZipCode, _MinimumLengthZipCode))
                AddNotification(nameof(ZipCode), $"O Código Postal {ZipCode} é inválido. Ele possui o tamamanho menor do que {_MinimumLengthZipCode}");
            else if (Comparators.IsLengthGranThan(ZipCode, _MaximumLengthZipCode))
                AddNotification(nameof(ZipCode), $"O Código Postal {ZipCode} é inválido. Ele possui o tamamanho maior do que {_MaximumLengthZipCode}");

        }
    }
}