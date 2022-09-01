using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Shapes;

// Change this to match your program's normal namespace
namespace FSHS_Desktop_ATC
{
    class whazzup   // revision 11
    {
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string whazzupPath;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;
        public whazzup(string whazzupPath = null)
        {
            File.Delete(whazzupPath + "whazzup_TFL.txt");
            using (StreamWriter sw = File.CreateText(whazzupPath + "whazzup_TFL.txt"))
            {
                sw.WriteLine(
                    "!GENERAL\r\nVERSION = 1\r\nRELOAD = 1\r\nUPDATE = 20220830184832\r\nCONNECTED CLIENTS = 0\r\nCONNECTED SERVERS = 41\r\n!CLIENTS\r\n!SERVERS\r\n162.248.88.180:162.248.88.180:Internet:DigitalThemePark:true:999\r\n82.72.118.42:sundowners.fsgg.nl:Internet:FSGG The Netherlands:true:999\r\n24.141.215.250:joinfs.dvfchh.site:Internet:Deer Valley Flying Club:true:999\r\n217.112.83.78:joinfs.helisimmer.com:Internet:HeliSimmer.com:true:999\r\n198.27.64.165:198.27.64.165:Internet:CyberAvia:true:999\r\n74.208.118.105:74.208.118.105:Internet:USAFv Tactical Datalink:true:999\r\n54.86.182.46:joinfs.yoyodyne.cf:Internet:Yoyodyne Hub:true:999\r\n108.45.136.100:100.15.253.55:Internet:EasternHops Community:true:999\r\n65.255.140.205:65.255.140.205:Internet: Flight Unlimited Network:true:999\r\n98.224.91.212:http://www.fsvintageair.com:Internet:FSVintageAIR.com:true:999\r\n91.186.9.180:91.186.9.180:Internet:TTM Flying Circus:true:999\r\n51.75.163.105:www.virtualnato.org:Internet:* Virtual NATO *:true:999\r\n35.199.191.28:35.199.191.28:Internet:Noobs Transport:true:999\r\n76.202.64.190:flightadventures.com:Internet:FlightAdventures VPC:true:999\r\n85.215.204.240:www.ala23virtual.com:Internet:Ala 23 Virtual:true:999\r\n90.70.22.202:90.70.22.202:Internet:NSBSI:true:999\r\n85.214.224.236:85.214.224.236:Internet:Aviatorseindhoven:true:999\r\n51.254.121.191:51.254.121.191:Internet:HAIDF 2.1.5:true:999\r\n148.251.40.117:148.251.40.126:6000:Internet:LCA  Les Copains d'Abord:true:999\r\n82.176.177.179:openairvirtual.eu:Internet:Open:true:999\r\n85.25.248.77:85.25.248.77:Internet:PNW Backcountry Pilots:true:999\r\n212.237.2.68:212.237.2.68:Internet:OVT:true:999\r\n81.159.52.244:81.159.52.244:Internet:UK317 Flight Sim Hub:true:999\r\n109.61.75.220:10.8.0.1:Internet:Blue Sky:true:999\r\n85.214.112.47:85.214.112.47:Internet:FeelFreeAirline:true:999\r\n162.55.223.247:planet.fshub.io:Internet:Planet FsHub:true:999\r\n85.214.63.20:app-derektar.de:Internet:!vGAF01:true:999\r\n94.213.123.56:DutchFlightCrew:Internet:DutchFlightCrew:true:999\r\n217.120.81.9:www.fsclub-friesland.nl:Internet:FSClub Friesland:true:999\r\n82.7.30.151:82.7.30.151:Internet:GFSG:true:999\r\n79.18.227.226:79.18.227.226:Internet:Virtual Over Italy:true:999\r\n49.212.165.206:49.212.165.206:Internet:\"2022\" SHA:true:999\r\n217.120.81.9:www.vliegenmetplezier.com:Internet:VMP:true:999\r\n120.138.19.171:milsim.nz:Internet:vRNZAF:true:999\r\n101.174.47.184:RAAFv:Internet:RAAFv:true:999\r\n81.44.158.247:vuelovirtual.no-ip.org:Internet:VueloVirtual:true:999\r\n73.164.89.159:Saint Paul Airlines:Internet:SPA:true:999\r\n46.182.6.10:46.182.6.10:Internet:Virtual Team Apache MSFS:true:999\r\n201.47.210.96:201.47.210.96:Internet:Servidor Brasil Amigos:true:999\r\n159.180.27.133:192.168.1.158:Internet:Yukon Do It:true:999\r\n77.44.49.59:joinfs.virginxl.uk:Internet:!TFL & Virgin XL!:true:999");
            }
        }
         public string Read(string callsign)
        {
            var MyIni = new IniFile();
            var path = MyIni.Read("whazzup_tfl", "Data");
            StreamReader whazzup = new StreamReader(File.OpenRead(path));
            string whazzup_content = whazzup.ReadToEnd();
            whazzup.Close();
            Match m = Regex.Match(whazzup_content, "^" + callsign + ".*", RegexOptions.Multiline);
            if (m.Success)
            {
                return m.Groups[0].Value;
            }else{return "failed";}
        }
        public string WhazzupRead(string callsign, string VID = null)
        {
            var MyIni = new IniFile();
            var path = MyIni.Read("whazzup", "Data");
            StreamReader whazzup = new StreamReader(File.OpenRead(path));
            string whazzup_content = whazzup.ReadToEnd();
            whazzup.Close();
            int FromClients = whazzup_content.IndexOf("!CLIENTS") + "!CLIENTS".Length;
            int ToServers = whazzup_content.LastIndexOf("!SERVERS");
            string CLIENTS = whazzup_content.Substring(FromClients, ToServers - FromClients);
            Match m = Regex.Match(CLIENTS, "^" + callsign + ":" + VID + ".*", RegexOptions.Multiline);
            if (m.Success)
            {
                return m.Groups[0].Value;
            }
            else { return "failed"; }
        }
        public bool ReadCallsignExists(string callsign)
        {
            var MyIni = new IniFile();
            var path = MyIni.Read("whazzup", "Data");
            StreamReader whazzup = new StreamReader(File.OpenRead(path));
            string whazzup_content = whazzup.ReadToEnd();
            whazzup.Close();
            Match m = Regex.Match(whazzup_content, "^" + callsign + ".*", RegexOptions.Multiline);
            if (m.Success)
            {
                return true;
            }
            else { return false; }
        }
        public void UpdateWithFlightPlans()
        {
            string UpdatedCLIENTAircraft = "";
            conn.Open();
            string sql = "Select * from flightplan";
            MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=;database=tfl;");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            //Ini Configure
            var MyIni = new IniFile();
            var path = MyIni.Read("whazzup", "Data");
            //open file
            StreamReader whazzup = new StreamReader(File.OpenRead(path));
            //extract data
            string whazzup_content = whazzup.ReadToEnd();
            //close file
            whazzup.Close();
            //proccess data
            int FromClients = whazzup_content.IndexOf("!CLIENTS") + "!CLIENTS".Length;
            int ToServers = whazzup_content.LastIndexOf("!SERVERS");
            //whazzup !CLIENTS content
            string CLIENTS = whazzup_content.Substring(FromClients, ToServers - FromClients);
            //whazzup !CLIENTS array of aircraft
            string[] CLIENTSAircraft = CLIENTS.Split('\n');
            //iterate list of aircraft
            for (int i = 1; i < CLIENTSAircraft.Length - 1; i++)
            {
                reader.Read();
                //skip 0 
                string[] WhazzupAircraftInfo = CLIENTSAircraft[i].Split(':');
                if (WhazzupAircraftInfo[0] == reader.GetString("callsign"))
                {
                    /* 1 Callsign
                    * 2 VID
                    * 3 Name
                    * 4 Client Type
                    * 5 Frequency
                    * 6 Latitude
                    * 7 Longitude
                    * 8 Altitude
                    * 9 Ground Speed
                    * 10 Flightplan: Aircraft
                    * 11 Flightplan: Cruising Speed
                    * 11 Flightplan: Departure Aerodrome
                    * 12 Flightplan: Cruising Level
                    * 13 Flightplan: Destination Aerodrome
                    * 18 Transponder Code
                    * 22 Flightplan: flight rules
                    * 28 Flightplan: Alternate Aerodrome
                    * 29 Flightplan: item 18 (other info)
                    * 30 Flightplan: route
                    */
                    WhazzupAircraftInfo[11] = reader.GetString("departure");
                    WhazzupAircraftInfo[13] = reader.GetString("arrival");
                    WhazzupAircraftInfo[29] = reader.GetString("remarks");
                    WhazzupAircraftInfo[30] = reader.GetString("route");
                    string ReJoinedWhazzupAircraftInfo = string.Join(":", WhazzupAircraftInfo);
                    //File.WriteAllText("Whazzup_TFL.txt", File.ReadAllText("whazzup_TFL.txt").Replace(CLIENTSAircraft[i].ToString(), WhazzupRead(WhazzupAircraftInfo[0].ToString())));
                    UpdatedCLIENTAircraft = UpdatedCLIENTAircraft + ReJoinedWhazzupAircraftInfo;
                }
                else
                {
                    try
                    {
                        UpdatedCLIENTAircraft = UpdatedCLIENTAircraft + WhazzupRead(WhazzupAircraftInfo[0], WhazzupAircraftInfo[1]).ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Please ignore:\n" + WhazzupRead(WhazzupAircraftInfo[0]).ToString());
                    }
                    
                }
            }
            conn.Close();
            con.Close();
            var path_tfl = MyIni.Read("whazzup_tfl", "Data");
            //open file
            StreamReader whazzup_tfl = new StreamReader(File.OpenRead(path));
            //extract data
            string whazzup_content_tfl = whazzup_tfl.ReadToEnd();
            //close file
            whazzup_tfl.Close();
            //proccess data
            int FromClients_tfl = whazzup_content_tfl.IndexOf("!CLIENTS") + "!CLIENTS".Length;
            int ToServers_tfl = whazzup_content_tfl.LastIndexOf("!SERVERS");
            //whazzup !CLIENTS content
            string CLIENTS_tfl = whazzup_content_tfl.Substring(FromClients_tfl, ToServers_tfl - FromClients_tfl);
            MessageBox.Show(CLIENTS_tfl);
            MessageBox.Show(UpdatedCLIENTAircraft);
            File.WriteAllText("Whazzup_TFL.txt", 
                File.ReadAllText("whazzup_TFL.txt").Replace(
                    CLIENTS_tfl, 
                    "\n" + UpdatedCLIENTAircraft
                    )
                );
            MessageBox.Show(File.ReadAllText("whazzup_tfl.txt"));
            CLIENTS_tfl = null;
            UpdatedCLIENTAircraft = null;
            //overwrite !CLIENTS section of file
            //get callsign
            //check if callsign in database
            //if in database
            //append with details to whazzup
            //if not in database
            //append or replace in whazzup

            /*
            while (reader.Read())
            {
                if (ReadCallsignExists(reader.GetString("callsign")) == true)
                {
                    if (!Read(reader.GetString("callsign")).Contains(reader.GetString("departure")) 
                        && reader.GetString("departure") != null && reader.GetString("departure") != "")
                    {
                        string[] WhazzupAircraftInfo = Read(reader.GetString("callsign")).Split(':');
                        /* 1 Callsign
                         * 2 VID
                         * 3 Name
                         * 4 Client Type
                         * 5 Frequency
                         * 6 Latitude
                         * 7 Longitude
                         * 8 Altitude
                         * 9 Ground Speed
                         * 10 Flightplan: Aircraft
                         * 11 Flightplan: Cruising Speed
                         * 11 Flightplan: Departure Aerodrome
                         * 12 Flightplan: Cruising Level
                         * 13 Flightplan: Destination Aerodrome
                         * 18 Transponder Code
                         * 22 Flightplan: flight rules
                         * 28 Flightplan: Alternate Aerodrome
                         * 29 Flightplan: item 18 (other info)
                         * 30 Flightplan: route
                         */
            /*
           WhazzupAircraftInfo[11] = reader.GetString("departure");
           WhazzupAircraftInfo[13] = reader.GetString("arrival");
           WhazzupAircraftInfo[29] = reader.GetString("remarks");
           WhazzupAircraftInfo[30] = reader.GetString("route");
           string restOfArray = string.Join(":", WhazzupAircraftInfo);
           File.WriteAllText("Whazzup_TFL.txt", File.ReadAllText("whazzup_TFL.txt").Replace(Read(reader.GetString("callsign")), restOfArray));
       }
       else
       {
           MessageBox.Show("Other error");
       }
   }
   else
   {
   }

}
conn.Close();
*/
        }
        public void DeleteClients(string whazzupPath = null)
        {
            File.Delete(whazzupPath + "whazzup_TFL.txt");
        }
        public void WriteClients()
        {
            var MyIni = new IniFile();
            var path = MyIni.Read("whazzup", "Data");
            StreamReader whazzup = new StreamReader(File.OpenRead(path));
            string whazzup_content = whazzup.ReadToEnd();
            whazzup.Close();
            int FromClients = whazzup_content.IndexOf("!CLIENTS") + "!CLIENTS".Length;
            int ToServers = whazzup_content.LastIndexOf("!SERVERS");
            string CLIENTS = whazzup_content.Substring(FromClients, ToServers - FromClients);

            string text = File.ReadAllText("whazzup_TFL.txt");
            string insertPoint = "!CLIENTS";
            int index = text.IndexOf(insertPoint) + insertPoint.Length;
            text = text.Insert(index, CLIENTS);
            File.WriteAllText("whazzup_TFL.txt", text);
            int numLinesClients = CLIENTS.Split('\n').Length - 2;
            File.WriteAllText("Whazzup_TFL.txt", File.ReadAllText("whazzup_TFL.txt").Replace("CONNECTED CLIENTS = 0", "CONNECTED CLIENTS = " + numLinesClients.ToString()));  
        }
        /*
        public bool KeyExists(string callsign)
        {
            
        }
        */
    }
}