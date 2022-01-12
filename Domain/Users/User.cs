using Domain.Common;
using HoefsmidEnjo.Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class User: Entity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Pincode { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public UserRole Role{ get; set; }


        public User(string firstname,string lastname,string password, string pincode, string email, string telephone, UserRole role)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Password = password;

            this.Pincode = pincode;
            this.Email = email;

            this.Role = role;
            this.Telephone = telephone;
        }

        public User()
        {

        }

    }
}
