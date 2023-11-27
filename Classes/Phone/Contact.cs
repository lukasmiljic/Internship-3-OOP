using zad3.Enums;

namespace zad3.Classes
{
    public class Contact
    {
        public string fullName {  get; set; }
        public string phoneNumber { get; set; }
        public Preference preference { get; set; } = Preference.Normal;

        public void EditPreference(string fullName, Preference preference)
        {
            this.preference = preference;
        }
        public override string ToString()
        {
            return $"Fullname: {fullName}\tPhone number: {phoneNumber}\t Preference: {preference}";
        }
    }
}
