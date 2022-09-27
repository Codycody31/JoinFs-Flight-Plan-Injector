using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinFs_Flight_Plan_Injector
{
    //TODO: add class for reading all information of whazzup file, publish to website
    //INFO: Not ready to be used yet!
    public class WhazzupFile
    {
        string whazzupPath = null;
        logger log = new logger();
        public WhazzupFile(string? whazzupPath = null)
        {
            string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (string.IsNullOrWhiteSpace(whazzupPath))
            {
                if (Directory.Exists(MyDocuments + "\\JoinFS-FSX\\whazzup.txt")){whazzupPath = MyDocuments + "\\JoinFS-FSX\\whazzup.txt";}
                else if(Directory.Exists(MyDocuments + "\\JoinFS\\whazzup.txt")){whazzupPath = MyDocuments + "\\JoinFS\\whazzup.txt";}
                else{log.error(new ArgumentNullException("Whazzup Path").ToString(), "WhazzupFile", "WhazzupFile", 0);
                    throw new ArgumentNullException("Whazzup Path");}
            }
            else
            {
                if (Directory.Exists(whazzupPath)) {}
                else
                {
                    log.error(new ArgumentNullException("Whazzup Path").ToString(), "WhazzupFile", "Startup", 0);
                }
            }

        }
        public class General
        {

        }
        public class Clients
        {

        }
        public class Servers
        {

        }
    }
}
