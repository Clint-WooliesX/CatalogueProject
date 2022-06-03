using System;
using System.Drawing;
using Console = Colorful.Console;
namespace TwoWheels
{
    public class MenuSystem
    {
        public static void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine(" -- Main Menu --", Color.Yellow);
            Console.Write(" 0. ", Color.Green); Console.WriteLine("Save and quit", Color.White);
            Console.Write(" 1. ", Color.Green); Console.WriteLine("Print Catalog to console", Color.White);
            Console.Write(" 2. ", Color.Green); Console.WriteLine("Add new product to Catalog", Color.White);
            Console.Write(" 3. ", Color.Green); Console.WriteLine("Remove product from Catalog", Color.White);
            Console.Write(" 4. ", Color.Green); Console.WriteLine("*** Delete Catalog! ***", Color.OrangeRed);
            Console.WriteLine();
            Console.Write("Make Selection 0-9: > ", Color.Blue);
            string user_choice = Console.ReadLine();

            switch (user_choice)
            {
                case "0":
                    {
                        // save and quit
                        break;
                    }

                case "1":
                    {
                        Console.Clear();
                        DBmethods.PrintCatalog();
                        MainMenu();
                        break;
                    }
                case "2":
                    {
                        Console.Clear();
                        AddProductMenu();
                        MainMenu();
                        break;
                    }
                case "3":
                    {
                        Console.Clear();
                        RemoveProductMenu();
                        MainMenu();
                        break;
                    }

                case "4":
                    {
                        Console.Clear();
                        DBmethods.DeleteCatalog();
                        MainMenu();
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        MainMenu();
                        break;
                    }
            }
        }

        public static void AddProductMenu()
        {
            Console.WriteLine(" -- Add New Product --",Color.Yellow);
            Console.Write(" 0. ", Color.Green); Console.WriteLine("Return to main menu", Color.White);
            Console.Write(" 1. ", Color.Green); Console.WriteLine("New Motorcycle", Color.White);
            Console.Write(" 2. ", Color.Green); Console.WriteLine("New Accessory", Color.White);
            Console.WriteLine();
            Console.Write("Make Selection 0-9: > ");
            string user_choice = Console.ReadLine();

            switch (user_choice)
            {
                case "0":
                    {
                        Console.Clear();
                        return;
                        break;
                    }

                case "1":
                    {
                        Console.Clear();
                        DBmethods.NewMotorcycle();
                        return;
                        break;
                    }
                case "2":
                    {
                        Console.Clear();
                        DBmethods.NewAccessory();
                        return;
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        return;
                        break;
                    }
            }
        }

        public static void RemoveProductMenu()
        {
            Console.WriteLine(" -- !!!Remove Product!!! --", Color.Yellow);
            Console.WriteLine("Record# - Name:", Color.Yellow);

            if (Program.theCatalog.Count == 0) Console.WriteLine("The catalog is empty!", Color.Magenta);
            foreach (Products record in Program.theCatalog)
            {
                Console.Write($"{Program.theCatalog.IndexOf(record),7}", Color.Green);
                Console.WriteLine($" - {Program.theCatalog[Program.theCatalog.IndexOf(record)].ProductName}");
            }

            Console.WriteLine();

            Console.Write("Record# or Enter to return to prev. menu > ", Color.Blue);
             string user_choice = Console.ReadLine();

            if (user_choice == "")
            {
                Console.Clear();
                return;
            }
            DBmethods.RemoveProduct(user_choice);

            }
        }
    }



