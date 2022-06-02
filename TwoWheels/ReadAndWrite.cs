using System;
using System.IO;
using System.Drawing;
using Console = Colorful.Console;
namespace TwoWheels
{
	public class ReadAndWrite
	{
		private static string _folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Catalogs");
		public static string FolderPath { get => _folderPath; }

        public static void CheckFolderStructure()
        {
            Console.WriteLine("Checking Folder Structure...", Color.DarkGreen);
            if (!Directory.Exists(FolderPath))
            {
                Console.WriteLine("Creating Catalog folder");
                Directory.CreateDirectory(FolderPath);
                Console.WriteLine("creating ", Path.Combine(FolderPath, "Default_Catalog.json"));
                File.Create(Path.Combine(FolderPath, "Default_Catalog.json")).Close();
                File.WriteAllText(Path.Combine(FolderPath, "Default_Catalog.json"), "{}");
            }
            else
            {
                Console.WriteLine("Folder structure ready.", Color.DarkGreen);
            }

        }

        //------------------------------------------------------//

        public static string[] CatalogFiles = new string[] { };

        public static void CollectCatalogs()
        {
            CatalogFiles = Directory.GetFiles(FolderPath, "*.json");
            Console.WriteLine($"getting files from path");
            foreach (var file in CatalogFiles)
            {
                Console.WriteLine(file);
                Console.WriteLine(Path.GetFileName(file));
                Console.WriteLine(Path.GetFileNameWithoutExtension(file));
            }
        }

        public static string CatalogName(int fileIndex)
        {
            return Path.GetFileNameWithoutExtension(ReadAndWrite.CatalogFiles[fileIndex]);
        }
	}
}

