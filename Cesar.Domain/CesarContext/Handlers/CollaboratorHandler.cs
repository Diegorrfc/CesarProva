using System;
using Cesar.Domain.CesarContext.Commands.CollaboratorComands.Input;
using Cesar.Domain.CesarContext.Commands.CollaboratorComands.Output;
using Cesar.Domain.CesarContext.Entities;
using Cesar.Domain.CesarContext.Repositories;
using Cesar.Domain.CesarContext.Services;
using Cesar.Domain.CesarContext.ValueObjects;
using Cesar.Shared.Comands;
using Cesar.Shared.Entities;

namespace Cesar.Domain.CesarContext.Handlers
{
    public class CollaboratorHandler : Notification, IComandHandler<CreateCollaboratorComand>,
        IComandHandler<UpdateCollaboratorComand>, IComandHandler<DeleteCollaboratorComand>
    {
        private readonly ICollaboratorRepository _collaboratorRepository;
        private readonly IEmailService _emailService;
        public CollaboratorHandler(ICollaboratorRepository CollaboratorRepository, IEmailService emailService)
        {
            _collaboratorRepository = CollaboratorRepository;
            _emailService = emailService;
        }
        public IComandResult Handle(CreateCollaboratorComand comand)
        {

            if (_collaboratorRepository.CheckDocument(comand.Document))
                AddNotification("Document", "Esse documento já está cadastrado");

            if (_collaboratorRepository.CheckEmail(comand.Email))
                AddNotification("Email", "Esse email já está cadastrado");

            var name = new Name(comand.FirstName, comand.LastName);
            var document = new Document(comand.Document);
            var email = new Email(comand.Email);
            var address = new Address(comand.Street, comand.Number, comand.District, comand.City, comand.Country, comand.ZipCode);
            var phone = new Phone(comand.Phone);
            var collaborator = new Collaborator(name, document, email, phone, address, comand.Salary, comand.ProjectName, comand.BirthDate, comand.JobTitle);

            AddNotifications(collaborator);
            AddNotifications(name);
            AddNotifications(document);
            AddNotifications(email);
            AddNotifications(address);
            AddNotifications(phone);

            if (IsInvalid())
                return null;

            _collaboratorRepository.Save(collaborator);

            return new CreateCollaboratorCommandResult(collaborator.Id, name.ToString(), email.Address);

        }
        public IComandResult Handle(UpdateCollaboratorComand comand)
        {
            var name = new Name(comand.FirstName, comand.LastName);
            var document = new Document(comand.Document);
            var email = new Email(comand.Email);
            var address = new Address(comand.Street, comand.Number, comand.District, comand.City, comand.Country, comand.ZipCode);
            var idAdd = _collaboratorRepository.Get(comand.Id).IdAddress;
            address.Id = idAdd;
            var phone = new Phone(comand.Phone);
            var collaborator = new Collaborator(name, document, email, phone, address, comand.Salary, comand.ProjectName, comand.BirthDate, comand.JobTitle)
            {
                Id = comand.Id
            };         
            
            AddNotifications(collaborator);
            AddNotifications(name);
            AddNotifications(document);
            AddNotifications(email);
            AddNotifications(address);
            AddNotifications(phone);
            if (IsInvalid())
                return null;

            _collaboratorRepository.Update(collaborator);

            return new CreateCollaboratorCommandResult(collaborator.Id, name.ToString(), email.Address);
        }

        public IComandResult Handle(DeleteCollaboratorComand comand)
        {
            DeleteCollaboratorCommandResult comandResult = new DeleteCollaboratorCommandResult();
            try
            {
                _collaboratorRepository.Delete(comand.Id);
            }
            catch (Exception ex)
            {
                AddNotification("Erro Delete", $"Erro ao excluir o usuário. Detalhe: {ex.Message}");
            }
            return comandResult;
        }
    }
}