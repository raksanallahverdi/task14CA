using System;
namespace Task2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Sell");
                Console.WriteLine("3. See Income");
                Console.WriteLine("4. See remain products");
                Console.WriteLine("Choose number:");

                
                string input = Console.ReadLine();

                int answer;

                bool isTrue = int.TryParse(input, out answer);

                if (isTrue)
                {
                    switch (answer)
                    {
                        case 1:
                            AddProduct(shop);
                            break;
                        case 2:
                            SellProduct(shop);
                            break;
                        case 3:
                            Console.WriteLine($"Total Income: {shop.TotalIncome}");
                            break;
                        case 4:
                            ViewProducts(shop);
                            break;
                        default:
                            Console.WriteLine("Choose again");
                            break;
                    }
                }
                
            }
        }

        static void AddProduct(Shop shop)
        {
            Console.WriteLine("Product Name daxil edin:");
            string name = Console.ReadLine();

            Console.WriteLine("Product Price daxil edin:");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Product Count daxil edin:");
            int count = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Product Type daxil edin (c for Coffee, t for Tea):");
            string type = Console.ReadLine();

            if (type == "c")
            {
                shop.AddProduct(new Coffee { Name = name, Price = price, Count = count });
            }
            else if (type == "t")
            {
                shop.AddProduct(new Tea { Name = name, Price = price, Count = count });
            }
            else
            {
                Console.WriteLine("Product type sehvdir, yeniden cehd edin.");
            }
        }

        static void SellProduct(Shop shop)
        {
            Console.WriteLine("Satilacaq productun adini daxil edin:");
            string name = Console.ReadLine();

            Console.WriteLine("Satilacaq productun sayini daxil edin:");
            int count = Convert.ToInt32(Console.ReadLine());

            bool result = shop.SellProduct(name, count);

            if (!result)
            {
                Console.WriteLine("Mehsul yetesizdir yaxud tapilmadi.");
            }
        }

        static void ViewProducts(Shop shop)
        {
            foreach (var product in shop.Products)
            {
                Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Count: {product.Count}");
            }
        }
    }
}