using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Models;
using ContactApp.Data;

namespace ContactApp.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ContactRepository(DatabaseContext databaseContext)
        {
                _databaseContext = databaseContext;
        }
        public ContactModel Add(ContactModel contact)
        {
           _databaseContext.Contacts.Add(contact);
           _databaseContext.SaveChanges();
           return contact;
        }

      
        public ContactModel Edit(ContactModel contact)
        {
           ContactModel contactFromDb = GetById(contact.Id);
           contactFromDb.Name = contact.Name;
           contactFromDb.Email = contact.Email;
           contactFromDb.Phone = contact.Phone;
           _databaseContext.Contacts.Update(contactFromDb);
           _databaseContext.SaveChanges();
           return contactFromDb;
        }

        public List<ContactModel> GetAll()
        {
           return _databaseContext.Contacts.ToList();
        }

        public ContactModel GetById(string id)
        {   
            ContactModel contact = _databaseContext.Contacts.FirstOrDefault( x => x.Id == id);
            if(contact == null) throw new System.Exception("Contact Not Found!");
            return contact;
        }

        public bool Delete(string id)
        {
           ContactModel contactToDelete = GetById(id);
           _databaseContext.Contacts.Remove(contactToDelete);
           _databaseContext.SaveChanges();
           return true;
        }

    }
}