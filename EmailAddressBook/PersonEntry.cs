namespace EmailAddressBook
{
    public class PersonEntry
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public PersonEntry()
        {

        }
        public PersonEntry(string PersonName, string PersonEmail, string PersonPhone)
        {
            Name = PersonName;
            Email = PersonEmail;
            Phone = PersonPhone;
        }
    }
}
