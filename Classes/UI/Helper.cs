using System;
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
            if (AreYouSure() == 1)
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
        public static int AreYouSure()
        {
            do
            {
                char userChoice;
                Console.Write("Jeste li sigurni [y/n]: ");
                userChoice = char.Parse(Console.ReadLine());
                if (userChoice == 'y')
                {
                    Console.Clear();
                    return 1;
                }
                else if (userChoice == 'n')
                {
                    Console.Clear();
                    return 0;
                }
                else
                {
                    Console.WriteLine("Unesite ili y ili n.");
                    PressAnything();
                }
            } while (true);
        }
    }
}
