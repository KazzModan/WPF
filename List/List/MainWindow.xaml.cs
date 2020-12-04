using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace List
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] counries = { "Ukraine", "Poland", "Russia", "Belaruss" };
        public MainWindow()
        {
            InitializeComponent();
            countryBox.ItemsSource = counries;
            lBox.ItemsSource = group;
            lBox.DisplayMemberPath=nameof(Person.shortInfo);
        }
        ObservableCollection<Person> group = new ObservableCollection<Person>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lBox.SelectedIndex==-1)
            {
                if (String.IsNullOrEmpty(countryBox.Text as string) || String.IsNullOrEmpty(nameBox.Text) || String.IsNullOrEmpty(srNameBox.Text) || String.IsNullOrEmpty(phBox.Text))
                    MessageBox.Show("One of field is empty");
                else
                    group.Add(new Person(nameBox.Text, srNameBox.Text, phBox.Text, countryBox.Text));
            }
            else
            {
                if (String.IsNullOrEmpty(countryBox.Text as string) || String.IsNullOrEmpty(nameBox.Text) || String.IsNullOrEmpty(srNameBox.Text) || String.IsNullOrEmpty(phBox.Text))
                    MessageBox.Show("One of field is empty");
                else
                {
                    group[lBox.SelectedIndex].Country = countryBox.Text;
                    group[lBox.SelectedIndex].Name = nameBox.Text;
                    group[lBox.SelectedIndex].Surname = srNameBox.Text;
                    group[lBox.SelectedIndex].Phone = phBox.Text;
                    lBox.SelectedIndex = -1;

                }

            }

        }
        public class Person : INotifyPropertyChanged
        {
            private string name;
            public Person(string name,string srname,string phone,string country)
            {
                Name = name;
                Surname = srname;
                Phone = phone;
                Country = country;
            }            
            public string Name
            {
                get { return name; }
                set 
                {
                    if (name != value)
                    {
                        name = value;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(shortInfo));
                    }
                }
            }
            private string surname;
            public string Surname
            {
                get { return surname; }
                set
                {
                    if (surname != value)
                    {
                        surname = value;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(shortInfo));
                    }
                }
            }
            private string phone;
            public string shortInfo => $"{Name} {Surname} \t {Phone}";
            public string Phone
            {
                get { return phone; }
                set
                {
                    if (phone != value)
                    {
                        phone = value;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(shortInfo));
                    }
                }
            }
            private string country;

            public event PropertyChangedEventHandler PropertyChanged;

            public string Country
            {
                get { return country; }
                set
                {
                    if (country != value)
                    {
                        country = value;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(shortInfo));
                    }
                }
            }
            protected void OnPropertyChanged([CallerMemberName] string name = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        private void delBut_Click(object sender, RoutedEventArgs e)
        {
            if (lBox.SelectedIndex == -1)
                MessageBox.Show("U didn't select any item");
            else
                group.RemoveAt(lBox.SelectedIndex);
            
        }

        private void lBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lBox.SelectedIndex >= group.Count)
            {
                nameBox.Text = group[lBox.SelectedIndex].Name;
                srNameBox.Text = group[lBox.SelectedIndex].Surname;
                phBox.Text = group[lBox.SelectedIndex].Phone;
                countryBox.Text = group[lBox.SelectedIndex].Country;
            }
            

        }

        private void lBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            lBox.SelectedIndex = -1;
        }
    }
    
  
}
