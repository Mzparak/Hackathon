using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EkunduConfig;
using Newtonsoft.Json;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            RestGetSimulation();
            RestPostSimulation();
        }

        private static void RestGetSimulation ()
        {
            //NB: Filter Codes PT = Peril Type, PG = Peril Group, RS = Rating Section
            EkunduConfig.Lib ekunduConfigLib = new EkunduConfig.Lib();
            string json = ekunduConfigLib.GetRisk("HSTGIAD", "RS");
            File.WriteAllText(@"C:\Test.json", json);
        }

        private static void RestPostSimulation()
        {
            StreamReader sr = new StreamReader(@"C:\Test.json");
            string jsonString = sr.ReadToEnd();
            EkunduConfig.Lib ekunduConfigLib = new EkunduConfig.Lib();
            ekunduConfigLib.GenerateXml(jsonString);
        }
    }
}
