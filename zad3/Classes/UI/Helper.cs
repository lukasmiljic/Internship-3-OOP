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
            }

            PressAnything();
        }
        public static void PressAnything()
        {
            Console.WriteLine("Unesite bilo sto za nastavak...");
            Console.ReadLine();
        }
        public static bool AreYouSure()
        {
            do
            {
                Console.Write("Jeste li sigurni [y/n]: ");
                var userChoice = char.Parse(Console.ReadLine());
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
        //stavi u Contact?
        public static Contact ContactFound(Dictionary<Contact, List<Call>> phonebook, string phoneNumber)
        {
            foreach (var contact in phonebook)
            {
                if (contact.Key.phoneNumber == phoneNumber)
                {
                    return contact.Key;
                }
            }
            return null;
        }

        public static bool ValidatePhoneNumber (string phoneNumber, Dictionary<Contact, List<Call>> phonebook)
        {
            if (phoneNumber.Length < 6 || !int.TryParse(phoneNumber, out var temp)) return false;
            if (ContactFound(phonebook, phoneNumber) != null) return false;
            //promjeni contact found u nullable pa vidi jel moze !contactfound
            return true;
        }

        public static bool IsEmpty(Dictionary<Contact, List<Call>> phonebook)
        {
            if (phonebook.Count != 0)
                    return false;
            Console.WriteLine("Trenutno nema nijedan kontakt u kontaktima");
            PressAnything();
            return true;
        }

        public static void SimplePrint(Dictionary<Contact, List<Call>> phonebook)
        {
            foreach (var contact in phonebook)
            {
                Console.WriteLine("\t" + contact.Key.Name + " " + contact.Key.phoneNumber);
            }
        }
    }
}
