using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Models;

namespace ContactApp.Repository
{
    public interface IContactRepository
    {
        ContactModel Add(ContactModel contact);
        List<ContactModel> GetAll();
        ContactModel GetById(string id);
        ContactModel Edit(ContactModel contact);
        bool Delete(string id);
    }
}