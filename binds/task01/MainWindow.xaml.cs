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

namespace task01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
            ViewModel model = new ViewModel();        
        public MainWindow()
        {
            model.SelectedColor = new MyColor();
        InitializeComponent();
            lBox.ItemsSource = model.colors;
            this.DataContext = model;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            model.Add();
        }
        private void lBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            model.BorderColor.A = model.colors[lBox.SelectedIndex].A;
            model.BorderColor.R = model.colors[lBox.SelectedIndex].R;
            model.BorderColor.G = model.colors[lBox.SelectedIndex].G;
            model.BorderColor.B = model.colors[lBox.SelectedIndex].B;
        }
    }
}
