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
        //SOLID
        //S - SÓ TEM COISAS NO COLABORADOR
        //O - ABERTA PARA A EXTENSÃO, FECHADA PARA MODIFICAÇÃO (PRIVATE), SÓ ELA SABE MODIFICAR O ESTADO DELA
        //L - 
        private readonly int _TIME_ZONE = -3;
        private readonly int _MinimumLengthProjectName = 2;
        private readonly int _MaximumLengthProjectName = 50;
        private readonly decimal _BaseSalary = 1000;
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
            Salary = salary;
            ProjectName = projectName;
            BirthDate = birthDate;
            JobTitle = jobTitle;
            CreateDate = DateTime.UtcNow.AddHours(_TIME_ZONE);
            if (Comparators.IsLengthLessThan(projectName, _MinimumLengthProjectName))
                AddNotification(nameof(ProjectName), $"O nome do projeto {projectName} é inválido. Ele possui o tamamanho menor do que {_MinimumLengthProjectName}");
            else if (Comparators.IsLengthGranThan(projectName, _MaximumLengthProjectName))
                AddNotification(nameof(ProjectName), $"O nome do projeto {projectName} é inválido. Ele possui o tamamanho maior do que {_MaximumLengthProjectName}");
            if (Comparators.IsLessThan(Salary, _BaseSalary))
                AddNotification(nameof(Salary), $"O salário {Salary} é inválido. Ele é menor do que o piso salarial {_BaseSalary}");
            
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        public DateTime BirthDate { get; private set; }
        public decimal Salary { get; private set; }
        public Address Address { get; private set; }
        public string ProjectName { get; private set; }
        public string JobTitle { get; private set; }
        public DateTime CreateDate { get; private set; }

        public override string ToString()
        {
            return Name.ToString();
        }
     
    }
}