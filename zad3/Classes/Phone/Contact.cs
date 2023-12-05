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
            var pref = (Preference)preference;
            this.preference = pref;
            //this.preference = (Preference)preference;
            //ovo gore je ozbiljno drukcije od ovog? haha
        }
        public override string ToString()
        {
            return $"Ime i prezime: {Name} {LastName}\tTel.broj: {phoneNumber}\t Preferenca: {preference}";
        }
    }
}
