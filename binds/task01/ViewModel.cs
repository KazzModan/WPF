using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace task01
{
    public class ViewModel : INotifyPropertyChanged

    {
        public ObservableCollection<MyColor> colors = new ObservableCollection<MyColor>();

        public MyColor SelectedColor { get; set; }
        public MyColor BorderColor { get; set; }
        public bool Check()
        {
            return !colors.Contains(BorderColor);
        }
        public void AddColor()
        {
            (AddCommand as Command).RaiseCanExecuteChanged();
            colors.Add(SelectedColor);
        }
        protected void Add()
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
            colors.Remove(SelectedColor);
        }
        public ViewModel()
        {
            SelectedColor = new MyColor();
            BorderColor = new MyColor();
            addCommand = new DelegateCommand(Add, Check);
            removeCommand = new DelegateCommand(RemoveColor);

            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(SelectedColor))
                {
                    addCommand.RaiseCanExecuteChanged();
                    removeCommand.RaiseCanExecuteChanged();

                }
            };

        }
        private readonly Command addCommand;
        private readonly Command removeCommand;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand AddCommand => addCommand;
        public ICommand RemoveCommand => removeCommand;
      
        public void RemoveColor()
        {
            if (SelectedColor != null)
                colors.Remove(SelectedColor);
        }
    }
    public class MyColor : INotifyPropertyChanged, ICloneable, IComparable<MyColor>, IEquatable<MyColor>
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
            MyColor clone = (MyColor)this.MemberwiseClone();
            return clone;
        }
        public int CompareTo(MyColor obj)
        {
            return this.A == obj.A && this.B == obj.B && this.R == obj.R ? 0 : 1;
        }

        public bool Equals(MyColor other)
        {
            if (other.A != this.A)
                return false;

            if (other.R != this.R)
                return false;

            if (other.G != this.G)
                return false;

            if (other.B != this.B)
                return false;
            return true;
        }
    }

}
