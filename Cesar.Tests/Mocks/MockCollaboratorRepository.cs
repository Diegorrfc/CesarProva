using System;
using System.Collections.Generic;
using Cesar.Domain.CesarContext.Dtos;
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

        public void Delete(Guid collaborator)
        {
            
        }

        public GetCollaboratorDto Get(Guid guid)
        {
            return null;
        }

        public List<GetCollaboratorDto> GetAll()
        {
            return null;
        }

        public void Save(Collaborator collaborator)
        {
           
        }

        public void Update(Collaborator collaborator)
        {
            
        }
    }
}