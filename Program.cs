using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad3.Classes;

namespace zad3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new Dictionary<Contact, List<Call>>
            {
                {new Contact{fullName = "Ante Antic", phoneNumber = "0"}, new List<Call>()}
            };
            Menu.MainMenu(phoneBook);
        }
    }
}
