using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StuffWorks.Models
{
        public class Login
        {
            [Required(ErrorMessage = "Enter EmailID")]
            [Remote("IsEmailIDExists", "Account", HttpMethod ="POST", ErrorMessage = "Email ID does not exists! Please Register")]
            public string EmailID { get; set; }
            [Required(ErrorMessage = "Enter Password")]
            public string Password { get; set; }
            public Boolean rememberme { get; set; }
        
    }
        public class Register
        {
            [Required(ErrorMessage = "Enter Full Name")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "Enter EmailID")]
            [Remote("IsEmailIDExistsRegister", "Account", HttpMethod = "POST", ErrorMessage = "Email ID already exists! Please Login")]
            public string EmailID { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Enter Phone Number")]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Phone")]
            public string Phone { get; set; }
        }
    public class ManageUserDetails
    {
        [Required(ErrorMessage = "Enter Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Enter your Email ID")]
        [Remote("IsEmailIDExists", "Account", HttpMethod = "POST", ErrorMessage = "Password not Correct! Please Enter Correct Password.")]
        public string useremail { get; set; }

        [Required(ErrorMessage = "Enter PhoneNumber")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter Current Password")]
        [Remote("IsEmailIDExists", "Account", HttpMethod = "POST", ErrorMessage = "Password not Correct! Please Enter Correct Password.")]
        public string currentpassword { get; set; }

        [Required(ErrorMessage = "Enter New Password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm New Password")]
        public string ConfirmNewPassword { get; set; }

        [Required(ErrorMessage = "Enter Address1")]
        public string Address1 { get; set; }

        [Required(ErrorMessage = "Enter Address2")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Enter City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Enter Pincode")]
        public string Pincode { get; set; }
               
    }

    public class RegisterStuffer
    {
        [Required(ErrorMessage = "Enter Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Enter EmailID")]
        [Remote("IsEmailIDExistsRegister", "Account", HttpMethod = "POST", ErrorMessage = "Email ID already exists! Please Login")]
        public string EmailID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter Address1")]
        [DataType(DataType.Text)]
        [Display(Name = "Address1")]
        public string Address1 { get; set; }

        [Required(ErrorMessage = "Enter Address2")]
        [DataType(DataType.Text)]
        [Display(Name = "Address2")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Enter City")]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter State")]
        [DataType(DataType.Text)]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Enter ZipCode")]
        [DataType(DataType.PostalCode)]
        [Display(Name = "ZipCode")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Enter ZipCode")]
        [Display(Name = "Service")]
        public string Service { get; set; }

        public List<SelectListItem> Services { get; set; }
    }
}