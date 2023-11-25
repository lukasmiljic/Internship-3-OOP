﻿using System;

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
    }
}
