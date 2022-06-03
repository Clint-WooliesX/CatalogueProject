using System;
using System.Drawing;
using Console = Colorful.Console;
namespace TwoWheels
{
    public class Motorcycle : Products
    {
        public string MotorcycleMake { get; set; }
        public string MotorcycleModel { get; set; }

        public Motorcycle
            (
            string name,
            string make,
            string model,
            string description,
            double price
            )
        {
            ProductName = name;
            MotorcycleMake = make;
            MotorcycleModel = model;
            ProductDescription = description;
            ProductPrice = price;
            is_Accessory = false;

    }

        public override string ToString()
        {
            return 
                    $"===============================================\n" +
                    $"Name: {ProductName}\n" +
                    $"Make: {MotorcycleMake}\n" +
                    $"Model: {MotorcycleModel}\n" +
                    $"Description: {WordWrapping(ProductDescription)}\n\n" +
                    $"Price: {string.Format("{0:C2}", ProductPrice).PadLeft(12)}\n" +
                    $"  GST: {string.Format("{0:C2}", GST).PadLeft(12)}\n" +
                    $"Total: {string.Format("{0:C2}", TotalPrice).PadLeft(12)}\n" +
                    $"-----------------------------------------------\n";
        }
    }
}

