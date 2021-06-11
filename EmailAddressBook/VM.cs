using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace EmailAddressBook
{
    public class VM : INotifyPropertyChanged
    {
        private static VM vm;
        public ObservableCollection<PersonEntry> Contacts { get; set; } = new ObservableCollection<PersonEntry>();

        string PeopleDataDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), RESULT_FOLDER_NAME);
        string PeopleDataFilePath =
           Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), RESULT_FOLDER_NAME, TEAMS_FILE_NAME);
        const string RESULT_FOLDER_NAME = "EmailAddressBook";
        const string TEAMS_FILE_NAME = "people.txt";

        public static VM Instance
        {
            get
            {
                if (vm == null)
                    vm = new VM();
                return vm;
            }
        }

        private PersonEntry selectedPerson;

        public PersonEntry SelectedPerson
        {
            get { return selectedPerson; }
            set { selectedPerson = value; }
        }


        public void populateUI()
        {
            Contacts.Clear();
            string[] people = File.ReadAllLines(PeopleDataFilePath);
            foreach (string person in people)
            {
                string[] props = person.Split(new char[] { ',' });
                Contacts.Add(new PersonEntry
                {
                    Name = props[0].Trim(),
                    Email = props[1].Trim(),
                    Phone = props[2].Trim()
                });
            }
        }

        public void populateSearchUI(string SearchQuery)
        {
            Contacts.Clear();
            string[] people = File.ReadAllLines(PeopleDataFilePath);
            foreach (string person in people)
            {
                string[] props = person.Split(new char[] { ',' });
                if (props[0].ToUpper().Contains(SearchQuery) || props[1].ToUpper().Contains(SearchQuery) || props[2].Contains(SearchQuery))
                {
                    Contacts.Add(new PersonEntry
                    {
                        Name = props[0].Trim(),
                        Email = props[1].Trim(),
                        Phone = props[2].Trim()
                    });
                }
            }
        }

        public void CreateDirectory()
        {
            if (!Directory.Exists(PeopleDataDirectoryPath))
                Directory.CreateDirectory(PeopleDataDirectoryPath);
        }

        #region propChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void propChange([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

    }
}
