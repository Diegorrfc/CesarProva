using Cesar.Shared.Comands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cesar.Domain.CesarContext.Commands.CollaboratorComands.Input
{
    public class DeleteCollaboratorComand : IComand
    {
        public Guid Id { get; set; }
    }
}
