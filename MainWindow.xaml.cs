using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
using MySql.Data.MySqlClient;
namespace FSHS_Desktop_ATC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool executeMethod;
        whazzup whazzup_tfl = new whazzup();
        IniFile MyIni = new IniFile();
        BackgroundWorker worker = new BackgroundWorker();
        public MainWindow()
        {
            InitializeComponent();
            if (!MyIni.KeyExists("DefaultVolume", "Audio"))
            {
                MyIni.Write("DefaultVolume", "100", "Audio");
            }
            MyIni.Write("FSHS", "https://dev.fshs.info", "Web");
            MyIni.Write("TFL", "https://tflserver.com", "Web");
            if (!MyIni.KeyExists("whazzup", "Data"))
            {
                MyIni.Write("whazzup", "C:\\Users\\cody\\Documents\\JoinFS-FSX\\whazzup.txt", "Data");
            }
            WhazzupLocation.Text = MyIni.Read("whazzup", "Data");
            MyIni.Write("whazzup_TFL", "whazzup_TFL.txt", "Data");
            if (!File.Exists(MyIni.Read("whazzup", "Data")))
            {
                MyIni.Write("whazzup", "C:\\Users\\cody\\Documents\\JoinFS-FSX\\whazzup.txt", "Data");
                MessageBox.Show("whazzup file location invalid!");
            }
        }
        public void ATC_Display_Data()
        {
            worker.WorkerReportsProgress = false;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i = 0; i < 600; i++)
            {
                whazzup_tfl.UpdateWithFlightPlans();
                //Update every 15 seconds
                Thread.Sleep(15000);
            }
            CheckATC();
            
        }
        void CheckATC()
        {
            if (Process.GetProcessesByName("vrc").Length > 0)
            {
                // Is running
                ATC_Display_Data();
            }
        }

        private void SpecifyWhazzupLocation_Checked(object sender, RoutedEventArgs e)
        {
            WhazzupLocation.IsEnabled = true;
        }
        private void SpecifyWhazzupLocation_UnChecked(object sender, RoutedEventArgs e)
        {
            WhazzupLocation.IsEnabled = false;
        }
        private void WhazzupLocation_TextChanged(object sender, TextChangedEventArgs e)
        {
            MyIni.Write("whazzup", WhazzupLocation.Text, "Data");
        }
        private async void StartStop_Clicked(object sender, RoutedEventArgs e)
        {
            executeMethod = !executeMethod;
            if(executeMethod == true)
            {
                whazzup whazzup_tfl = new whazzup();
                ButtonControlStartStop.Background = Brushes.Red;
                ButtonControlStartStop.Content = "STOP";
                whazzup_tfl.WriteClients();
                ATC_Display_Data();
            }
            else
            {
                ButtonControlStartStop.Background = Brushes.Green;
                ButtonControlStartStop.Content = "START";
                whazzup_tfl.DeleteClients();
                worker.CancelAsync();
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            worker.CancelAsync();
            whazzup_tfl.DeleteClients();
            this.Close();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            whazzup_tfl.UpdateWithFlightPlans();
        }
    }
}
