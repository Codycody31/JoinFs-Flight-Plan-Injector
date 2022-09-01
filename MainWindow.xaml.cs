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
        public void ATC_Display_Data(bool cancel = false)
        {
            BackgroundWorker worker = new BackgroundWorker();
            if (cancel == true)
            {
                worker.WorkerReportsProgress = false;
                worker.WorkerSupportsCancellation = true;
                worker.DoWork += worker_DoWork;
                worker.CancelAsync();
            }
            else
            {
                worker.WorkerReportsProgress = false;
                worker.WorkerSupportsCancellation = true;
                worker.DoWork += worker_DoWork;
                worker.RunWorkerAsync();
            }
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i = 0; i < 600; i++)
            {
                whazzup_tfl.UpdateWithFlightPlans();
                //MessageBox.Show(i.ToString());
                //Update every 1 seconds
                Thread.Sleep(1000);
            }
            CheckATC();  
        }
        void CheckATC()
        {
            if (Process.GetProcessesByName("VRC").Length > 0)
            {
                // Is running
                ATC_Display_Data();
            }
            else
            {
                ATC_Display_Data(true);
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
                ButtonControlStartStop.Background = Brushes.Red;
                ButtonControlStartStop.Content = "STOP";
                whazzup_tfl.WriteClients();
                ATC_Display_Data();
            }
            else
            {
                ButtonControlStartStop.Background = Brushes.Green;
                ButtonControlStartStop.Content = "START";
                ATC_Display_Data(true);
                whazzup_tfl.DeleteClients();
                
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            ATC_Display_Data(true);
            whazzup_tfl.DeleteClients();
            this.Close();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            whazzup_tfl.UpdateWithFlightPlans();
        }
    }
}
