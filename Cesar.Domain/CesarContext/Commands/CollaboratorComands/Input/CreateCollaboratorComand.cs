using System;
using Cesar.Domain.CesarContext.Entities;
using Cesar.Shared.Comands;

namespace Cesar.Domain.CesarContext.Commands.CollaboratorComands.Input {
    public class CreateCollaboratorComand : IComand {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public string ProjectName { get; set; }
        public DateTime birthDate { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string JobTitle { get; set; }

    }
}