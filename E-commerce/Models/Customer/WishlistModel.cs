using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_commerce.Models.Products;

namespace E_commerce.Models.Customer
{
    public class WishlistModel
    {
        public int Wishlist_id { get; set; }
        public Nullable<int> User_id { get; set; }
        public Nullable<int> Product_id { get; set; }

        public ProductsModel Products { get; set; }

        public UsersModel Users { get; set; }
    }
}