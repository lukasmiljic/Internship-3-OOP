using System;
using System.Collections.Generic;

namespace zad3.Classes
{
    internal class PhoneBook
    {
        public void PrintContacts(Dictionary<Contact, List<Call>> phoneBook)
        {
            foreach (var Contact in phoneBook)
            {
                Console.WriteLine(Contact.ToString());
            }
        }
        public void AddNewContact(Dictionary<Contact, List<Call>> phoneBook, Contact contact, List<Call>calls)
        {
            phoneBook.Add(contact,calls);
        }
        public void DeleteContact(Dictionary<Contact, List<Call>> phoneBook, Contact contact) 
        {
            phoneBook.Remove(contact);
        }
    }
}
