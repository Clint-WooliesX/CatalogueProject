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
        public double ProductPrice{get; set;}
        public double GST {get{return CalculateGST(ProductPrice);} set{}}
        public double TotalPrice { get { return ProductPrice + CalculateGST(ProductPrice); } set { } }
        public bool is_Accessory { get; set; }

        public static double CalculateGST(double price)
        {

            return price * 0.1;
        }

        public static double totalGST()
        {
            double totaltax = 0;
            foreach (var item in Program.theCatalog)
            {
                totaltax += CalculateGST(item.ProductPrice);
            }
            return totaltax;
        }

        public static string WordWrapping(string text)
        {
            var words = text.Split(' ');
            var lines = words.Skip(1).Aggregate(words.Take(1).ToList(), (l, w) =>
            {
                if (l.Last().Length + w.Length >= 50)
                    l.Add(w);
                else
                    l[l.Count - 1] += " " + w;
                return l;
            });
            string Wrapped = "";
            foreach (string line in lines)
            {
                Wrapped += "\n" + line ;
            }
            return Wrapped;
        }
    }
}

