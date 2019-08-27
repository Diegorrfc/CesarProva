using Cesar.Shared;
using Cesar.Shared.Entities;
using Cesar.Shared.utils;

namespace Cesar.Domain.CesarContext.Entities
{
    public class Address : Notification
    {
        private readonly int _MaximumLengthStreet = 200;
        private readonly int _MinimumLengthStreet = 5;
        private readonly int _MaximumLengthNumber = 300000;
        private readonly int _MinimumLengthNumber = 0;
        private readonly int _MinimumLengthDistrict = 7;
        private readonly int _MaximumLengthDistrict = 100;
        private readonly int _MinimumLengthCity = 3;
        private readonly int _MaximumLengthCity = 50;
        private readonly int _MinimumLengthCountry = 5;
        private readonly int _MaximumLengthCountry = 20;
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
                AddNotification("Street", $"O rua {Street} é inválido. Ele possui o tamamanho menor do que {_MinimumLengthStreet}");

            if (Comparators.IsLengthGranThan(Street, _MaximumLengthStreet))
                AddNotification("Street", $"O rua {Street} é inválido. Ele possui o tamamanho maior do que {_MaximumLengthStreet}");

            if (Comparators.IsLengthEqualThan(Number, _MinimumLengthNumber))
                AddNotification("PhoneNumber", $"O número {Number} é inválido. Ele possui o tamamanho menor do que {_MinimumLengthNumber}");

            if (Comparators.IsLengthGranThan(Number, _MaximumLengthNumber))
                AddNotification("PhoneNumber", $"O número {Number} é inválido. Ele possui o tamamanho maior do que {_MaximumLengthNumber}");

            if (Comparators.IsLengthEqualThan(District, _MinimumLengthDistrict))
                AddNotification("PhoneNumber", $"O Distritu {District} é inválido. Ele possui o tamamanho menor do que {_MinimumLengthNumber}");
            if (Comparators.IsLengthGranThan(District, _MaximumLengthDistrict))
                AddNotification("PhoneNumber", $"O Distrito {District} é inválido. Ele possui o tamamanho maior do que {_MaximumLengthNumber}");

            if (Comparators.IsLengthEqualThan(City, _MinimumLengthCity))
                AddNotification("PhoneNumber", $"A Cidade {City} é inválido. Ele possui o tamamanho menor do que {_MinimumLengthNumber}");
            if (Comparators.IsLengthGranThan(City, _MaximumLengthCity))
                AddNotification("PhoneNumber", $"A Cidade {City} é inválido. Ele possui o tamamanho maior do que {_MaximumLengthNumber}");

            if (Comparators.IsLengthEqualThan(Country, _MinimumLengthCountry))
                AddNotification("PhoneNumber", $"O Pais {Country} é inválido. Ele possui o tamamanho menor do que {_MinimumLengthNumber}");
            if (Comparators.IsLengthGranThan(Country, _MaximumLengthCountry))
                AddNotification("PhoneNumber", $"O Pais {Country} é inválido. Ele possui o tamamanho maior do que {_MaximumLengthNumber}");

            if (Comparators.IsLengthEqualThan(ZipCode, _MinimumLengthZipCode))
                AddNotification("PhoneNumber", $"O Código Postal {ZipCode} é inválido. Ele possui o tamamanho menor do que {_MinimumLengthNumber}");
            if (Comparators.IsLengthGranThan(ZipCode, _MaximumLengthZipCode))
                AddNotification("PhoneNumber", $"O Código Postal {ZipCode} é inválido. Ele possui o tamamanho maior do que {_MaximumLengthNumber}");

        }
    }
}