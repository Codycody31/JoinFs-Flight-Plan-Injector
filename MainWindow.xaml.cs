using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MahApps.Metro;
namespace JoinFs_Flight_Plan_Injector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        // Enable self-contained for built in .net 6.0. Default set to framework dependent
        bool executeMethod;
        logger logger = new logger();
        whazzup whazzup_tfl = new whazzup();
        IniFile MyIni = new IniFile();
        WhazzupFile WhazzupFile = new WhazzupFile();
        string path = "log.txt";
        public MainWindow()
        {
            InitializeComponent();
            if (!File.Exists(path))
            {
                File.CreateText(path);
            }
            if (!File.Exists("LICENSE.txt"))
            {
                using (StreamWriter sw = File.CreateText("LICENSE.txt"))
                {
                    sw.WriteLine("MIT License\r\n\r\nCopyright (c) 2022 Vahn Melendez Gomes\r\n\r\nPermission is hereby granted, free of charge, to any person obtaining a copy\r\nof this software and associated documentation files (the \"Software\"), to deal\r\nin the Software without restriction, including without limitation the rights\r\nto use, copy, modify, merge, publish, distribute, sublicense, and/or sell\r\ncopies of the Software, and to permit persons to whom the Software is\r\nfurnished to do so, subject to the following conditions:\r\n\r\nThe above copyright notice and this permission notice shall be included in all\r\ncopies or substantial portions of the Software.\r\n\r\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR\r\nIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,\r\nFITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE\r\nAUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER\r\nLIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,\r\nOUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE\r\nSOFTWARE.");
                    logger.info("log.txt created!", "MainWindow", "Startup");
                    logger.info("LICENSE.txt created!", "MainWindow", "Startup");
                }
            }
            if (!File.Exists("tfl-flightplan.sql"))
            {
                using (StreamWriter sw = File.CreateText("tfl-flightplan.sql"))
                {
                    sw.WriteLine("SET SQL_MODE = \"NO_AUTO_VALUE_ON_ZERO\";\r\nSTART TRANSACTION;\r\nSET time_zone = \"+00:00\";\r\nCREATE TABLE `flightplan` (\r\n  `id` int(11) NOT NULL,\r\n  `callsign` varchar(10) NOT NULL,\r\n  `aircraft` varchar(10) NOT NULL,\r\n  `departure` varchar(4) NOT NULL,\r\n  `arrival` varchar(4) NOT NULL,\r\n  `route` varchar(250) NOT NULL,\r\n  `remarks` varchar(250) NOT NULL,\r\n  `cruisingaltitude` varchar(10) NOT NULL,\r\n  `flightrule` varchar(10) NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;\r\nALTER TABLE `flightplan`\r\n  ADD PRIMARY KEY (`id`);\r\n\r\nALTER TABLE `flightplan`\r\n  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;\r\nCOMMIT;");
                    logger.info("tfl-flightplan.sql created!", "MainWindow", "Startup");
                }
            }
            if (!File.Exists("ReadMe.txt"))
            {
                using (StreamWriter sw = File.CreateText("Readme.txt"))
                {
                    sw.WriteLine("Use the attached tfl-flightplan.sql file to create the MySQL Database;\r\nthen just add the information of the flight and start the Updater!\r\nIf something isn't showing always check the log file;\r\nOne more thing, the application must run twice for the first time! One to add files and two to for the GUI.\r\nAfter this if you don't remove any files it will work fine!\r\n\r\nAdd Debug mode:\r\n[Debug]\r\nLevel=0-5\r\nCreated by: Vahn Gomes, copyright 2022.");
                    logger.info("ReadMe.txt created!", "MainWindow", "Startup");
                }
            }
            if (!File.Exists("Manual.txt")) { }
            if (!MyIni.KeyExists("DefaultVolume", "Audio"))
            {
                MyIni.Write("DefaultVolume", "100", "Audio");
                MyIni.Write("FSHS", "https://dev.fshs.info", "Web");
                MyIni.Write("TFL", "https://tflserver.com", "Web");
                MyIni.Write("VG", "https://vahngomes.dev", "Web");
                MyIni.Write("version", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(), "Data");
                MyIni.Write("ThreadUpdateSpeed", "500", "Data");
            }
            if (!MyIni.KeyExists("whazzup", "Data"))
            {
                MyIni.Write("whazzup", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\JoinFS-FSX\\whazzup.txt", "Data");
            }
            WhazzupLocation.Text = MyIni.Read("whazzup", "Data");
            MyIni.Write("whazzup_TFL", "whazzup_TFL.txt", "Data");
            if (!File.Exists(MyIni.Read("whazzup", "Data")))
            {

                MyIni.Write("whazzup", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\JoinFS-FSX\\whazzup.txt", "Data");
                logger.error("whazzup file location invalid!", "MainWindow", "Startup");
                MessageBox.Show("whazzup file location invalid!");
            }
            logger.status("Startup completed!", "MainWindow", "Startup");
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            logger.status("Shutdown completed!\n", "MainWindow", "Suspension");
        }
        public string CurrentPath
        {
            get
            {
                return "V " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + "-x64";
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
                    logger.info("Stopped Background Worker", "MainWindow", "ATC_Display_Data()");
                }
                catch
                {
                    logger.error("Failed to Stop Background Worker", "MainWindow", "ATC_Display_Data()");
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
                    logger.info("Started worker_DoWork", "MainWindow", "ATC_Display_Data");
                }
                catch
                {
                    logger.error("Failed to Start Background Worker", "MainWindow", "ATC_Display_Data");
                }
            }
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            logger.info("Started whazzup_tfl background worker", "MainWindow", "worker_DoWork");
            for (int i = 0; i < 6000; i++)
            {
                var ThreadSleepTime = MyIni.Read("ThreadUpdateSpeed", "Data");
                logger.info("Updating Flight Plans", "MainWindow", "worker_DoWork", 5);
                whazzup_tfl.UpdateWithFlightPlans();
                try { whazzup_tfl.UpdateWithFlightPlans(); }
                catch { logger.error("Failed to confirm that whazzup_tfl updated successfully", "MainWindow", "worker_DoWork"); ATC_Display_Data(true); }
                finally { Thread.Sleep(Convert.ToInt32(ThreadSleepTime)); }
            }
            logger.info("Stopped whazzup_tfl background worker", "MainWindow", "worker_DoWork");
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
                SpecifyWhazzupLocation.IsChecked = true;
                WhazzupLocation.IsEnabled = true;
            }
            catch
            {
                logger.error("Failed to set WhazzupLocation as enabled", "MainWindow", "SpecifyWhazzupLocation");
            }
        }
        private void SpecifyWhazzupLocation_UnChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                SpecifyWhazzupLocation.IsChecked = false;
                WhazzupLocation.IsEnabled = false;
            }
            catch
            {
                logger.error("Failed to set WhazzupLocation as disabled", "MainWindow", "SpecifyWhazzupLocation");
            }
        }
        private void WhazzupLocation_TextChanged(object sender, TextChangedEventArgs e)
        {
            try { MyIni.Write("whazzup", WhazzupLocation.Text, "Data"); }
            catch { logger.error("Failed to update WhazzupLocation in ini file", "MainWindow", "WhazzupLocation"); }
        }
        private void StartStop_Clicked(object sender, RoutedEventArgs e)
        {
            executeMethod = !executeMethod;
            if (executeMethod == true)
            {
                if (TFL.IsChecked == true && Other.IsChecked == false || TFL.IsChecked == false && Other.IsChecked == true)
                {
                    logger.info("Injector Started", "MainWindow", "Start-Stop");
                    ButtonControlStartStop.Background = Brushes.Red;
                    ButtonControlStartStop.Content = "STOP";
                    try { whazzup_tfl.WriteClients(); }
                    catch{logger.error("Failed to Write Clients", "MainWindow", "Start-Stop", 2);}
                    try { ATC_Display_Data(); }
                    catch { logger.error("Failed to start worker", "MainWindow", "Start-Stop"); }

                }
                else
                {
                    logger.error("Failed to start injector, Data sources need to be selected", "MainWindow", "Start-Stop");
                    try { new IniFile(); }
                    catch { logger.error("Failed to create new Ini File", "MainWindow", "Start-Stop"); }
                    MessageBox.Show("Data sources need to be selected correctly!");
                    executeMethod = false;
                }
            }
            else
            {
                logger.info("Injector Stopped\n", "MainWindow", "Start-Stop");
                ButtonControlStartStop.Background = Brushes.Green;
                ButtonControlStartStop.Content = "START";
                try { ATC_Display_Data(true); }
                catch { logger.error("Failed to stop worker", "MainWindow", "Start-Stop"); }
                try { whazzup_tfl.DeleteClients(); }
                catch { logger.error("Failed to Delete whazzup clients", "MainWindow", "Start-Stop"); new IniFile(); }

            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            logger.info("JoinFs Flight Plan Injector Closed\n", "MainWindow", "Close");
            try { ATC_Display_Data(true); }
            catch { logger.error("Failed to stop worker", "MainWindow", "Close"); }
            try { whazzup_tfl.DeleteClients(); }
            catch { logger.error("Failed to Delete whazzup clients", "MainWindow", "Close"); }
            this.Close();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            logger.info("Manual whazzup updater triggered", "MainWindow", "Update");
            try
            {
                whazzup_tfl.UpdateWithFlightPlans();
            }
            catch
            {
                logger.error("Failed to manually call whazzup_tfl.UpdateWithFlightPlans()", "MainWindow", "Update");
            }
        }
        private void Other_UnChecked(object sender, RoutedEventArgs e)
        {
            TFL.IsChecked = true;
        }
        private void Other_Checked(object sender, RoutedEventArgs e)
        {
            TFL.IsChecked = false;
        }
        //not in use
        private void MainWindow_Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Owner = this;
            settings.Show();
        }
    }
}
