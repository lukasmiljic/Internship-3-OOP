using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3.Classes
{
    internal class PhoneBook
    {
        public static Dictionary<Contact, List<Call>> phoneBook;

        public void PrintContacts()
        {
            foreach (var Contact in PhoneBook.phoneBook)
            {
                Console.WriteLine(Contact.ToString());
            }
        }
        public void AddNewContact(Contact contact, List<Call>calls)
        {
            phoneBook.Add(contact,calls);
        }
        public void DeleteContact(Contact contact) 
        {
            phoneBook.Remove(contact);
        }
    }
}
