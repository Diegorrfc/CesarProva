using System;
using Cesar.Shared.Comands;

namespace Cesar.Domain.CesarContext.Commands.CollaboratorComands.Input {
    public class AddAddressComand : IComand{
        public Guid Id { get; set; }
        public string Number { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
    }
}