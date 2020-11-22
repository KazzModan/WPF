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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
namespace Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<int> list = new List<int>();
        DispatcherTimer timer;
        int time = 45;
        BitmapSource bitImg2 = Imaging.CreateBitmapSourceFromHBitmap(Resource1.image2.GetHbitmap(),
                                    IntPtr.Zero,
                                    Int32Rect.Empty,
                                    BitmapSizeOptions.FromEmptyOptions());
        BitmapSource bitImg = Imaging.CreateBitmapSourceFromHBitmap(Resource1.image.GetHbitmap(),
                               IntPtr.Zero,
                               Int32Rect.Empty,
                               BitmapSizeOptions.FromEmptyOptions());
        Style wrongStyle;
        Style rightStyle;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            wrongStyle = TryFindResource("wrongBtn") as Style;
            rightStyle = TryFindResource("rightBtn") as Style;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Title = $"00:{time - counter}";
            counter++;
            if (time - counter <= 0)
            {
                MessageBox.Show("You lost");
                this.Close();
            }
        }

        int lastValue = 0;
        int counter = 0;
        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            slider.IsEnabled = false;
            Random rand = new Random();
            FillList();
            foreach (Button item in grid.Children.OfType<Button>())
            {
                item.IsEnabled = true;
                int index = rand.Next(0, list.Count);
                item.Content = list[index];
                list.Remove(list[index]);
            }
        }
        public void FillList()
        {
            for (int i = 0; i < 24; i++)
            {
                list.Add(i + 1);
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if ((int)(btn.Content) == lastValue + 1)
            {
                btn.Style = rightStyle;
                btn.IsEnabled = false;
                lastValue++;
                counter++;
                prBar.Value++;
            }
            else
                btn.Style = wrongStyle;
            if (counter == 24)
            {
                MessageBox.Show("CONGRATULATION, YOU WON");
                this.Close();
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            time = (int)(slider.Value);
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        { 
            image.Source = bitImg2;
        }

        private void image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            image.Source = bitImg;
        }
    }
}
