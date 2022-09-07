﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinFs_Flight_Plan_Injector
{
    class logger
    {
        string path = "log.txt";
        public logger()
        {
            if (!File.Exists(path))
            {
                File.CreateText(path);
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
    }
}
