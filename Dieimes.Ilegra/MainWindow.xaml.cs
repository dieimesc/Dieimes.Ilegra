using Dieimes.Ilegra.Service.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Dieimes.Ilegra
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread thread =  FileService.StartRead(AppDomain.CurrentDomain.BaseDirectory + "//data/in//",
                                  AppDomain.CurrentDomain.BaseDirectory + "//data/out//");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (btnStart.Content.ToString() == "Parar leitura")
            {
                thread.Suspend();
                btnStart.Content = "Retomar leitura";
            }
            else
            {
                if (thread.ThreadState == System.Threading.ThreadState.Suspended)
                    thread.Resume();
                else
                    thread.Start();
                btnStart.Content = "Parar leitura";
            }

          
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "//data/in//"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "//data/in//");

            Process.Start(AppDomain.CurrentDomain.BaseDirectory + "//data/in//");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "//data/out//"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "//data/out//");

            Process.Start(AppDomain.CurrentDomain.BaseDirectory + "//data/out//");
        }
    }
}
