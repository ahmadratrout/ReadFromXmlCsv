using System;
using System.Xml.Linq;

namespace OpenWeatherMap
{
    public class Program
    {
        static void Main(string[] args)
        {
            ReadFromXmlFile();
            ReadFromCsvFile();

        }

        private static void ReadFromCsvFile()
        {
            string csvFilePath = "C:\\Users\\AhmadRA\\source\\repos\\ReadFromXmlCsv\\ReadFromXmlCsv\\WeatherData.csv";


            var lines = File.ReadAllLines(csvFilePath);

            for (int i = 1; i < lines.Length; i++)
            {
                var data = lines[i].Split(',');

                string cityName = data[0];
                string temperature = data[1];
                string unit = data[2];

                Console.WriteLine($"City: {cityName}, Temperature: {temperature} {unit}");
            }
        }

        private static void ReadFromXmlFile() {
            string xmlFilePath = "C:\\Users\\AhmadRA\\source\\repos\\ReadFromXmlCsv\\ReadFromXmlCsv\\WeatherData.xml";

            // Load and parse the XML file
            XDocument xmlDoc = XDocument.Load(xmlFilePath);

            // Loop through each city element and extract data
            foreach (var city in xmlDoc.Descendants("City"))
            {
                string cityName = city.Element("Name").Value;
                string temperature = city.Element("Temperature").Value;
                string unit = city.Element("Unit").Value;

                Console.WriteLine($"City: {cityName}, Temperature: {temperature} {unit}");
            }
        }
    }
}
