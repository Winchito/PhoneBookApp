using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PhoneBookApp.Controller;
using PhoneBookApp.Models;

namespace PhoneBookApp
{
    internal class UserInput
    {
        private const string REGEX_VALUE = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        public static void MainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Write("Phone Book \n1. Create Contact\n2. Read Contacts\n3. Update Contact\n4. Delete Contact\n0. Exit App\nSelect an option: ");
                try
                {
                    int option = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (option)
                {
                    case 0:
                            exit = true;
                            break;
                        case 1:
                            CreateContact();
                            break;
                        case 2:
                            ReadContacts();
                            break;
                        case 3:
                            UserUpdateContact();
                            break;
                        case 4:
                            UserDeleteContact();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Select a valid option!");
                            break;
                        }
                    }
                catch (Exception ex) 
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }

        }

        private static void CreateContact()
        {
            (string contactName, string contactPhoneNumber, string contactEmail) contactTuple = ConsoleUserInputs();

            Contact contact = new Contact
            {
                Name = contactTuple.contactName,
                PhoneNumber = contactTuple.contactPhoneNumber,
                Email = contactTuple.contactEmail
            };

            ContactController.PostContact(contact);
        }

        private static void ReadContacts()
        {
            List<Contact> contacts = ContactController.GetContacts();
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Id} | {contact.Name} | {contact.PhoneNumber} | {contact.Email}");
            }
        }

        private static void UserUpdateContact()
        {
            ReadContacts();
            Console.Write("Select the contact ID, enter 0 to exit: ");
            int contactId = Int32.Parse(Console.ReadLine());
            bool idExists = ContactController.CheckIfIdExists(contactId);
            if (idExists)
            {
                (string contactName, string contactPhoneNumber, string contactEmail) contactTuple = ConsoleUserInputs();

                Contact contact = new Contact
                {
                    Name = contactTuple.contactName,
                    PhoneNumber = contactTuple.contactPhoneNumber,
                    Email = contactTuple.contactEmail
                };

                ContactController.UpdateContact(contact, contactId);

            }
            else
            {
                Console.WriteLine("ID Not found!");
                return;
            }


        }

        private static void UserDeleteContact()
        {
            ReadContacts();
            Console.Write("Select the contact ID, enter 0 to exit: ");
            int contactId = Int32.Parse(Console.ReadLine());
            bool idExists = ContactController.CheckIfIdExists(contactId);
            if (idExists)
            {
                ContactController.DeleteContact(contactId);
            }
            else
            {
                Console.WriteLine("ID Not found!");
                return;
            }
        }

        private static (string, string, string) ConsoleUserInputs()
        {
            Console.Write("Insert Contact Name, enter 0 to exit: ");
            string contactName = Console.ReadLine();
            if (contactName == "0") MainMenu();

            Console.Write("Insert Contact Phone Number, enter 0 to exit: ");
            string contactPhoneNumber = Console.ReadLine();
            if (contactPhoneNumber == "0") MainMenu();

            Console.Write("Insert Contact Email, enter 0 to exit: ");
            string contactEmail = Console.ReadLine();
            if (contactEmail == "0") MainMenu();
            while (!Regex.IsMatch(contactEmail, REGEX_VALUE, RegexOptions.IgnoreCase))
            {
                Console.Write("Insert a valid Email or enter - to: ");
                contactEmail = Console.ReadLine();
                if (contactEmail == "0") MainMenu();
            }

            return (contactName!, contactPhoneNumber!, contactEmail);
        }

    }
}
