using System;
using System.Collections.Generic;
using System.Threading;
using zad3.Classes.UI;

namespace zad3.Classes
{
    public class Menu
    {
        public static void MainMenu(Dictionary<Contact, List<Call>> phoneBook)
        {
            var userChoice = -1;
            do
            {
                Console.Clear();
                Console.WriteLine("[1] Ispis svih kontakata");
                Console.WriteLine("[2] Dodavanje novih kontakata u imenik");
                Console.WriteLine("[3] Brisanje kontakata iz imenika");
                Console.WriteLine("[4] Editiranje preference kontakta");
                Console.WriteLine("[5] Upravljanje kontaktom");
                Console.WriteLine("[6] Ispis svih poziva");
                Console.WriteLine("[0] Izlaz");

                if (!Helper.ValidateInput(ref userChoice, 6))
                {
                    Helper.ErrorMessage(0);
                    continue;
                }

                switch (userChoice)
                {
                    case 1:
                        PrintAllContacts(phoneBook);
                        break;

                    case 2:
                        AddContact(phoneBook);
                        break;

                    case 3:
                        DeleteContact();
                        break;

                    case 4:
                        EditContactPreference();
                        break;

                    case 5:
                        ManageContact();
                        break;

                    case 6:
                        PrintAllCalls();
                        break;

                    case 0:
                        if (!ExitApplication()) userChoice = -1;
                        break;

                    default:
                        break;
                }
            } while (userChoice != 0);
        }

        private static void PrintAllContacts(Dictionary<Contact, List<Call>> phonebook)
        {
            Console.Clear();
            Console.WriteLine("Ispis svih kontakata");
            PhoneBook.PrintContacts(phonebook);
            Helper.PressAnything();
        }
        private static void AddContact(Dictionary<Contact, List<Call>> phonebook)
        {
            Console.Clear();
            Console.WriteLine("Dodavanje novog kontakta");
            var newContact = new Contact();
            Console.Write("Ime i prezime: ");
            newContact.fullName = Console.ReadLine();
            Console.Write("Telefonski broj: ");
            newContact.phoneNumber = Console.ReadLine();
            if (Helper.AreYouSure())
            {
                PhoneBook.AddNewContact(phonebook, newContact, new List<Call>());
                Console.WriteLine("Uspjesno dodan novi kontakt");
            }
            else Console.WriteLine("Unos novog kontakta otkazan");
            Helper.PressAnything();
        }
        private static void DeleteContact()
        {

        }
        private static void EditContactPreference()
        {

        }
        private static void ManageContact()
        {

        }
        private static void PrintAllCalls()
        {

        }
        private static bool ExitApplication()
        {
            Console.Clear();
            if (Helper.AreYouSure())
            {
                Console.WriteLine("Zbogom...");
                Thread.Sleep(1000);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
