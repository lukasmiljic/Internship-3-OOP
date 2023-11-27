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
            var contactToDelete = "";
            Console.Write("Telefonski broj: ");
            contactToDelete = Console.ReadLine();
            if (!Helper.AreYouSure())
            {
                Console.WriteLine("Brisanje otkazano");
                Helper.PressAnything();
                return;
            }
            foreach (var contact in phonebook) 
            {
                if (contact.Key.phoneNumber == contactToDelete)
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
            Console.WriteLine("[0] - Favorit, [1] - Blokiran, [2] - Normalan kontakt");
            Console.WriteLine("Telefonski broj: ");
            var contactToEdit = "";
            contactToEdit = Console.ReadLine();
            foreach (var contact in phonebook)
            {
                if (contact.Key.phoneNumber == contactToEdit)
                {
                    var newPreference = 0;
                    do
                    {
                        Console.WriteLine($"Trenutna preferenca kontakta je {contact.Key.preference}");
                        Console.WriteLine("Unesite novu preferencu: ");
                        if (Helper.ValidateInput(ref newPreference, 2))
                        {
                            Helper.ErrorMessage(0);
                            continue;
                        }
                        contact.Key.EditPreference(newPreference);
                        Console.WriteLine("Uspjesno izbrisan kontakt");
                        Helper.PressAnything();
                        break;
                    } while (true);
                    return;
                }
            }
            Console.Clear();
            Console.WriteLine("Kontakt nije pronaden");
            Helper.PressAnything();
        }
        private static void ManageContact(Dictionary<Contact, List<Call>> phonebook)
        {
            var newPhoneNumber = "";
            var selectedContact = new Contact();
            do
            {
                Console.Clear();
                Console.WriteLine("Upravljanje kontaktom - unesite telefonski broj kontakta s kojim zelite upravljati");
                Console.Write("Tel.broj: ");
                newPhoneNumber = Console.ReadLine();
                selectedContact = Helper.ContactFound(phonebook, newPhoneNumber);
            } while (selectedContact != null);

            var userChoice = -1;
            do
            {
                Console.Clear();
                Console.WriteLine("[1] Ispis svih poziva");
                Console.WriteLine("[2] Kreiranje novog poziva");
                Console.WriteLine("[0] Izlaz");

                if (!Helper.ValidateInput(ref userChoice, 2))
                {
                    Helper.ErrorMessage(0);
                    userChoice = -1;
                    continue;
                }

                switch (userChoice)
                {
                    case 1:
                        PrintAllCalls(phonebook[selectedContact]);
                        break;

                    case 2:
                        CreateCall(phonebook[selectedContact]);
                        break;

                    default:
                        break;
                }
            } while (userChoice != 0);
        }
        private static void PrintAllCalls()
        {

        }

        private static void PrintAllCalls(List<Call> calls)
        {
            foreach (Call call in calls)
            {
                Console.WriteLine(call.ToString());
            }
            Helper.PressAnything();
        }

        private static void CreateCall(List<Call> calls)
        {
            foreach (Call call in calls) 
            {
                
            }
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
