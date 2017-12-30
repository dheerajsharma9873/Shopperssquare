using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Shoppers_Square.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "E-Mail is required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Please confirm your password!")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Address is Required!")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Mobile Number is required")]
        public string MobileNo { get; set; }

    }
}