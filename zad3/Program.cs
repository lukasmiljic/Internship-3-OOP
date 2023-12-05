using System.Collections.Generic;
using zad3.Classes;

namespace zad3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new Dictionary<Contact, List<Call>>
            {
                {new Contact{Name = "Ante", LastName = "Antic", phoneNumber = "063456789"}, new List<Call>()}
            };
            Menu.MainMenu(phoneBook);
        }
    }
}
