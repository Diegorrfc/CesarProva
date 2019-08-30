using System;
using Cesar.Domain.CesarContext.Enums;
using Cesar.Domain.CesarContext.ValueObjects;
using Cesar.Shared;
using Cesar.Shared.Entities;
using Cesar.Shared.utils;

namespace Cesar.Domain.CesarContext.Entities
{
    public class Collaborator : Entity
    {
       
        private readonly int _TIME_ZONE = -3;
       
        protected Collaborator()
        {

        }
        public Collaborator(
            Name name,
            Document document,
            Email email,
            Phone phone,
            Address address,
            decimal salary,
            string projectName,
            DateTime birthDate,
            string jobTitle)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            Address = address;
            IdAddress = address.Id;
            Salary = salary;
            ProjectName = projectName;
            BirthDate = birthDate;
            JobTitle = jobTitle;
            CreateDate = DateTime.UtcNow.AddHours(_TIME_ZONE);

            if (Comparators.IsLengthLessThan(projectName, Constraints.MinimumLengthProjectName))
                AddNotification(nameof(ProjectName), $"O nome do projeto {projectName} é inválido. Ele possui o tamamanho menor do que {Constraints.MinimumLengthProjectName}");
            else if (Comparators.IsLengthGranThan(projectName, Constraints.MaximumLengthProjectName))
                AddNotification(nameof(ProjectName), $"O nome do projeto {projectName} é inválido. Ele possui o tamamanho maior do que {Constraints.MaximumLengthProjectName}");
            if (Comparators.IsLessThan(Salary, Constraints.BaseSalary))
                AddNotification(nameof(Salary), $"O salário {Salary} é inválido. Ele é menor do que o piso salarial {Constraints.BaseSalary}");
            if (!Comparators.IsYearOldIsGreaterOrEqual18YearOld(BirthDate))
                AddNotification(nameof(BirthDate), $"O colaborador não poderá ser cadastrado, pois ele possui menos de 18 anos de idade");

        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        public DateTime BirthDate { get; private set; }
        public decimal Salary { get; private set; }
        public Guid IdAddress { get; private set; }
        public virtual Address Address { get; private set; }
        public string ProjectName { get; private set; }
        public string JobTitle { get; private set; }
        public DateTime CreateDate { get; private set; }

        public class Constraints
        {
            public const int MinimumLengthProjectName = 2;
            public const int MaximumLengthProjectName = 50;
            public const decimal BaseSalary = 1000;
        }
        public void AddAddress(Guid IdAddress)
        {
            this.IdAddress = IdAddress;
        }
        public override string ToString()
        {
            return Name.ToString();
        }
     
    }
}