using System;
namespace Task2
{
	public class Shop
	{
        public List<Product> Products { get; private set; }
        public double TotalIncome { get; private set; }

        public Shop()
        {
            Products = new List<Product>();
            TotalIncome = 0;
        }

        public void AddProduct(Product product)
        {
            var existingProduct = Products.FirstOrDefault(p => p.Name == product.Name);
            if (existingProduct != null)
            {
                existingProduct.Count += product.Count;
            }
            else
            {
                Products.Add(product);
            }
        }

        public bool SellProduct(string name, int count)
        {
            var product = Products.FirstOrDefault(p => p.Name == name);
            if (product != null && product.Count >= count)
            {
                product.Count -= count;
                TotalIncome += product.Price * count;
                return true;
            }
            return false;
        }
    }
}

