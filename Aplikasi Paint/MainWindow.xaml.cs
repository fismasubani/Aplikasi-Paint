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

class Bentuk
{
    public string Tipe;
    public double Ketebalan;
    public SolidColorBrush Warna;
    public Point mulai, selesai;

    //constructors
    public Bentuk()
    {
        Warna = Brushes.Black;
        Tipe = "Garis";
    }

    public Line Garis()
    {
        Line garisBaru = new Line()
        {
            Stroke = Warna,
            StrokeThickness = Ketebalan,
            X1 = mulai.X,
            Y1 = mulai.Y - 70,
            X2 = selesai.X,
            Y2 = selesai.Y - 70
        };
        return garisBaru;
    }

    public Ellipse Lingkaran()
    {
        Ellipse lingkaranBaru = new Ellipse()
        {
            Stroke = Brushes.Black,
            Fill = Warna,
            StrokeThickness = Ketebalan
        };

        if (selesai.X >= mulai.X)
        {
            lingkaranBaru.Width = selesai.X - mulai.X;
            lingkaranBaru.SetValue(Canvas.LeftProperty, mulai.X);
        }
        else
        {
            lingkaranBaru.Width = mulai.X - selesai.X;
            lingkaranBaru.SetValue(Canvas.LeftProperty, selesai.X);
        }

        if (selesai.Y >= mulai.Y)
        {
            lingkaranBaru.Height = selesai.Y - mulai.Y;
            lingkaranBaru.SetValue(Canvas.TopProperty, mulai.Y - 70);
        }
        else
        {
            lingkaranBaru.Height = mulai.Y - selesai.Y;
            lingkaranBaru.SetValue(Canvas.TopProperty, selesai.Y - 70);
        }
        return lingkaranBaru;
    }

    public Rectangle Kotak()
    {
        Rectangle kotakBaru = new Rectangle()
        {
            Stroke = Brushes.Black,
            Fill = Warna,
            StrokeThickness = Ketebalan
        };

        if (selesai.X >= mulai.X)
        {
            kotakBaru.Width = selesai.X - mulai.X;
            kotakBaru.SetValue(Canvas.LeftProperty, mulai.X);
        }
        else
        {
            kotakBaru.Width = mulai.X - selesai.X;
            kotakBaru.SetValue(Canvas.LeftProperty, selesai.X);
        }

        if (selesai.Y >= mulai.Y)
        {
            kotakBaru.Height = selesai.Y - mulai.Y;
            kotakBaru.SetValue(Canvas.TopProperty, mulai.Y - 70);
        }
        else
        {
            kotakBaru.Height = mulai.Y - selesai.Y;
            kotakBaru.SetValue(Canvas.TopProperty, selesai.Y - 70);
        }
        
        return kotakBaru;
    }
}

namespace Kel._4_PBO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Bentuk bentukSekarang = new Bentuk();


        private void Tombol_Garis_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Tipe = "Garis";
        }

        private void Tombol_Lingkaran_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Tipe = "Lingkaran";
        }

        private void Tombol_Kotak_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Tipe = "Kotak";
        }

        private void Warna_Merah_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Warna = Brushes.Red;
        }

        private void Warna_Orange_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Warna = Brushes.Orange;
        }

        private void Warna_Kuning_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Warna = Brushes.Yellow;
        }

        private void Warna_Hijau_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Warna = Brushes.Green;
        }

        private void Warna_Biru_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Warna = Brushes.Blue;
        }

        private void Warna_Ungu_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Warna = Brushes.Purple;
        }

        private void Warna_Pink_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Warna = Brushes.DeepPink;
        }

        private void Warna_Coklat_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Warna = Brushes.Brown;
        }

        private void Warna_Salmon_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Warna = Brushes.Salmon;
        }

        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bentukSekarang.mulai = e.GetPosition(this);
        }

        private void MyCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Shape bentukYangDigambar;
            if(bentukSekarang.Tipe == "Garis")
            {
                bentukYangDigambar = bentukSekarang.Garis();
            }
            else if(bentukSekarang.Tipe == "Lingkaran")
            {
                bentukYangDigambar = bentukSekarang.Lingkaran();
            }
            else
            {
                bentukYangDigambar = bentukSekarang.Kotak();
            }
            MyCanvas.Children.Add(bentukYangDigambar);
        }

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                bentukSekarang.selesai = e.GetPosition(this);
            }
        }

        private void Satu_Point_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Ketebalan = 1;
        }

        private void Dua_Point_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Ketebalan = 2;
        }

        private void Empat_Point_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Ketebalan = 4;
        }

        private void Tombol_Clear_Click(object sender, RoutedEventArgs e)
        {
            MyCanvas.Children.Clear();
        }
    }
}