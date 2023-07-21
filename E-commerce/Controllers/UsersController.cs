using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_commerce.Models.Customer;

namespace E_commerce.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UsersModel usersModel)
        {
            CustomerRepo cusRepo = new CustomerRepo();
            if (ModelState.IsValid)
            {
                var id = cusRepo.AddCustomer(usersModel);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Okay = "User Added";
                }
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            CustomerRepo cusRepo = new CustomerRepo();
            var data = cusRepo.GetData(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(UsersModel usersModel)
        {
            CustomerRepo cusRepo = new CustomerRepo();

            if (ModelState.IsValid)
            {
                cusRepo.UpdateData(usersModel.User_id, usersModel);
                ViewBag.Okay = "Updated";
            }

            return View(usersModel);
        }

        public ActionResult SelectUserToUpdate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SelectUserToUpdate(int userId)
        {
            return RedirectToAction("Edit", new { id = userId });
        }

        public ActionResult Delete(int id)
        {
            CustomerRepo cusRepo = new CustomerRepo();
            cusRepo.DeleteData(id);
            return View();
        }

        public ActionResult SelectUserToDelete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SelectUserToDelete(int userId)
        {
            ViewBag.Okay = "Deleted Successfully";
            return RedirectToAction("Delete", new { id = userId });
        }

        public ActionResult ShowProducts()
        {
            CustomerRepo cusRepo = new CustomerRepo();
            var data = cusRepo.ShowProducts();
            return View(data);
        }

        public ActionResult Cart(int id)
        {
            CustomerRepo cusRepo = new CustomerRepo();
            var data = cusRepo.Cart(id);
            return View(data);
        }

        public ActionResult SelectUserForCart()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SelectUserForCart(int userId)
        {
            return RedirectToAction("Cart", new { id = userId });
        }
        

        public ActionResult SelectUserForAddCart(int productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }

        [HttpPost]
        public ActionResult SelectUserForAddCart(int userId, int productId)
        {
            
            var cartModel = new CartModel
            {
                User_id = userId,
                Product_id = productId
            };
            CustomerRepo cusRepo = new CustomerRepo();
            if (ModelState.IsValid)
            {
                var cartCheck = cusRepo.AddCart(cartModel);
                if (cartCheck > 0)
                {
                    ViewBag.Okay = "Added to Cart";
                }
            }

            return View();
        }

        public ActionResult DeleteCart(int id)
        {
            CustomerRepo cusRepo = new CustomerRepo();
            cusRepo.DeleteCart(id);
            return View("Create");
        }

        public ActionResult Wishlist(int id)
        {
            CustomerRepo cusRepo = new CustomerRepo();
            var data = cusRepo.Wishlist(id);
            return View(data);
        }

        public ActionResult SelectUserForWishlist()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SelectUserForWishlist(int userId)
        {
            return RedirectToAction("Wishlist", new { id = userId });
        }


        public ActionResult SelectUserForAddWishlist(int productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }

        [HttpPost]
        public ActionResult SelectUserForAddWishlist(int userId, int productId)
        {

            var wishlistModel = new WishlistModel
            {
                User_id = userId,
                Product_id = productId
            };
            CustomerRepo cusRepo = new CustomerRepo();
            if (ModelState.IsValid)
            {
                var wishlistCheck = cusRepo.AddWishlist(wishlistModel);
                if (wishlistCheck > 0)
                {
                    ViewBag.Okay = "Added to Wishlist";
                }
            }

            return View();
        }
    }
}