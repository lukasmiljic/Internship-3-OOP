using zad3.Enums;

namespace zad3.Classes
{
    public class Contact
    {
        public string Name {  get; set; }
        public string LastName {  get; set; }
        public string phoneNumber { get; set; }
        public Preference preference { get; set; } = Preference.Normal;

        public void EditPreference(int preference)
        {
            this.preference = (Preference)preference;
        }
        public override string ToString()
        {
            return $"Ime i prezime: {Name} {LastName}\tTel.broj: {phoneNumber}\t Preferenca: {preference}";
        }
    }
}
