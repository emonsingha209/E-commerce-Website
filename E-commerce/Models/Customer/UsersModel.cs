using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_commerce.Models;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models.Customer
{
    public class UsersModel
    {
        public int User_id { get; set; }

        [Required(ErrorMessage = "Please enter your Name")]
        [MinLength(3, ErrorMessage = "Must contain at least 3 characters")]
        [MaxLength(40, ErrorMessage = "More than 40 character is not allow")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 40 characters.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z]).+$", ErrorMessage = "Password must contain at least one lowercase letter and one uppercase letter.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        public CartModel Cart { get; set; }
        public OrderedModel Ordered { get; set; }
        public WishlistModel Wishlist { get; set; }
    }
}