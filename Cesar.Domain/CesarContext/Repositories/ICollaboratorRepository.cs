using System;
using System.Collections.Generic;
using Cesar.Domain.CesarContext.Dtos;
using Cesar.Domain.CesarContext.Entities;

namespace Cesar.Domain.CesarContext.Repositories
{
    public interface ICollaboratorRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string document);
        void Save(Collaborator collaborator);
        void Update(Collaborator collaborator);
        void Delete(Guid Id);
        List<GetCollaboratorDto> GetAll();
        GetCollaboratorDto Get(Guid guid);
    }
}