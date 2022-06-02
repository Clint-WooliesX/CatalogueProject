using System;
using Newtonsoft.Json;
using System.Drawing;
using Console = Colorful.Console;
using JsonSubTypes;

namespace TwoWheels // Note: actual namespace depends on the project name.
{
    internal class Program
    {


        public static List<Products> theCatalog = new List<Products>();
        public static string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Catalogs");
        public static string filePath = Path.Combine(folderPath, "Default_Catalog.json");
        public static string readData = File.ReadAllText(Path.Combine(folderPath, "Default_Catalog.json"));


        static void Main(string[] args)
        {

            Console.WriteLine("Starting App...", Color.DarkGreen);

            ReadAndWrite.CheckFolderStructure();

            theCatalog = JsonConvert.DeserializeObject<List<Products>>(readData);

            MenuSystem.MainMenu();

            DBmethods.SaveToFile();
        }

    }
}
