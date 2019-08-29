using System;
using System.Collections.Generic;
using System.Text;

namespace Cesar.Domain.CesarContext.Dtos
{
    public class GetCollaboratorDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public string ProjectName { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid IdAddress { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string JobTitle { get; set; }
    }
}
