using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EmailAddressBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly VM vm;
        readonly Dictionary<string, Person> activeDisplay = new Dictionary<string, Person>();

        public MainWindow()
        {
            InitializeComponent();
            vm = VM.Instance;
            DataContext = vm;

            vm.CreateDirectory();
            vm.populateUI();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vm.SelectedPerson != null)
            {
                if (activeDisplay.TryGetValue(vm.SelectedPerson.Email, out Person activePerson))
                {
                    activePerson.Focus();
                    double screenWidth = SystemParameters.PrimaryScreenWidth;
                    double screenHeight = SystemParameters.PrimaryScreenHeight;
                    double windowWidth = activePerson.Width;
                    double windowHeight = activePerson.Height;
                    activePerson.Left = (screenWidth / 2) - (windowWidth / 2);
                    activePerson.Top = (screenHeight / 2) - (windowHeight / 2);
                }
                else
                {
                    Person p = new Person(vm.SelectedPerson) { Owner = this };
                    p.Closed += P_Closed;
                    p.Show();

                    activeDisplay.Add(vm.SelectedPerson.Email, p);
                }
            }
        }

        private void P_Closed(object sender, EventArgs e)
        {
            Person p = sender as Person;

            if (activeDisplay.ContainsKey(p.person.Email))
                activeDisplay.Remove(p.person.Email);
        }

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "Search....")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Search....";
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string SearchText = txtSearch.Text.Trim();
            if (SearchText.Length > 0)
            {
                SearchText = SearchText.ToUpper();
                vm.populateSearchUI(SearchText);
            }
            else
            {
                vm.populateUI();
            }
        }
    }
}
