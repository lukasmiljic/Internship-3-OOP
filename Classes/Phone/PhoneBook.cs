using System;
using System.Collections.Generic;

namespace zad3.Classes
{
    internal class PhoneBook
    {
        public static void PrintContacts(Dictionary<Contact, List<Call>> phoneBook)
        {
            foreach (var contact in phoneBook)
            {
                Console.WriteLine(contact.Key.ToString());
            }
        }
        public static void AddNewContact(Dictionary<Contact, List<Call>> phoneBook, Contact contact, List<Call>calls)
        {
            phoneBook.Add(contact,calls);
        }
        public static void DeleteContact(Dictionary<Contact, List<Call>> phoneBook, Contact contact) 
        {
            phoneBook.Remove(contact);
        }
    }
}
