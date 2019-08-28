using System;
using System.Collections.Generic;
using Cesar.Domain.CesarContext.Commands.CollaboratorComands.Input;
using Cesar.Domain.CesarContext.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cesar.Api.Controllers {
    public class CollaboratorController : Controller {

        [HttpGet]
        [Route ("collaborators")]
        public List<Collaborator> GetAll () {
            return null;
        }

        [HttpGet]
        [Route ("collaborators/{id}")]
        public Collaborator GetById (Guid id) {
            return null;
        }

        [HttpPost]
        [Route ("collaborators")]
        public Collaborator Post ([FromBody] CreateCollaboratorComand Collaborator) {
            return null;
        }

        [HttpPut]
        [Route ("collaborators/{id}")]
        public Collaborator Put ([FromBody] Collaborator Collaborator) {
            return null;
        }

        [HttpDelete]
        [Route ("collaborators/{id}")]
        public Collaborator Delete () {
            return null;
        }
    }
}