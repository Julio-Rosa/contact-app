using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ContactApp.Models
{
    public class  ContactModel
    {
        public ContactModel()
        {
            Id = Guid.NewGuid().ToString();
        }
        
        public string Id {get; set;}
        [Required(ErrorMessage="Type the contact name!")]
        public string Name {get; set;}
        [Required (ErrorMessage="Type the contact e-mail!")]
        [EmailAddress(ErrorMessage="Type a valid e-mail!")]
        public string Email {get; set;}       
        [Required (ErrorMessage="Type the contact phone!")]
        [Phone (ErrorMessage = "Type a valid phone number!")]
        public string Phone {get; set;}

    }
}