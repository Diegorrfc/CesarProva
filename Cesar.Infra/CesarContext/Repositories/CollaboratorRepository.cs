using System;
using System.Collections.Generic;
using System.Linq;
using Cesar.Domain.CesarContext.Dtos;
using Cesar.Domain.CesarContext.Entities;
using Cesar.Domain.CesarContext.Repositories;
using Cesar.Infra.CesarContext.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Cesar.Infra.CesarContext.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly CesarDataContext _context;
        public CollaboratorRepository(CesarDataContext context)
        {
            _context = context;
        }
        public bool CheckDocument(string document)
        {
            bool valueToreturn = false;
            var count = _context.Collaborator.Where(c => c.Document.Number == document).ToList().Count;
            if (count > 1)
                valueToreturn = true;
            return valueToreturn;
        }

        public bool CheckEmail(string email)
        {
            bool valueToreturn = false;
            var count = _context.Collaborator.Where(c => c.Email.Address == email).ToList().Count;
            if (count > 1)
                valueToreturn = true;
            return valueToreturn;
        }

        public void Delete(Guid Id)
        {
            var colab = _context.Collaborator.Include(x => x.Address).Where(n => n.Id == Id).FirstOrDefault();
            _context.Collaborator.Remove(colab);
            _context.SaveChanges();
        }

        public GetCollaboratorDto Get(Guid guid)
        {
            return _context.Collaborator.Include(x => x.Address)
                .AsNoTracking()
                .Select(cb =>
                new GetCollaboratorDto
                {
                    Id = cb.Id,
                    FirstName = cb.Name.FirstName,
                    BirthDate = cb.BirthDate,
                    City = cb.Address.City,
                    Country = cb.Address.Country,
                    District = cb.Address.District,
                    Document = cb.Document.Number,
                    Email = cb.Email.Address,
                    JobTitle = cb.JobTitle,
                    LastName = cb.Name.LastName,
                    Number = cb.Address.Number,
                    Phone = cb.Phone.PhoneNumber,
                    ProjectName = cb.ProjectName,
                    Salary = cb.Salary,
                    Street = cb.Address.Street,
                    ZipCode = cb.Address.ZipCode,
                    IdAddress = cb.IdAddress
                    
                }).ToList().FirstOrDefault();
        }

        public List<GetCollaboratorDto> GetAll()
        {
            return _context.Collaborator.Include(x => x.Address)
                .AsNoTracking()
                .Select(cb =>
                new GetCollaboratorDto
                {
                    Id = cb.Id,
                    FirstName = cb.Name.FirstName,
                    BirthDate = cb.BirthDate,
                    City = cb.Address.City,
                    Country = cb.Address.Country,
                    District = cb.Address.District,
                    Document = cb.Document.Number,
                    Email = cb.Email.Address,
                    JobTitle = cb.JobTitle,
                    LastName = cb.Name.LastName,
                    Number = cb.Address.Number,
                    Phone = cb.Phone.PhoneNumber,
                    ProjectName = cb.ProjectName,
                    Salary = cb.Salary,
                    Street = cb.Address.Street,
                    ZipCode = cb.Address.ZipCode,
                    IdAddress = cb.IdAddress
                }).ToList();
        }

        public void Save(Collaborator collaborator)
        {
            _context.Collaborator.Add(collaborator);
            _context.SaveChanges();
        }

        public void Update(Collaborator collaborator)
        {
            var a  = _context.Collaborator.Find(collaborator.Id);            
            _context.Entry<Collaborator>(collaborator).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}