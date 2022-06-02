using System;
using Newtonsoft.Json;
using JsonSubTypes;

namespace TwoWheels
{
    [JsonConverter(typeof(JsonSubtypes), "is_Accessory")]
    [JsonSubtypes.KnownSubType(typeof(Motorcycle), false)]
    [JsonSubtypes.KnownSubType(typeof(Accessory), true)]
    public abstract class Products
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public double GST { get; set; }
        public bool is_Accessory { get; set; }

        public static double CalculateGST(double price)
        {

            return price * 0.1;
        }

        public static double totalGST()
        {
            double totaltax = 0;
            foreach(var item in Program.theCatalog)
            {
                totaltax += CalculateGST(item.ProductPrice);
            }
            return totaltax;
        }
    }
}

