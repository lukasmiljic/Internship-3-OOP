using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
                        ManageContact(phoneBook);
                        break;

                    case 6:
                        PrintAllCalls(phoneBook);
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

            if (Helper.IsEmpty(phonebook) == true) return;

            PhoneBook.PrintContacts(phonebook);
            Helper.PressAnything();
        }
        private static void AddContact(Dictionary<Contact, List<Call>> phonebook)
        {
            Console.Clear();
            Console.WriteLine("Dodavanje novog kontakta");
            
            Console.Write("Ime i prezime: ");
            var fullName = Console.ReadLine();
            var phoneNumber = "";
            do
            {
                Console.Write("Telefonski broj: ");
                phoneNumber = Console.ReadLine();
                if (!Helper.ValidatePhoneNumber(phoneNumber, phonebook))
                {
                    Console.WriteLine("Greska pri unosu broja");
                    Helper.PressAnything();
                    continue;
                }
                break;
            } while (true);
            
            if (Helper.AreYouSure())
            {
                var newContact = new Contact();
                newContact.fullName = fullName;
                newContact.phoneNumber = phoneNumber;
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
            if (Helper.IsEmpty(phonebook) == true) return;
            Helper.SimplePrint(phonebook);

            var contactToDelete = "";
            Console.Write("Telefonski broj: ");
            contactToDelete = Console.ReadLine();
            foreach (var contact in phonebook) 
            {
                if (contact.Key.phoneNumber == contactToDelete)
                {
                    if (!Helper.AreYouSure())
                    {
                        Console.WriteLine("Brisanje otkazano");
                        Helper.PressAnything();
                        return;
                    }
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
            if (Helper.IsEmpty(phonebook) == true) return;
            Helper.SimplePrint(phonebook);
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
                        Console.Write("Unesite novu preferencu: ");
                        if (!Helper.ValidateInput(ref newPreference, 2))
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
                Console.WriteLine("Upravljanje kontaktom - unesite telefonski broj kontakta s kojim zelite upravljati [0] za Izlaz");
                if (Helper.IsEmpty(phonebook) == true) return;
                Helper.SimplePrint(phonebook);
                Console.Write("Tel.broj: ");
                newPhoneNumber = Console.ReadLine();
                if (newPhoneNumber == "0")
                {
                    if (Helper.AreYouSure())
                    {
                        Console.WriteLine("Upravljanje otkazano");
                        Helper.PressAnything();
                        return;
                    }
                }
                selectedContact = Helper.ContactFound(phonebook, newPhoneNumber);
                if (selectedContact == null)
                {
                    Console.WriteLine("Kontakt nije pronaden");
                    Helper.PressAnything();
                    continue;
                }
                break;
            } while (true);

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
        private static void PrintAllCalls(Dictionary<Contact, List<Call>> phonebook)
        {
            var emptyFlag = true;
            Console.Clear();
            Console.WriteLine("Ispis svih poziva");
            if (Helper.IsEmpty(phonebook) == true) return;

            foreach (var item in phonebook)
            {
                if (item.Value.Count == 0) continue;
                Console.WriteLine(item.Key.fullName);
                for (int i= 0; i<item.Value.Count; i++)
                {
                    Console.WriteLine("\t" + item.Value[i].ToString());
                    emptyFlag = false;
                }
                //foreach(var call in phonebook.Values)
                //{
                //    Console.WriteLine(call.ToString());
                //    emptyFlag = false;
                //}
            }
            if (emptyFlag == true) Console.WriteLine("Trenutno nema ni jedan poziv");
            Helper.PressAnything();
        }

        private static void PrintAllCalls(List<Call> calls)
        {
            Console.Clear();
            Console.WriteLine("Ispis svih poziva");
            var isEmpty = true;
            foreach (Call call in calls)
            {
                Console.WriteLine(call.ToString());
                isEmpty = false;
            }
            if (isEmpty) Console.WriteLine("Nije zabiljezen nijedan poziv");
            Helper.PressAnything();
        }

        private static void CreateCall(List<Call> calls)
        {
            Console.Clear();
            calls.Add(new Call() { callDate = DateTime.Now, status = Enums.Status.inProgress});
            //odgovor na poziv mora biti random generirana vrijednost?
            Random rand = new Random();
            Console.WriteLine("Poziv je u tijeku...");
            Thread.Sleep(rand.Next(1, 20) * 100);
            calls[calls.Count - 1].status = Enums.Status.ended;
            Helper.PressAnything();
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
