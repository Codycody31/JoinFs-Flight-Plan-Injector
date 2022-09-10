﻿using System;
using System.IO;

namespace JoinFs_Flight_Plan_Injector
{
    class logger
    {
        string path = "log.txt";
        IniFile MyIni = new IniFile();
        public logger()
        {
            if (!File.Exists(path))
            {
                File.CreateText(path);
            }
        }
        public void info(string log, string source, string sourcefunction, int Debug = 0)
        {
            using (StreamWriter stream = new FileInfo(path).AppendText())
            {
                if(MyIni.KeyExists("Level", "Debug"))
                {
                    if (Convert.ToInt32(MyIni.Read("Level", "Debug")) >= Debug)
                    {
                        stream.WriteLine(DateTime.Now.ToString("ddHHmmss") + " INFO : " + Debug.ToString() + " : " + source + " : " + sourcefunction + " : " + log);
                    }
                }
                else if (Debug == 0)
                {
                    stream.WriteLine(DateTime.Now.ToString("ddHHmmss") + " INFO : " + source + " : " + sourcefunction + " : " + log);
                }

            }
        }
        public void error(string log, string source, string sourcefunction, int Debug = 0)
        {
            using (StreamWriter stream = new FileInfo(path).AppendText())
            {
                if (MyIni.KeyExists("Level", "Debug"))
                {
                    if (Convert.ToInt32(MyIni.Read("Level", "Debug")) >= Debug)
                    {
                        stream.WriteLine(DateTime.Now.ToString("ddHHmmss") + " ERROR : " + Debug.ToString() + " : " + source + " : " + sourcefunction + " : " + log);
                    }
                }
                else if (Debug == 0)
                {
                    stream.WriteLine(DateTime.Now.ToString("ddHHmmss") + " ERROR : " + source + " : " + sourcefunction + " : " + log);
                }
            }
        }
        public void status(string log, string source, string sourcefunction, int Debug = 0)
        {
            using (StreamWriter stream = new FileInfo(path).AppendText())
            {
                if (MyIni.KeyExists("Level", "Debug"))
                {
                    if (Convert.ToInt32(MyIni.Read("Level", "Debug")) >= Debug)
                    {
                        stream.WriteLine(DateTime.Now.ToString("ddHHmmss") + " STATUS : " + Debug.ToString() + " : " + source + " : " + sourcefunction + " : " + log);
                    }
                }
                else if (Debug == 0)
                {
                    stream.WriteLine(DateTime.Now.ToString("ddHHmmss") + " STATUS : " + source + " : " + sourcefunction + " : " + log);
                }
                
            }
        }
    }
}
