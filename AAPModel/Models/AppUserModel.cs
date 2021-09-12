using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAPModel.Models
{
   public class AppUserModel
   {
        public long UserId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
        public string LoginId { get; set; }
        public string LoginPassword { get; set; }

        [DisplayName("Address")]
        public string AddressLine { get; set; }

        [DisplayName("Phone")]
        public string Phone { get; set; }
        public bool? IsActive { get; set; }
        public int RoleId { get; set; }
    }
}
