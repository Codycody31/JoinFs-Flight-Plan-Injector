using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace FSHS_Desktop_ATC
{
    class logger
    {
        string path;
        public logger(string LoggerPath = null)
        {
            string path = DateTime.Now.ToString("yyyyMMddHHmmss") + "-log.txt";
            File.CreateText(path);
        }
        public void info(string log)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(DateTime.Now.ToString("ddHHmmss") + "|Info|" + log.ToString());
            }
        }
        public void error(string log)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(DateTime.Now.ToString("ddHHmmss") + "|Error|" + log.ToString());
            }
        }
    }
}
