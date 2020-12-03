using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace task01
{
    public class ViewModel
    {
        public ObservableCollection<MyColor> colors = new ObservableCollection<MyColor>();
        
        public MyColor SelectedColor { get; set; }
        public MyColor BorderColor { get; set; }

        public void Add()
        {
            SelectedColor = (MyColor)BorderColor.Clone();
            colors.Add(SelectedColor);
            BorderColor.A = 0;
            BorderColor.R = 0;
            BorderColor.G = 0;
            BorderColor.B = 0;
        }
          public void Remove()
        {
            
        }
        public ViewModel()
        {
            SelectedColor = new MyColor();
            BorderColor = new MyColor();

        }
    }
   public class MyColor : INotifyPropertyChanged , ICloneable 
    {
        private byte a;

        public MyColor()
        {
         
        }
        public byte A
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Color));
            }
        }
        private byte r;

        public byte R
        {
            get
            {
                return r;
            }
            set
            {
                r = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Color));
            }
        }

        private byte g;

        public byte G
        {
            get
            {
                return g;
            }
            set
            {
                g = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Color));
            }
        }
        private byte b;

        public byte B
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Color));
            }
        }
      
        public Color Color => Color.FromArgb(A, R, G, B);

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public object Clone()
        {
            MyColor clone =  (MyColor)this.MemberwiseClone();
            return clone;
        }
    }
       
    
}
