using zad3.Enums;

namespace zad3.Classes
{
    public class Contact
    {
        public string fullName;
        public string phoneNumber { get; private set; }
        public Preference preference;

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
