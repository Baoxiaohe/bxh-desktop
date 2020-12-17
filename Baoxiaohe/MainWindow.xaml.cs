using CefSharp;
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
using System.Windows.Threading;

namespace Baoxiaohe
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private const string MAIN_URL = "https://www.baoxiaohe.com/";
        DispatcherTimer startLogodispatcherTimer = new DispatcherTimer();

        private void myChrome_Loaded(object sender, RoutedEventArgs e)
        {
        }


        private void myChrome_IsBrowserInitializedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (myChrome.IsBrowserInitialized)
            {
                if (!String.IsNullOrEmpty(MAIN_URL))
                {
                    myChrome.Load(MAIN_URL);
                    startLogodispatcherTimer.Tick += StartLogodispatcherTimer_Tick;
                    startLogodispatcherTimer.Interval = new TimeSpan(0, 0, 0, 2, 600);
                    startLogodispatcherTimer.Start();
                }
            }
        }

        private void StartLogodispatcherTimer_Tick(object sender, EventArgs e)
        {
            startLogodispatcherTimer.Stop();
            startArea.Visibility = Visibility.Collapsed;
            myChrome.Visibility = Visibility.Visible;
        }
    }
}
