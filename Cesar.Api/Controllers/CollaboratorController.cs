using System;
using System.Collections.Generic;
using Cesar.Domain.CesarContext.Commands.CollaboratorComands.Input;
using Cesar.Domain.CesarContext.Commands.CollaboratorComands.Output;
using Cesar.Domain.CesarContext.Dtos;
using Cesar.Domain.CesarContext.Entities;
using Cesar.Domain.CesarContext.Handlers;
using Cesar.Domain.CesarContext.Repositories;
using Cesar.Shared.Comands;
using Microsoft.AspNetCore.Mvc;

namespace Cesar.Api.Controllers
{
    public class CollaboratorController : Controller
    {
        private readonly ICollaboratorRepository _collaboratorRepository;
        private readonly CollaboratorHandler _collaboratorHandler;
        public CollaboratorController(ICollaboratorRepository collaboratorRepository, CollaboratorHandler collaboratorHandler)
        {
            _collaboratorHandler = collaboratorHandler;
            _collaboratorRepository = collaboratorRepository;
        }

        [HttpGet]
        [Route("collaborators")]
        public List<GetCollaboratorDto> GetAll()
        {
            return _collaboratorRepository.GetAll();
        }

        [HttpGet]
        [Route("collaborators/{id}")]
        public GetCollaboratorDto GetById(Guid id)
        {
            return _collaboratorRepository.Get(id);
        }

        [HttpPost]
        [Route("collaborators")]
        public ResultDto Post([FromBody]CreateCollaboratorComand Collaborator)
        {
            ResultDto resultDto;
            var result = (CreateCollaboratorCommandResult)_collaboratorHandler.Handle(Collaborator);
            if (_collaboratorHandler.IsValid())
                resultDto = new ResultDto(_collaboratorHandler.IsValid(), "Usuário criado com sucesso", result);
            else
                resultDto = new ResultDto(_collaboratorHandler.IsValid(), "Não foi possível criar o usuário", _collaboratorHandler.Notifications);

            return resultDto;
        }

        [HttpPut]
        [Route("collaborators/{id}")]
        public ResultDto Put([FromBody] UpdateCollaboratorComand Collaborator)
        {
            ResultDto resultDto;
            var result = (CreateCollaboratorCommandResult)_collaboratorHandler.Handle(Collaborator);
            if (_collaboratorHandler.IsValid())
                resultDto = new ResultDto(_collaboratorHandler.IsValid(), "Usuário atualizado com sucesso", result);
            else
                resultDto = new ResultDto(_collaboratorHandler.IsValid(), "Não foi possível atualizar o usuário", _collaboratorHandler.Notifications);
            return resultDto;
        }

        [HttpDelete]
        [Route("collaborators/{id}")]
        public ResultDto Delete(Guid id)
        {
            ResultDto resultDto;
            DeleteCollaboratorComand delete = new DeleteCollaboratorComand();
            delete.Id = id;
            var result = (DeleteCollaboratorCommandResult)_collaboratorHandler.Handle(delete);
            if (_collaboratorHandler.IsValid())
                resultDto = new ResultDto(_collaboratorHandler.IsValid(), "Usuário deletado com sucesso", result);
            else
                resultDto = new ResultDto(_collaboratorHandler.IsValid(), "Não foi possível atualizar o usuário", _collaboratorHandler.Notifications);

            return resultDto;

        }
    }
}