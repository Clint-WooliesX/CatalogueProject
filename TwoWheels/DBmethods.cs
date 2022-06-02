using System.Drawing;
using Newtonsoft.Json;
using Console = Colorful.Console;

namespace TwoWheels
{
    public class DBmethods
    {
        public static void PrintCatalog()
        {
            if(Program.theCatalog.Count == 0)
            {
                Console.WriteLine("The Catalog is empty.", Color.BlueViolet);
                return;
            }

            foreach (Products record in Program.theCatalog)
            {
                Console.WriteLine($"Record#: {Program.theCatalog.IndexOf(record)}");
                Console.WriteLine(record);
            }

            Console.WriteLine($"Total GST of all products = {Products.totalGST():C2}");
        }

        public static void SaveToFile()
        {
            string jsonObject = JsonConvert.SerializeObject(Program.theCatalog.ToArray());

            Console.WriteLine();
            Console.WriteLine("Succesfully added to Catalog", Color.DarkGreen);

            File.WriteAllText(Program.filePath, jsonObject);
        }

        public static void NewMotorcycle()
        {
            Console.Clear();
            Console.WriteLine("- Add New Motorcyle -", Color.Yellow);

            Console.Write("Name: ", Color.Blue);
            string? input_name = Console.ReadLine();

            Console.Write("Make: ", Color.Blue);
            string? input_make = Console.ReadLine();

            Console.Write("Model: ", Color.Blue);
            string? input_model = Console.ReadLine();

            Console.Write("Description: ", Color.Blue);
            string? input_description = Console.ReadLine();

            Console.Write("Price$: ", Color.Blue);
            string? input_price = Console.ReadLine();

            try
            {
                Motorcycle newMotorcycle = new Motorcycle
                    (
                    name: input_name,
                    make: input_make,
                    model: input_model,
                    description: input_description,
                    price: Convert.ToDouble(input_price)
                    );
                Program.theCatalog.Add(newMotorcycle);
                DBmethods.SaveToFile();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("failed to add - invalid data", Color.OrangeRed);
                MenuSystem.MainMenu();
            }
        }

        public static void NewAccessory()
        {
            Console.Clear();
            Console.WriteLine("- Add New Accessory -", Color.Yellow);

            Console.Write("Name: ", Color.Blue);
            string? input_name = Console.ReadLine();

            Console.Write("Color: ", Color.Blue);
            string? input_color = Console.ReadLine();

            Console.Write("Size: ", Color.Blue);
            string? input_size = Console.ReadLine();

            Console.Write("Description: ", Color.Blue);
            string? input_description = Console.ReadLine();

            Console.Write("Price$: ", Color.Blue);
            string? input_price = Console.ReadLine();


            try
            {
                Accessory newAccessory = new Accessory
                (
                name: input_name,
                accessoryColor: input_color,
                accessorySize: input_size,
                productDescription: input_description,
                price: Convert.ToDouble(input_price)
                );
                Program.theCatalog.Add(newAccessory);
                DBmethods.SaveToFile();
            }

            catch
            {
                Console.Clear();
                Console.WriteLine("failed to add - invalid data", Color.OrangeRed);
                MenuSystem.MainMenu();
            }
        }

        public static void RemoveProduct(string user_choice)
        {
            if (user_choice == "")
            {
                Console.Clear();
                MenuSystem.MainMenu();
            }
            try
            {
                int choice = Convert.ToInt32(user_choice);
                Program.theCatalog.RemoveAt(choice);
                Console.Clear();
                Console.WriteLine("Record succesfully removed and catalog updated", Color.DarkRed);
                MenuSystem.MainMenu();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Invalid selection!", Color.OrangeRed);
                MenuSystem.MainMenu();
            }
        }

        public static void DeleteCatalog()
        {
            Console.WriteLine(" !!! Warning his will permenantly remove the Catalog !!! ", Color.OrangeRed);
            Console.WriteLine(" type YES to proceed or enter nothing to return to main menu ", Color.OrangeRed);
            Console.Write(" Are you sure you want to do this? > ", Color.Blue);
            string user_input = Console.ReadLine();
            if (user_input == "YES")
            {
                Program.theCatalog.Clear();
                SaveToFile();
            }
        }
    }
}
