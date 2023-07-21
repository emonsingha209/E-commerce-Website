using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_commerce.Models;
using E_commerce.Models.Customer;

namespace E_commerce.Models.Products
{
    public class ProductsModel
    {
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public Nullable<double> Product_price { get; set; }
        public Nullable<int> Product_catagory { get; set; }

        public Product_catagoryModel Product_Catagory { get; set; }
        public CartModel Cart { get; set; }
        public OrderedModel Ordered { get; set; }
        public WishlistModel Wishlist { get; set; }
    }
}