using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;

namespace Zadacha16_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString1 = "";
            int code = 0;
            string name = "";
            decimal price = 0;
            String path = "C:/Products.json";
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            };
            Product[] products = new Product[5];
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"Введите код продукта №{i + 1}");
                code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите имя  продукта");
                name = Console.ReadLine();
                Console.WriteLine("Введите цену продукта");
                price = Convert.ToDecimal(Console.ReadLine());
                products[i] = new Product(code, name, price);
                jsonString1 += JsonSerializer.Serialize(products[i], options);
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(JsonSerializer.Serialize(products[i], options));
                }

            }
            Console.WriteLine(jsonString1);
            Console.ReadKey();
        }
    }
    public class Product
    {
        [JsonPropertyName("Код продукта")]
        public int ProductCode { get; set; }
        [JsonPropertyName("Имя продукта")]
        public string ProductName { get; set; }
        [JsonPropertyName("Цена продукта")]
        public decimal ProductPrice { get; set; }
        public Product()
        {
            ProductName = "Undefined";
        }
        public Product(int productCode, string productName, decimal productPrice)
        {
            ProductCode = productCode;
            ProductName = productName;
            ProductPrice = productPrice;
        }
    }
}
