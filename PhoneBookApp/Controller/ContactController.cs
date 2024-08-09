using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using PhoneBookApp.Data;
using PhoneBookApp.Models;

namespace PhoneBookApp.Controller
{
    internal class ContactController
    {
        public static void PostContact(Contact contact)
        {
            using(var db = new DatabaseManager()) 
            {
                try
                {
                    //db.Add(contact);
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                    Console.WriteLine("Contact Added!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
        }


        public static List<Contact> GetContacts()
        {
            using (var db = new DatabaseManager())
            {
                var contacts = db.Contacts.ToList();
                return contacts;
            }
        }

        public static void UpdateContact(Contact contact, int contactId)
        {
            using (var db = new DatabaseManager())
            {
                try
                {
                    var storedData = db.Contacts.FirstOrDefault(c => c.Id == contactId);

                    storedData!.Name = contact.Name;
                    storedData!.Email = contact.Email;
                    storedData!.PhoneNumber = contact.PhoneNumber;
                    db.SaveChanges();
                 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
        }

        public static void DeleteContact(int contactId)
        {
            using (var db = new DatabaseManager())
            {
                try
                {
                    var storedData = db.Contacts.FirstOrDefault(c => c.Id == contactId);

                    db.Contacts.Remove(storedData!);
                    db.SaveChanges();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
        }

        public static bool CheckIfIdExists(int contactId)
        {
            using(var db = new DatabaseManager())
            {
                var data = db.Contacts.FirstOrDefault(c  => c.Id == contactId);

                return data != null;
            }
        }
     
    }
}
