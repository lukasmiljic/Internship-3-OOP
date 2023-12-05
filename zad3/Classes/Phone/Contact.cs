using zad3.Enums;

namespace zad3.Classes
{
    public class Contact
    {
        public string Name {  get; set; }
        public string LastName {  get; set; }
        public string PhoneNumber { get; set; }
        public Preference Preference { get; set; } = Preference.Normal;
        public void EditPreference(int preference)
        {
            var pref = (Preference)preference;
            Preference = pref;
            //this.preference = (Preference)preference;
            //ovo gore je ozbiljno drukcije od ovog? haha
        }
        public override string ToString()
        {
            return $"Ime i prezime: {Name} {LastName}\tTel.broj: {PhoneNumber}\t Preferenca: {Preference}";
        }
    }
}
