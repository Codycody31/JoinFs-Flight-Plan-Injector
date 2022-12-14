using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace JoinFs_Flight_Plan_Injector
{
    class whazzup   // revision 11
    {
        MySqlConnection conn = new
        MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        logger logger = new logger();
        public whazzup(string? whazzupPath = null)
        {
            logger.info("Started whazzup class", "whazzup", "Initiate", 5);
            try { File.Delete(whazzupPath + "whazzup_TFL.txt"); }
            catch { logger.error("Failed to Delete file whazzup_TFL.txt", "whazzup", "Startup"); }
            try { using (StreamWriter sw = File.CreateText(whazzupPath + "whazzup_TFL.txt")) { sw.WriteLine("!GENERAL\r\nVERSION = 1\r\nRELOAD = 1\r\nUPDATE = 20220830184832\r\nCONNECTED CLIENTS = 0\r\nCONNECTED SERVERS = 41\r\n!CLIENTS\r\n!SERVERS\r\n162.248.88.180:162.248.88.180:Internet:DigitalThemePark:true:999\r\n82.72.118.42:sundowners.fsgg.nl:Internet:FSGG The Netherlands:true:999\r\n24.141.215.250:joinfs.dvfchh.site:Internet:Deer Valley Flying Club:true:999\r\n217.112.83.78:joinfs.helisimmer.com:Internet:HeliSimmer.com:true:999\r\n198.27.64.165:198.27.64.165:Internet:CyberAvia:true:999\r\n74.208.118.105:74.208.118.105:Internet:USAFv Tactical Datalink:true:999\r\n54.86.182.46:joinfs.yoyodyne.cf:Internet:Yoyodyne Hub:true:999\r\n108.45.136.100:100.15.253.55:Internet:EasternHops Community:true:999\r\n65.255.140.205:65.255.140.205:Internet: Flight Unlimited Network:true:999\r\n98.224.91.212:http://www.fsvintageair.com:Internet:FSVintageAIR.com:true:999\r\n91.186.9.180:91.186.9.180:Internet:TTM Flying Circus:true:999\r\n51.75.163.105:www.virtualnato.org:Internet:* Virtual NATO *:true:999\r\n35.199.191.28:35.199.191.28:Internet:Noobs Transport:true:999\r\n76.202.64.190:flightadventures.com:Internet:FlightAdventures VPC:true:999\r\n85.215.204.240:www.ala23virtual.com:Internet:Ala 23 Virtual:true:999\r\n90.70.22.202:90.70.22.202:Internet:NSBSI:true:999\r\n85.214.224.236:85.214.224.236:Internet:Aviatorseindhoven:true:999\r\n51.254.121.191:51.254.121.191:Internet:HAIDF 2.1.5:true:999\r\n148.251.40.117:148.251.40.126:6000:Internet:LCA  Les Copains d'Abord:true:999\r\n82.176.177.179:openairvirtual.eu:Internet:Open:true:999\r\n85.25.248.77:85.25.248.77:Internet:PNW Backcountry Pilots:true:999\r\n212.237.2.68:212.237.2.68:Internet:OVT:true:999\r\n81.159.52.244:81.159.52.244:Internet:UK317 Flight Sim Hub:true:999\r\n109.61.75.220:10.8.0.1:Internet:Blue Sky:true:999\r\n85.214.112.47:85.214.112.47:Internet:FeelFreeAirline:true:999\r\n162.55.223.247:planet.fshub.io:Internet:Planet FsHub:true:999\r\n85.214.63.20:app-derektar.de:Internet:!vGAF01:true:999\r\n94.213.123.56:DutchFlightCrew:Internet:DutchFlightCrew:true:999\r\n217.120.81.9:www.fsclub-friesland.nl:Internet:FSClub Friesland:true:999\r\n82.7.30.151:82.7.30.151:Internet:GFSG:true:999\r\n79.18.227.226:79.18.227.226:Internet:Virtual Over Italy:true:999\r\n49.212.165.206:49.212.165.206:Internet:\"2022\" SHA:true:999\r\n217.120.81.9:www.vliegenmetplezier.com:Internet:VMP:true:999\r\n120.138.19.171:milsim.nz:Internet:vRNZAF:true:999\r\n101.174.47.184:RAAFv:Internet:RAAFv:true:999\r\n81.44.158.247:vuelovirtual.no-ip.org:Internet:VueloVirtual:true:999\r\n73.164.89.159:Saint Paul Airlines:Internet:SPA:true:999\r\n46.182.6.10:46.182.6.10:Internet:Virtual Team Apache MSFS:true:999\r\n201.47.210.96:201.47.210.96:Internet:Servidor Brasil Amigos:true:999\r\n159.180.27.133:192.168.1.158:Internet:Yukon Do It:true:999\r\n77.44.49.59:joinfs.virginxl.uk:Internet:!TFL & Virgin XL!:true:999"); } }
            catch { logger.error("Failed to Create and write to file whazzup_TFL.txt", "whazzup", "Startup"); }
            logger.status("Startup completed!", "whazzup", "Startup");
            var MyIni = new IniFile();

        }
        public string Read(string callsign)
        {
            logger.info("Read function called", "whazzup", "Read", 5);
            var MyIni = new IniFile();
            var path = MyIni.Read("whazzup_tfl", "Data");
            logger.info("Reading whazzup_tfl location from Data", "whazzup", "Read", 5);
            StreamReader? whazzup = null;
            try { whazzup = new StreamReader(File.OpenRead(path)); }
            catch (ArgumentException e) { logger.error(e.ToString(), "whazzup", "Read", 3); }
            catch (DirectoryNotFoundException e) { logger.error(e.ToString(), "whazzup", "Read", 3); }
            catch (UnauthorizedAccessException e) { logger.error(e.ToString(), "whazzup", "Read", 3); }
            catch (FileNotFoundException e) { logger.error(e.ToString(), "whazzup", "Read", 3); }
            catch { logger.error("Failed to OpenRead " + path, "whazzup", "Read"); }
            string whazzup_content = whazzup.ReadToEnd();
            whazzup.Close();
            Match m = Regex.Match(whazzup_content, "^" + callsign + ".*", RegexOptions.Multiline);
            logger.info("Matching row starting with " + callsign, "whazzup", "Read", 5);
            if (m.Success) { return m.Groups[0].Value; }
            else { return "Read failed"; logger.error("Failed to read " + callsign + " info from whazzup_tfl", "whazzup", "Read"); }
        }
        public string WhazzupRead(string callsign, string? VID = null)
        {
            logger.info("WhazzupRead Function called", "whazzup", "WhazzupRead", 5);
            var MyIni = new IniFile();
            var path = MyIni.Read("whazzup", "Data");
            logger.info("Reading whazzup location fron Data", "whazzup", "WhazzupRead", 5);
            StreamReader? whazzup = null;
            try { whazzup = new StreamReader(File.OpenRead(path)); }
            catch (ArgumentException e) { logger.error(e.ToString(), "whazzup", "WhazzupRead", 3); }
            catch (DirectoryNotFoundException e) { logger.error(e.ToString(), "whazzup", "WhazzupRead", 3); }
            catch (UnauthorizedAccessException e) { logger.error(e.ToString(), "whazzup", "WhazzupRead", 3); }
            catch (FileNotFoundException e) { logger.error(e.ToString(), "whazzup", "WhazzupRead", 3); }
            catch { logger.error("Failed to OpenRead " + path, "whazzup", "WhazzupRead"); }
            string whazzup_content = whazzup.ReadToEnd();
            whazzup.Close();
            int FromClients = whazzup_content.IndexOf("!CLIENTS") + "!CLIENTS".Length;
            int ToServers = whazzup_content.LastIndexOf("!SERVERS");
            string CLIENTS = whazzup_content.Substring(FromClients, ToServers - FromClients);
            Match m = Regex.Match(CLIENTS, "^" + callsign + ":" + VID + ".*", RegexOptions.Multiline);
            logger.info("Matching string in CLIENTS containing " + callsign + ":" + VID, "whazzup", "WhazzupRead", 5);
            if (m.Success)
            {
                return m.Groups[0].Value;
            }
            else { return ""; logger.error("Failed to read " + callsign + ":" + VID + " info from whazzup", "whazzup", "WhazzupRead"); }

        }
        public bool ReadCallsignExists(string callsign)
        {
            logger.info("Read Callsign Exists for " + callsign, "whazzup", "ReadCallsignExists", 5);
            var MyIni = new IniFile();
            var path = MyIni.Read("whazzup", "Data");
            logger.info("Reading whazzup location from Data", "whazzup", "ReadCallsignExists", 5);
            StreamReader whazzup = null;
            try { whazzup = new StreamReader(File.OpenRead(path)); }
            catch (ArgumentException e) { logger.error(e.ToString(), "whazzup", "ReadCallsignExists", 3); }
            catch (DirectoryNotFoundException e) { logger.error(e.ToString(), "whazzup", "ReadCallsignExists", 3); }
            catch (UnauthorizedAccessException e) { logger.error(e.ToString(), "whazzup", "ReadCallsignExists", 3); }
            catch (FileNotFoundException e) { logger.error(e.ToString(), "whazzup", "ReadCallsignExists", 3); }
            catch { logger.error("Failed to OpenRead " + path, "whazzup", "ReadCallsignExists"); }
            string whazzup_content = whazzup.ReadToEnd();
            whazzup.Close();
            Match m = Regex.Match(whazzup_content, "^" + callsign + ".*", RegexOptions.Multiline);
            if (m.Success)
            {
                logger.info(callsign + " exists in whazzup", "whazzup", "ReadCallsignExists", 5);
                return true;
            }
            else { return false; }
        }
        public void UpdateWithFlightPlans()
        {
            //TODO: Check ini for custom database and table
            var MyIni = new IniFile();
            logger.info("Function UpdateWithFlightPlans Called", "whazzup", "UpdateWithFlightPlans", 5);
            //open mysql connection
            conn.Open();
            string? UpdatedCLIENTAircraft = null;
            StreamReader? whazzup = null;
            var path = MyIni.Read("whazzup", "Data");
            logger.info("Reading whazzup location from Data", "whazzup", "UpateWithFlightPlans", 5);
            //check if able to open file
            try { whazzup = new StreamReader(File.OpenRead(path)); }
            catch (ArgumentException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans"); }
            catch (DirectoryNotFoundException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch (UnauthorizedAccessException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch (FileNotFoundException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch { logger.error("Failed to Open and Read " + path, "whazzup", "UpdateWithFlightPlans", 3); }

            string whazzup_content = whazzup.ReadToEnd(); whazzup.Close();
            int FromClients = whazzup_content.IndexOf("!CLIENTS") + "!CLIENTS".Length;
            int ToServers = whazzup_content.LastIndexOf("!SERVERS");
            string CLIENTS = whazzup_content.Substring(FromClients, ToServers - FromClients);
            string[] CLIENTSAircraft = CLIENTS.Split('\n');
            logger.info("Extracting information from JoinFs whazzup File", "whazzup", "UpdateWithFlightPlans", 5);
            //figure out how to check flightplan database and add aircraft

            for (int i = 1; i < CLIENTSAircraft.Length - 1; i++)
            {
               
                //inital start works, second fails
                string[] WhazzupAircraftInfo = CLIENTSAircraft[i].Split(':');
                logger.info("Check for aircraft " + WhazzupAircraftInfo[0], "whazzup", "UpdateWithCallsigns", 5);
                MySqlCommand cmd = null;
                MySqlDataReader reader = null;
                try
                {
                    //TODO: allow parsing on of groups own database instead of default
                    cmd = new MySqlCommand("SELECT * FROM flightplan WHERE callsign='" + WhazzupAircraftInfo[0] + "'", conn);
                    reader = cmd.ExecuteReader();
                    logger.info("SQL Query: SELECT * FROM flightplan WHERE callsign=" + WhazzupAircraftInfo[0], "whazzup", "UpdateWithCallsigns", 5);
                }
                catch (MySqlException ex)
                {
                    logger.error(ex.ToString(), "whazzup", "UpdateWithFlightPlans");
                }
                if (reader.Read() == true)
                {
                    logger.info("Appending info to aircraft " + WhazzupAircraftInfo[0], "whazzup", "UpdateWithCallsigns", 5);
                    WhazzupAircraftInfo[11] = reader.GetString("departure");
                    WhazzupAircraftInfo[12] = reader.GetString("cruisingaltitude");
                    WhazzupAircraftInfo[13] = reader.GetString("arrival");
                    WhazzupAircraftInfo[29] = reader.GetString("remarks");
                    WhazzupAircraftInfo[30] = reader.GetString("route");
                    string ReJoinedWhazzupAircraftInfo = string.Join(":", WhazzupAircraftInfo);
                    logger.info(WhazzupAircraftInfo[0] +" updated: " + ReJoinedWhazzupAircraftInfo, "whazzup", "UpdateWithCallsigns", 5);
                    try { UpdatedCLIENTAircraft = UpdatedCLIENTAircraft + ReJoinedWhazzupAircraftInfo; }
                    catch { logger.error("Failed to update variable UpdatedCLIENTAircraft with aircraft + flight plan", "whazzup", "UpdateWithFlightPlans"); }
                }
                else
                {
                    logger.info(WhazzupAircraftInfo[0] + " updated in whazzup", "whazzup", "UpdateWithCallsigns", 5);
                    try { UpdatedCLIENTAircraft = UpdatedCLIENTAircraft + WhazzupRead(WhazzupAircraftInfo[0], WhazzupAircraftInfo[1]).ToString(); }
                    catch { logger.error("Failed to update variable UpdatedCLIENTAircraft", "whazzup", "UpdateWithFlightPlans"); }
                }
                reader.Close();
            }
            conn.Close();
            FileStream fileStream = null;
            try { fileStream = File.Open("whazzup_tfl.txt", FileMode.Open); fileStream.SetLength(0); fileStream.Close(); }
            catch (ArgumentException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch (DirectoryNotFoundException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch (UnauthorizedAccessException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch (FileNotFoundException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch { logger.error("Failed to open whazzup_tfl.txt", "whazzup", "UpdateWithFlightPlans"); }
            try { File.WriteAllText("whazzup_tfl.txt", "!GENERAL\r\nVERSION = 1\r\nRELOAD = 1\r\nUPDATE = 20220830184832\r\nCONNECTED CLIENTS = 0\r\nCONNECTED SERVERS = 41\r\n!CLIENTS\r\n!SERVERS\r\n162.248.88.180:162.248.88.180:Internet:DigitalThemePark:true:999\r\n82.72.118.42:sundowners.fsgg.nl:Internet:FSGG The Netherlands:true:999\r\n24.141.215.250:joinfs.dvfchh.site:Internet:Deer Valley Flying Club:true:999\r\n217.112.83.78:joinfs.helisimmer.com:Internet:HeliSimmer.com:true:999\r\n198.27.64.165:198.27.64.165:Internet:CyberAvia:true:999\r\n74.208.118.105:74.208.118.105:Internet:USAFv Tactical Datalink:true:999\r\n54.86.182.46:joinfs.yoyodyne.cf:Internet:Yoyodyne Hub:true:999\r\n108.45.136.100:100.15.253.55:Internet:EasternHops Community:true:999\r\n65.255.140.205:65.255.140.205:Internet: Flight Unlimited Network:true:999\r\n98.224.91.212:http://www.fsvintageair.com:Internet:FSVintageAIR.com:true:999\r\n91.186.9.180:91.186.9.180:Internet:TTM Flying Circus:true:999\r\n51.75.163.105:www.virtualnato.org:Internet:* Virtual NATO *:true:999\r\n35.199.191.28:35.199.191.28:Internet:Noobs Transport:true:999\r\n76.202.64.190:flightadventures.com:Internet:FlightAdventures VPC:true:999\r\n85.215.204.240:www.ala23virtual.com:Internet:Ala 23 Virtual:true:999\r\n90.70.22.202:90.70.22.202:Internet:NSBSI:true:999\r\n85.214.224.236:85.214.224.236:Internet:Aviatorseindhoven:true:999\r\n51.254.121.191:51.254.121.191:Internet:HAIDF 2.1.5:true:999\r\n148.251.40.117:148.251.40.126:6000:Internet:LCA  Les Copains d'Abord:true:999\r\n82.176.177.179:openairvirtual.eu:Internet:Open:true:999\r\n85.25.248.77:85.25.248.77:Internet:PNW Backcountry Pilots:true:999\r\n212.237.2.68:212.237.2.68:Internet:OVT:true:999\r\n81.159.52.244:81.159.52.244:Internet:UK317 Flight Sim Hub:true:999\r\n109.61.75.220:10.8.0.1:Internet:Blue Sky:true:999\r\n85.214.112.47:85.214.112.47:Internet:FeelFreeAirline:true:999\r\n162.55.223.247:planet.fshub.io:Internet:Planet FsHub:true:999\r\n85.214.63.20:app-derektar.de:Internet:!vGAF01:true:999\r\n94.213.123.56:DutchFlightCrew:Internet:DutchFlightCrew:true:999\r\n217.120.81.9:www.fsclub-friesland.nl:Internet:FSClub Friesland:true:999\r\n82.7.30.151:82.7.30.151:Internet:GFSG:true:999\r\n79.18.227.226:79.18.227.226:Internet:Virtual Over Italy:true:999\r\n49.212.165.206:49.212.165.206:Internet:\"2022\" SHA:true:999\r\n217.120.81.9:www.vliegenmetplezier.com:Internet:VMP:true:999\r\n120.138.19.171:milsim.nz:Internet:vRNZAF:true:999\r\n101.174.47.184:RAAFv:Internet:RAAFv:true:999\r\n81.44.158.247:vuelovirtual.no-ip.org:Internet:VueloVirtual:true:999\r\n73.164.89.159:Saint Paul Airlines:Internet:SPA:true:999\r\n46.182.6.10:46.182.6.10:Internet:Virtual Team Apache MSFS:true:999\r\n201.47.210.96:201.47.210.96:Internet:Servidor Brasil Amigos:true:999\r\n159.180.27.133:192.168.1.158:Internet:Yukon Do It:true:999\r\n77.44.49.59:joinfs.virginxl.uk:Internet:!TFL & Virgin XL!:true:999"); }
            catch (ArgumentException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch (DirectoryNotFoundException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch (UnauthorizedAccessException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch (FileNotFoundException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch { logger.error("Failed to WriteAllText to whazzup_tfl.txt for default content", "whazzup", "UpdateWithFlightPlans"); }
            string text = File.ReadAllText("whazzup_TFL.txt");
            string insertPoint = "!CLIENTS";
            int index = text.IndexOf(insertPoint) + insertPoint.Length;
            text = text.Insert(index, "\n" + UpdatedCLIENTAircraft);
            try { File.WriteAllText("whazzup_tfl.txt", text); }
            catch (ArgumentException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch (DirectoryNotFoundException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch (UnauthorizedAccessException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch (FileNotFoundException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch { logger.error("Failed to WriteAllText for whazzup_tfl.txt", "whazzup", "UpdateWithFlightPlans"); }
            int numLinesClients = CLIENTS.Split('\n').Length - 2;
            try { File.WriteAllText("Whazzup_tfl.txt", File.ReadAllText("whazzup_TFL.txt").Replace("CONNECTED CLIENTS = 0", "CONNECTED CLIENTS = " + numLinesClients.ToString())); }
            catch (ArgumentException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch (DirectoryNotFoundException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch (UnauthorizedAccessException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans", 3); }
            catch (FileNotFoundException e) { logger.error(e.ToString(), "whazzup", "UpdateWithFlightPlans"); }
            catch { logger.error("Failed to update whazzup_tfl with aircraft", "whazzup", "UpdateWithFlightPlans", 3); }
        }
        public void DeleteClients(string? whazzupPath = null)
        {
            try { File.Delete(whazzupPath + "whazzup_TFL.txt"); logger.info("whazzup_tfl.txt deleted", "whazzup", "DeleteClients"); }
            catch { logger.error("Failed to delete file " + whazzupPath + "whazzup_TFL.txt", "whazzup", "DeleteClients"); }
        }
        public void WriteClients()
        {
            logger.info("Function WriteClients Called", "whazzup", "WriteClients", 5);
            var MyIni = new IniFile();
            var path = MyIni.Read("whazzup", "Data");
            if (!File.Exists(MyIni.Read("whazzup_tfl", "Data")))
            {
                logger.info(MyIni.Read("whazzup_tfl", "Data") + " is missing, generating!", "whazzup", "WriteClients");
                try { using (StreamWriter sw = File.CreateText("whazzup_TFL.txt")) { sw.WriteLine("!GENERAL\r\nVERSION = 1\r\nRELOAD = 1\r\nUPDATE = 20220830184832\r\nCONNECTED CLIENTS = 0\r\nCONNECTED SERVERS = 41\r\n!CLIENTS\r\n!SERVERS\r\n162.248.88.180:162.248.88.180:Internet:DigitalThemePark:true:999\r\n82.72.118.42:sundowners.fsgg.nl:Internet:FSGG The Netherlands:true:999\r\n24.141.215.250:joinfs.dvfchh.site:Internet:Deer Valley Flying Club:true:999\r\n217.112.83.78:joinfs.helisimmer.com:Internet:HeliSimmer.com:true:999\r\n198.27.64.165:198.27.64.165:Internet:CyberAvia:true:999\r\n74.208.118.105:74.208.118.105:Internet:USAFv Tactical Datalink:true:999\r\n54.86.182.46:joinfs.yoyodyne.cf:Internet:Yoyodyne Hub:true:999\r\n108.45.136.100:100.15.253.55:Internet:EasternHops Community:true:999\r\n65.255.140.205:65.255.140.205:Internet: Flight Unlimited Network:true:999\r\n98.224.91.212:http://www.fsvintageair.com:Internet:FSVintageAIR.com:true:999\r\n91.186.9.180:91.186.9.180:Internet:TTM Flying Circus:true:999\r\n51.75.163.105:www.virtualnato.org:Internet:* Virtual NATO *:true:999\r\n35.199.191.28:35.199.191.28:Internet:Noobs Transport:true:999\r\n76.202.64.190:flightadventures.com:Internet:FlightAdventures VPC:true:999\r\n85.215.204.240:www.ala23virtual.com:Internet:Ala 23 Virtual:true:999\r\n90.70.22.202:90.70.22.202:Internet:NSBSI:true:999\r\n85.214.224.236:85.214.224.236:Internet:Aviatorseindhoven:true:999\r\n51.254.121.191:51.254.121.191:Internet:HAIDF 2.1.5:true:999\r\n148.251.40.117:148.251.40.126:6000:Internet:LCA  Les Copains d'Abord:true:999\r\n82.176.177.179:openairvirtual.eu:Internet:Open:true:999\r\n85.25.248.77:85.25.248.77:Internet:PNW Backcountry Pilots:true:999\r\n212.237.2.68:212.237.2.68:Internet:OVT:true:999\r\n81.159.52.244:81.159.52.244:Internet:UK317 Flight Sim Hub:true:999\r\n109.61.75.220:10.8.0.1:Internet:Blue Sky:true:999\r\n85.214.112.47:85.214.112.47:Internet:FeelFreeAirline:true:999\r\n162.55.223.247:planet.fshub.io:Internet:Planet FsHub:true:999\r\n85.214.63.20:app-derektar.de:Internet:!vGAF01:true:999\r\n94.213.123.56:DutchFlightCrew:Internet:DutchFlightCrew:true:999\r\n217.120.81.9:www.fsclub-friesland.nl:Internet:FSClub Friesland:true:999\r\n82.7.30.151:82.7.30.151:Internet:GFSG:true:999\r\n79.18.227.226:79.18.227.226:Internet:Virtual Over Italy:true:999\r\n49.212.165.206:49.212.165.206:Internet:\"2022\" SHA:true:999\r\n217.120.81.9:www.vliegenmetplezier.com:Internet:VMP:true:999\r\n120.138.19.171:milsim.nz:Internet:vRNZAF:true:999\r\n101.174.47.184:RAAFv:Internet:RAAFv:true:999\r\n81.44.158.247:vuelovirtual.no-ip.org:Internet:VueloVirtual:true:999\r\n73.164.89.159:Saint Paul Airlines:Internet:SPA:true:999\r\n46.182.6.10:46.182.6.10:Internet:Virtual Team Apache MSFS:true:999\r\n201.47.210.96:201.47.210.96:Internet:Servidor Brasil Amigos:true:999\r\n159.180.27.133:192.168.1.158:Internet:Yukon Do It:true:999\r\n77.44.49.59:joinfs.virginxl.uk:Internet:!TFL & Virgin XL!:true:999"); } }
                catch { logger.error("Failed to Create and write to file whazzup_TFL.txt", "whazzup", "WriteClients"); }
            }
            StreamReader whazzup = null;
            try { whazzup = new StreamReader(File.OpenRead(path)); }
            catch { logger.error("Failed to Open whazzup_tfl.txt", "whazzup", "WriteClients"); }

            string whazzup_content = whazzup.ReadToEnd();
            whazzup.Close();
            int FromClients = whazzup_content.IndexOf("!CLIENTS") + "!CLIENTS".Length;
            int ToServers = whazzup_content.LastIndexOf("!SERVERS");
            string CLIENTS = whazzup_content.Substring(FromClients, ToServers - FromClients);

            string text = null;
            try { text = File.ReadAllText("whazzup_TFL.txt"); }
            catch { logger.error("Failed to ReadAllText of whazzup_TFL.txt", "whazzup", "WriteClients"); }
            string insertPoint = "!CLIENTS";
            int index = text.IndexOf(insertPoint) + insertPoint.Length;
            text = text.Insert(index, CLIENTS);
            try { File.WriteAllText("whazzup_TFL.txt", text); }
            catch { logger.error("Failed WriteAllText to whazzup_TFL.txt", "whazzup", "WriteClients"); }
            int numLinesClients = CLIENTS.Split('\n').Length - 2;
            try { File.WriteAllText("Whazzup_TFL.txt", File.ReadAllText("whazzup_TFL.txt").Replace("CONNECTED CLIENTS = 0", "CONNECTED CLIENTS = " + numLinesClients.ToString())); }
            catch { logger.error("Failed to write to whazzup_tfl", "whazzup", "WriteClients"); }
        }
    }
}
