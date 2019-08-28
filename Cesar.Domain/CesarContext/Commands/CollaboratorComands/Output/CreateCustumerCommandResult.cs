using System;
using Cesar.Shared.Comands;

namespace Cesar.Domain.CesarContext.Commands.CollaboratorComands.Output {
    public class CreateCustumerCommandResult : IComandResult {
        public CreateCustumerCommandResult(){}
        public CreateCustumerCommandResult(Guid id, string name, string email)
        {
            Id = id;     
            Name = name;           
            Email = email;
           
        }

        public Guid Id { get; set; }
        public string Name { get; set; }      
        public string Email { get; set; } 
    }
}