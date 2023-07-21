using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_commerce.Models;
using E_commerce.Models.Customer;
using E_commerce.Models.Products;

namespace E_commerce
{
    public class CustomerRepo
    {
        public int AddCustomer(UsersModel usersModel)
        {
            using (var context = new CustomersEntities())
            {
                users c = new users()
                {
                    name = usersModel.Name,
                    email = usersModel.Email,
                    password = usersModel.Password,
                };

                context.users.Add(c);

                context.SaveChanges();

                return c.user_id;
            }
        }

        public UsersModel GetData(int id)
        {
            using (var context = new CustomersEntities())
            {
                var result = context.users.Where(x => x.user_id == id).Select(x => new UsersModel()
                {
                    User_id = x.user_id,
                    Name = x.name,
                    Email = x.email,
                    Password = x.password,
                }
                ).FirstOrDefault();

                return result;
            }
        }

        public bool UpdateData(int id, UsersModel usersModel)
        {
            using (var context = new CustomersEntities())
            {
                var customer = context.users.FirstOrDefault(x => x.user_id == id);

                if (customer != null)
                {
                    customer.name = usersModel.Name;
                    customer.email = usersModel.Email;
                    customer.password = usersModel.Password;
                }

                context.SaveChanges();

                return true;
            }
        }

        public bool DeleteData(int id)
        {
            using (var context = new CustomersEntities())
            {
                var customer = context.users.FirstOrDefault(x => x.user_id == id);
                if (customer != null)
                {
                    context.users.Remove(customer);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public List<ProductsModel> ShowProducts()
        {
            using (var context = new CustomersEntities())
            {
                var result = context.products.Select(x => new ProductsModel()
                {
                    Product_id = x.product_id,
                    Product_name = x.product_name,
                    Product_price = x.product_price,
                    Product_catagory = x.product_catagory,
                    Product_Catagory = new Product_catagoryModel
                    {
                        Catagory_id = x.product_catagory1.catagory_id,
                        Catagory_name = x.product_catagory1.catagory_name,
                    }
                }
                ).ToList();

                return result;
            }
        }

        public List<CartModel> Cart(int id)
        {
            using (var context = new CustomersEntities())
            {
                var result = context.cart.Where(x => x.user_id == id).Select(x => new CartModel()
                {
                    Cart_id = x.cart_id,
                    Products = new ProductsModel
                    {
                        Product_id = x.products.product_id,
                        Product_name = x.products.product_name,
                        Product_price = x.products.product_price,
                    }
                }
                ).ToList();

                return result;
            }
        }

        public int AddCart(CartModel cartModel)
        {
            using (var context = new CustomersEntities())
            {
                cart c = new cart()
                {
                    user_id = cartModel.User_id,
                    product_id = cartModel.Product_id,
                };

                context.cart.Add(c);

                context.SaveChanges();

                return c.cart_id;
            }
        }

        public bool DeleteCart(int id)
        {
            using (var context = new CustomersEntities())
            {
                var cart = context.cart.FirstOrDefault(x => x.cart_id == id);
                if (cart != null)
                {
                    context.cart.Remove(cart);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public List<WishlistModel> Wishlist(int id)
        {
            using (var context = new CustomersEntities())
            {
                var result = context.wishlist.Where(x => x.user_id == id).Select(x => new WishlistModel()
                {
                    Products = new ProductsModel
                    {
                        Product_id = x.products.product_id,
                        Product_name = x.products.product_name,
                        Product_price = x.products.product_price,
                    }
                }
                ).ToList();

                return result;
            }
        }

        public int AddWishlist(WishlistModel wishlistModel)
        {
            using (var context = new CustomersEntities())
            {
                wishlist c = new wishlist()
                {
                    user_id = wishlistModel.User_id,
                    product_id = wishlistModel.Product_id,
                };

                context.wishlist.Add(c);

                context.SaveChanges();

                return c.wishlist_id;
            }
        }

    }
}