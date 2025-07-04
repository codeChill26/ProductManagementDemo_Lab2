﻿using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductDAO productDAO= new ProductDAO();
        public void DeleteProduct(Product p) => productDAO.DeleteProduct(p);
        

        public void SaveProduct(Product p) => productDAO.SaveProduct(p);    

        public void UpdateProduct(Product p) => productDAO.UpdateProduct(p);

        public List<Product> GetProducts() => productDAO.GetProducts();

        public Product GetProductById(int id) => productDAO.GetProductById(id);
    }
}
