using System;
using System.Drawing;
using Console = Colorful.Console;
namespace TwoWheels
{
    public class Accessory : Products
    {
        public string AccessoryColor { get; set; }
        public string AccessorySize { get; set; }

        public Accessory
            (
            string name,
            string accessoryColor,
            string accessorySize,
            string productDescription,
            double price
            )
        {
            ProductName = name;
            AccessoryColor = accessoryColor;
            AccessorySize = accessorySize;
            ProductDescription = productDescription;
            ProductPrice = price;
            is_Accessory = true;
        }

        public override string ToString()
        {
            return 
                    $"===============================================\n" +
                    $"Name: {ProductName}\n" +
                    $"Color: {AccessoryColor}\n" +
                    $"Size: {AccessorySize}\n" +
                    $"Description: {WordWrapping(ProductDescription)}\n\n" +
                    $"Price: {string.Format("{0:C2}", ProductPrice).PadLeft(12)}\n" +
                    $"  GST: {string.Format("{0:C2}", GST).PadLeft(12)}\n" +
                    $"Total: {string.Format("{0:C2}", TotalPrice).PadLeft(12)}\n" +
                    $"-----------------------------------------------\n";
        }
    }
}

