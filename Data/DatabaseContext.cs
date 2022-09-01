using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Data
{
    public class DatabaseContext : DbContext
    {
       public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
       {
        
       }
        public DbSet<ContactModel> Contacts {get; set;}
       
    }
}