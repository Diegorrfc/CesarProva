using System;
using System.Collections.Generic;
using System.Linq;
using Cesar.Domain.CesarContext.Entities;
using Cesar.Domain.CesarContext.Repositories;
using Cesar.Infra.CesarContext.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Cesar.Infra.CesarContext.Repositories {
    public class CollaboratorRepository : ICollaboratorRepository {
        private readonly CesarDataContext _context;
        public CollaboratorRepository (CesarDataContext context) {
            _context = context;
        }
        public bool CheckDocument (string document) {
            bool valueToreturn = false;
            var count = _context.Collaborator.Where (c => c.Document.Number == document).ToList ().Count;
            if (count > 1)
                valueToreturn = true;
            return valueToreturn;
        }

        public bool CheckEmail (string email) {
            bool valueToreturn = false;
            var count = _context.Collaborator.Where (c => c.Email.Address == email).ToList ().Count;
            if (count > 1)
                valueToreturn = true;
            return valueToreturn;
        }

        public void Delete (Collaborator collaborator) {
            var colab = Get (collaborator.Id);
            _context.Collaborator.Remove (colab);
            _context.SaveChanges();
        }

        public Collaborator Get (Guid guid) {
            return _context.Collaborator.Find(guid);
        }

        public List<Collaborator> GetAll () {
            return _context.Collaborator.Include (x => x.Address).AsNoTracking ().ToList ();
        }

        public void Save (Collaborator collaborator) {
            _context.Collaborator.Add (collaborator);
            _context.SaveChanges();
        }

        public void Update (Collaborator collaborator) {
            _context.Entry<Collaborator>(collaborator).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}