﻿using System;
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
    public partial class MainWindow : Window
    {
        bool executeMethod;
        whazzup whazzup_tfl = new whazzup();
        IniFile MyIni = new IniFile();
        string path = "log.txt";
        public MainWindow()
        {
            InitializeComponent();
            if (!File.Exists("log.txt"))
            {
                File.CreateText("log.txt");
            }
            if (!File.Exists("LICENSE.txt")) { 
                using(StreamWriter sw = File.CreateText("LICENSE.txt"))
                {
                    sw.WriteLine("MIT License\r\n\r\nCopyright (c) 2022 Vahn Melendez Gomes\r\n\r\nPermission is hereby granted, free of charge, to any person obtaining a copy\r\nof this software and associated documentation files (the \"Software\"), to deal\r\nin the Software without restriction, including without limitation the rights\r\nto use, copy, modify, merge, publish, distribute, sublicense, and/or sell\r\ncopies of the Software, and to permit persons to whom the Software is\r\nfurnished to do so, subject to the following conditions:\r\n\r\nThe above copyright notice and this permission notice shall be included in all\r\ncopies or substantial portions of the Software.\r\n\r\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR\r\nIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,\r\nFITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE\r\nAUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER\r\nLIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,\r\nOUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE\r\nSOFTWARE.");
                }
            }
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
        public void info(string log, string source, string sourcefunction)
        {
            using (StreamWriter stream = new FileInfo(path).AppendText())
            {
                stream.WriteLine(DateTime.Now.ToString("ddHHmmss") + " INFO : " + source + " : " + sourcefunction + " : " + log);
            }
        }
        public void error(string log, string source, string sourcefunction)
        {
            using (StreamWriter stream = new FileInfo(path).AppendText())
            {
                stream.WriteLine(DateTime.Now.ToString("ddHHmmss") + " ERROR : " + source + " : " + sourcefunction + " : " + log);
            }
        }
        public void status(string log, string source, string sourcefunction)
        {
            using (StreamWriter stream = new FileInfo(path).AppendText())
            {
                stream.WriteLine(DateTime.Now.ToString("ddHHmmss") + " STATUS : " + source + " : " + sourcefunction + " : " + log);
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
                try
                {
                    
                    worker.CancelAsync();
                    info("Stopped Background Worker", "MainWindow", "ATC_Display_Data()");
                }
                catch
                {
                    error("Failed to Stop Background Worker", "MainWindow", "ATC_Display_Data()");
                }
            }
            else
            {
                worker.WorkerReportsProgress = false;
                worker.WorkerSupportsCancellation = true;
                worker.DoWork += worker_DoWork;
                try
                {
                    worker.RunWorkerAsync();
                    info("Started Background Worker", "MainWindow", "ATC_Display_Data()");
                }
                catch
                {
                    error("Failed to Start Background Worker", "MainWindow", "ATC_Display_Data()");
                }
            }
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            info("whazzup_tfl Started whazzup_tfl updating", "MainWindow", "worker_DoWork");
            for (int i = 0; i < 600; i++)
            {
                try { whazzup_tfl.UpdateWithFlightPlans(); }
                catch { error("Failed to confirm whazzup_tfl updated", "MainWindow", "worker_DoWork"); ATC_Display_Data(true); MessageBox.Show("Failed to confirm whazzup_tfl updated"); this.Close(); }
                finally { Thread.Sleep(1000); }
            }
            info("whazzup_tfl Stopped whazzup_tfl updating", "MainWindow", "worker_DoWork");
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
            try
            {
                WhazzupLocation.IsEnabled = true;
            }
            catch
            {
                error("Failed to set WhazzupLocation as enabled", "MainWindow", "SpecifyWhazzupLocation");
            }
        }
        private void SpecifyWhazzupLocation_UnChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                WhazzupLocation.IsEnabled = false;
            }
            catch
            {
                error("Failed to set WhazzupLocation as disabled", "MainWindow", "SpecifyWhazzupLocation");
            }
        }
        private void WhazzupLocation_TextChanged(object sender, TextChangedEventArgs e)
        {
            try { MyIni.Write("whazzup", WhazzupLocation.Text, "Data"); }
            catch {error("Failed to update WhazzupLocation in ini file", "MainWindow", "WhazzupLocation"); }
        }
        private async void StartStop_Clicked(object sender, RoutedEventArgs e)
        {
            executeMethod = !executeMethod;
            if (executeMethod == true)
            {
                if (JoinFs.IsChecked == true && TFL.IsChecked == true)
                {
                    info("Updater Started", "MainWindow", "Start-Stop");
                    ButtonControlStartStop.Background = Brushes.Red;
                    ButtonControlStartStop.Content = "STOP";
                    try { whazzup_tfl.WriteClients(); }
                    catch { error("Failed to Setup whazzup File", "MainWindow", "Start-Stop"); IniFile MyIni = new IniFile(); }
                    try { ATC_Display_Data(); }
                    catch { error("Failed to start worker", "MainWindow", "Start-Stop"); }
                    
                }
                else
                {
                    error("Failed Data sources JoinFs and TFL need to be selected", "MainWindow", "Start-Stop");
                    MessageBox.Show("Data sources JoinFs and TFL need to be selected");
                }
            }
            else
            {
                info("Updater Stopped", "MainWindow", "Start-Stop");
                ButtonControlStartStop.Background = Brushes.Green;
                ButtonControlStartStop.Content = "START";
                try { ATC_Display_Data(true); }
                catch { error("Failed to stop worker", "MainWindow", "Start-Stop"); }
                try { whazzup_tfl.DeleteClients(); }
                catch { error("Failed to Delete whazzup clients", "MainWindow", "Start-Stop"); }

            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            info("Updater Closed", "MainWindow", "Close");
            try{ATC_Display_Data(true);}
            catch{error("Failed to stop worker", "MainWindow", "Close");}
            try{whazzup_tfl.DeleteClients();}
            catch{error("Failed to Delete whazzup clients", "MainWindow", "Close");}
            this.Close();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            info("Manual whazzup updater triggered", "MainWindow", "Update");
            try
            {
                whazzup_tfl.UpdateWithFlightPlans();
            }
            catch
            {
                error("Failed to manually call whazzup_tfl.UpdateWithFlightPlans()", "MainWindow", "Update");
            }
        }
    }
}
