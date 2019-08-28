using System;
using System.Collections.Generic;
using Cesar.Domain.CesarContext.Entities;
using Cesar.Domain.CesarContext.Repositories;

namespace Cesar.Tests.Mocks
{
    public class MockCollaboratorRepository : ICollaboratorRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string document)
        {
            return false;
        }

        public void Delete(Collaborator collaborator)
        {
            
        }

        public Collaborator Get(Guid guid)
        {
           return null;
        }

        public List<Collaborator> GetAll()
        {
            return null;
        }

        public void Save(Collaborator collaborator)
        {
            throw new NotImplementedException();
        }

        public void Update(Collaborator collaborator)
        {
            throw new NotImplementedException();
        }
    }
}