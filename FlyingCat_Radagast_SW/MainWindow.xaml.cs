using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FlyingCat_Radagast_SW
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread th;

        public MainWindow()
        {
            InitializeComponent();

            giphy_heaven.IsEnabled = true;
            CatImage.IsEnabled = true;

            th = new Thread(thread);
            th.Start();
        }

        public void thread()
        {
            //target Frames per Second (FAKE)
            float Speed = 240;
            while (true)
            {
                Application.Current.Dispatcher.Invoke(new Action(() => updateGUI()));
                Thread.Sleep(Convert.ToInt32((1 / Speed) * 1000));
            }
        }

        float i = 0;
        void updateGUI()
        {
            //Update Cat Position
            int CatAmplitude = 50;
            i += 0.01f;
            int newpos = Convert.ToInt32((Math.Sin(i) * CatAmplitude ));
            Thickness tn = CatImage.Margin;
            tn.Bottom = newpos;
            CatImage.Margin = tn;
            Console.WriteLine(newpos);
        }

        private void replayGif(object sender, RoutedEventArgs e)
        {
            giphy_heaven.Position = new TimeSpan(0, 0, 10);
            giphy_heaven.Play();           
        }
    }
}