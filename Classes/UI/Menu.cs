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
                    userChoice = -1;
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
                        DeleteContact(phoneBook);
                        break;

                    case 4:
                        EditContactPreference(phoneBook);
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
        private static void DeleteContact(Dictionary<Contact, List<Call>> phonebook)
        {
            Console.Clear();
            Console.WriteLine("Brisanje kontakta - Unesite broj kontakta kojeg zelite obrisati");
            var brojKontaktaZaObrisat = "";
            Console.Write("Telefonski broj: ");
            brojKontaktaZaObrisat = Console.ReadLine();
            if (!Helper.AreYouSure())
            {
                Console.WriteLine("Brisanje otkazano");
                return;
            }
            foreach (var contact in phonebook) 
            {
                if (contact.Key.phoneNumber == brojKontaktaZaObrisat)
                {
                    PhoneBook.DeleteContact(phonebook, contact.Key);
                    Console.WriteLine("Uspjesno izbrisan kontakt");
                    Helper.PressAnything();
                    return;
                }
            }
            Console.Clear();
            Console.WriteLine("Kontakt nije pronaden");
            Helper.PressAnything();
        }
        private static void EditContactPreference(Dictionary<Contact, List<Call>> phonebook)
        {
            Console.Clear();
            Console.WriteLine("Uredivanje preference kontakta - Unesite broj kontakta kojeg zelite urediti\")");
            Console.WriteLine("[F] - Favorit, [B] - Blokiran, [N] - Normalan kontakt");
            Console.WriteLine("Telefonski broj: ");
            var brojKontaktaZaObrisat = "";
            brojKontaktaZaObrisat = Console.ReadLine();
            if (!Helper.AreYouSure()) 
            {
                Console.WriteLine("Uredivanje otkazano");
            }
            foreach (var contact in phonebook)
            {
                if (contact.Key.phoneNumber == brojKontaktaZaObrisat)
                {
                    Console.WriteLine($"Trenutna preferenca kontakta je {contact.Key.preference}");
                    Console.WriteLine("Unesite novu preferencu: ");
                    var newPreference = int.Parse(Console.ReadLine());
                    contact.Key.EditPreference(newPreference);
                    Console.WriteLine("Uspjesno izbrisan kontakt");
                    Helper.PressAnything();
                    return;
                }
            }
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
