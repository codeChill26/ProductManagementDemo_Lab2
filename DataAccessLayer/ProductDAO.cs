using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer

{
    public class ProductDAO
    {
        private static List<Product> listProducts;
        public ProductDAO()
        {
            Product chai = new Product(1, "Chai", 1, 12, 18);
            Product chang = new Product(2, "Chang", 3, 23, 19);
            Product aniseed = new Product(3, "Aniseed Syrup", 2, 23, 10);
            listProducts = new List<Product> { chai, chang, aniseed };
            //Product chef = new Product(4, "Chef Anton's Cajun Seasoning", 2, 53, 22);
            //Product chefMix = new Product(5, "Chef Mix", 2, 120, 25);
            //Product grandma = new Product(6, "Grandma's Boysenberry Spread", 2, 25, 25);
            //Product uncleBob = new Product(7, "Uncle Bob's Organic Dried Pears", 7, 15, 30);
            //Product northwoods = new Product(8, "Northwoods Cranberry Sauce", 2, 6, 40);
            //Product mishi = new Product(9, "Mishi Kobe Niku", 6, 29, 97);
            //Product ikura = new Product(10, "Ikura", 8, 31, 31);
            //listProducts = new List<Product> { chai, chang, aniseed, chef, chefMix, grandma, };

        }
        public List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using var db = new MyStoreContext();
                listProducts = db.Products.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving products: {ex.Message}");
            }
            return listProducts;

        }
       
        public void SaveProduct(Product p)
        {
            listProducts.Add(p);
        }
        public void UpdateProduct(Product product)
        {
            foreach(Product p in listProducts.ToList())
            {
                if (p.ProductID == product.ProductID)
                {
                    p.ProductID = product.ProductID;
                    p.ProductName = product.ProductName;    
                    p.UnitPrice = product.UnitPrice;
                    p.UnitsInStock = product.UnitsInStock;
                    p.CategoryID = product.CategoryID;

                }

            }
        }
        public void DeleteProduct(Product product)
        {
            foreach (Product p in listProducts.ToList())
            {
                if (p. == product.ProductID)
                {
                    listProducts.Remove(p);  
                }
            }
        }
        public Product GetProductById(int id)
        {
            foreach(Product p in listProducts.ToList())
            {
                if(p.ProductID == id)
                {
                    return p;
                }
            }
            return null;

        }
    }
}
