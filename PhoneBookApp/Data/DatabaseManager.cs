using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using PhoneBookApp.Models;

namespace PhoneBookApp.Data
{
    internal class DatabaseManager: DbContext
    {

        public readonly string dbConnection = ConfigurationManager.AppSettings.Get("SQLConnection");

        DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(dbConnection);
        }

    }
}
