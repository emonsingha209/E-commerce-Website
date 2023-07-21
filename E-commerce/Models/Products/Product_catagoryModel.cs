using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_commerce.Models;

namespace E_commerce.Models.Products
{
    public class Product_catagoryModel
    {
        public int Catagory_id { get; set; }
        public string Catagory_name { get; set; }

        public ProductsModel Products { get; set; }
    }
}