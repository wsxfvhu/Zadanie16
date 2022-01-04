using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Zadacha16_1;

namespace Zadacha16_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int j = 0;
            decimal price = 0;
            String path = "C:/Products.json";
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            Product[] products = new Product[5];
            StreamReader sr = new StreamReader(path);
            for (int i = 0; i < products.Length; i++)
            {
                string read = sr.ReadLine();
                products[i] = JsonSerializer.Deserialize<Product>(read, options);
                if (price < products[i].ProductPrice)
                { 
                    price = products[i].ProductPrice; 
                    j=i;
                }
            }
            sr.Close();
            Console.WriteLine($"Самый дорогой товар - {products[j].ProductName}");
            Console.ReadKey();
        }
    }
}
