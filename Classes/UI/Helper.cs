using System;
using System.Collections.Generic;
using System.Threading;

namespace zad3.Classes.UI
{
    public class Helper
    {
        public static bool ValidateInput(ref int userChoice, int maxValue)
        {
            var inputSuccess = false;
            inputSuccess = int.TryParse(Console.ReadLine(), out userChoice);
            if (inputSuccess == false || userChoice > maxValue || userChoice < 0) return false;
            else return true;
        }
        public static void ErrorMessage(int errorCode)
        {
            Console.Clear();

            switch (errorCode)
            {
                case 0:
                    Console.WriteLine("Greska pri odabiru! Molimo ponovno unesite vrijednost");
                    break;

                default:
                    break;
            }

            PressAnything();
        }
        public static void PressAnything()
        {
            Console.WriteLine("Unesite bilo sto za nastavak...");
            Console.ReadLine();
        }
        public static int ExitApplication()
        {
            Console.Clear();
            if (AreYouSure())
            {
                Console.WriteLine("Zbogom...");
                Thread.Sleep(1000);
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public static bool AreYouSure()
        {
            do
            {
                char userChoice;
                Console.Write("Jeste li sigurni [y/n]: ");
                char.TryParse(Console.ReadLine(), out userChoice);
                if (userChoice == 'y')
                {
                    return true;
                }
                else if (userChoice == 'n')
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Unesite ili y ili n.");
                }
            } while (true);
        }

        public static Contact ContactFound(Dictionary<Contact, List<Call>> phonebook, string phoneNumber)
        {
            foreach (var contact in phonebook)
            {
                if (contact.Key.phoneNumber == phoneNumber)
                {
                    return contact.Key;
                }
            }
            Console.WriteLine("Kontakt nije pronaden");
            PressAnything();
            return null;
        }

        public static bool ValidatePhoneNumber (string phoneNumber, Dictionary<Contact, List<Call>> phonebook)
        {
            if (phoneNumber.Length < 6 || int.TryParse(phoneNumber, out _)) return false;
            if (ContactFound(phonebook, phoneNumber) != null) return false;
            return true;
        }

        public static bool IsEmpty(Dictionary<Contact, List<Call>> phonebook)
        {
            if (phonebook.Count == 0)
            {
                Console.WriteLine("Trenutno nema nijedan kontakt u kontaktima");
                Helper.PressAnything();
                return true;
            }
            return false;
        }

        public static void SimplePrint(Dictionary<Contact, List<Call>> phonebook)
        {
            foreach (var contact in phonebook)
            {
                Console.WriteLine("\t" + contact.Key.fullName + " " + contact.Key.phoneNumber);
            }
        }
    }
}
