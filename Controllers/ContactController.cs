using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ContactApp.Models;
using ContactApp.Repository;



namespace ContactApp.Controllers
{
 
    public class ContactController : Controller
    {

        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
          _contactRepository = contactRepository;
        }  
        public IActionResult Index()
        {
            List<ContactModel> contacts = _contactRepository.GetAll();
            return View(contacts);
        }

       public IActionResult Create()
       {
            return View();
       }
       public IActionResult Edit(string id)
       {
            ContactModel contact = _contactRepository.GetById(id);
            return View(contact);
       }
       public IActionResult ConfirmDelete(string id)
       {
          ContactModel contact = _contactRepository.GetById(id);
          return View(contact);
       }

       [HttpPost] 
       public IActionResult Create(ContactModel contact)
       {
         try
         {
               if(ModelState.IsValid)
            {
                _contactRepository.Add(contact);
                TempData["SuccessMessage"] = "The contact was successfully saved.";
                return RedirectToAction("Index");
            }
            return View(contact);
         }
         catch (System.Exception error)
         {
            
             TempData["ErrrorMessage"] = "Error saving contact.";
             return RedirectToAction("Index");
         }
       }
       [HttpPost]
       public IActionResult Edit(ContactModel contact)
       {
         try
         {
             if(ModelState.IsValid){
              _contactRepository.Edit(contact);
              TempData["SuccessMessage"] = "Your contact has been successfully edited";
              return RedirectToAction("Index");
            }
             return View("Edit",contact);
      
         }
         catch (System.Exception)
         {
            
             TempData["ErrorMessage"] = "Error editing contact";
             return View("Edit",contact);
         }
       }
       public IActionResult Delete(string id)
       {
         try
         {
             bool deleted = _contactRepository.Delete(id);
               if(deleted)
               {
                    TempData["SuccessMessage"] = "The contact was successfully deleted.";
                    return RedirectToAction("Index");
               }else{
                   TempData["ErrrorMessage"] = "Error deleting contact.";
               }
             return RedirectToAction("Index");
         }
         catch (System.Exception)
         {
            
             TempData["ErrrorMessage"] = "Error deleting contact.";
              return RedirectToAction("Index");
         }
        
       }
    }
}