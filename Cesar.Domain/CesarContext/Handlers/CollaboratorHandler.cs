using System;
using Cesar.Domain.CesarContext.Commands.CollaboratorComands.Input;
using Cesar.Domain.CesarContext.Commands.CollaboratorComands.Output;
using Cesar.Domain.CesarContext.Entities;
using Cesar.Domain.CesarContext.Repositories;
using Cesar.Domain.CesarContext.Services;
using Cesar.Domain.CesarContext.ValueObjects;
using Cesar.Shared.Comands;
using Cesar.Shared.Entities;

namespace Cesar.Domain.CesarContext.Handlers {
    public class CollaboratorHandler : Notification, IComandHandler<CreateCollaboratorComand>,
        IComandHandler<AddAddressComand> {
            private readonly ICollaboratorRepository _collaboratorRepository;
            private readonly IEmailService _emailService;
            public CollaboratorHandler (ICollaboratorRepository CollaboratorRepository, IEmailService emailService) {
                _collaboratorRepository = CollaboratorRepository;
                _emailService = emailService;
            }
            public IComandResult Handle (CreateCollaboratorComand comand) {

                //verirficar se o document já existe
                if (_collaboratorRepository.CheckDocument (comand.Document))
                    AddNotification ("Document", "Esse documento já está cadastrado");
                //verificar se o email existe
                if (_collaboratorRepository.CheckEmail (comand.Email))
                    AddNotification ("Email", "Esse email já está cadastrado");
                //criar v.o

                var name = new Name (comand.FirstName, comand.LastName);
                var document = new Document (comand.Document);
                var email = new Email (comand.Email);
                var address = new Address (comand.Street, comand.Number, comand.District, comand.City, comand.Country, comand.ZipCode);
                var phone = new Phone (comand.Phone);               
                var collaborator = new Collaborator (name, document, email, phone, address, comand.Salary, comand.ProjectName, comand.birthDate, comand.JobTitle);

                AddNotifications (collaborator);
                AddNotifications (name);
                AddNotifications (document);
                AddNotifications (email);
                AddNotifications (address);
                AddNotifications (phone);

                if (IsInvalid ())
                    return null;

                _collaboratorRepository.Save (collaborator);
                //decimal salary,
                //string projectName,
                //DateTime birthDate,
                //JobTitle jobTitle
                //criar a entendidade
                //persistir o colaborador
                //retornar o resultadpo
                var k = new CreateCustumerCommandResult (collaborator.Id, name.ToString (), email.Address);
                return k;
            }

            public IComandResult Handle (AddAddressComand comand) {
                throw new System.NotImplementedException ();
            }
        }
}