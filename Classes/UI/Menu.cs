using System;
using zad3.Classes.UI;

namespace zad3.Classes
{
    public class Menu
    {
        public void MainMenu()
        {
            var userChoice = -1;
            do
            {
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
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    case 6:
                        break;

                    case 0:
                        break;

                    default:
                        break;
                }

                break;
            } while (true);
        }
        
    }
}
