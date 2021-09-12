using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AAPM.Models
{
    public class UserModel
    {
        public long UserId { get; set; }

        [Required(ErrorMessage = "Please Enter FirstName")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Name")]
        public string FullName {
            get
            {
                return FirstName + (String.IsNullOrEmpty(MiddleName) ? " " :" "+ MiddleName) + (String.IsNullOrEmpty(LastName) ? " " :" "+ LastName);
            }
        }

        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        public string LoginId { get; set; }
        public string LoginPassword { get; set; }

        [DisplayName("Address")]
        public string AddressLine { get; set; }

        [Required(ErrorMessage = "Please enter PhoneNumber")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public bool? IsActive { get; set; }

        [DisplayName("Status")]
        public string Status
        {
            get
            {
                return IsActive == true ? "Active" : "Inactive";
            }
        }

        [UIHint("Role")]
        public int RoleId { get; set; }

    }

}