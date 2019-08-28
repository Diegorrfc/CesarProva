using System;
using System.Collections.Generic;
using Cesar.Domain.CesarContext.Entities;

namespace Cesar.Domain.CesarContext.Repositories
{
    public interface ICollaboratorRepository
    {
         bool CheckDocument(string document);
         bool CheckEmail(string document);
         void Save(Collaborator collaborator);
         void Update(Collaborator collaborator);
         void Delete(Collaborator collaborator);
         List<Collaborator> GetAll();
         Collaborator Get(Guid guid);
    }
}