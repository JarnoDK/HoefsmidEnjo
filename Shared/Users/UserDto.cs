using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoefsmidEnjo.Shared.Users
{
    public abstract class UserDto
    {
        public class Index
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

        }
        public class Detail:Index
        {
            // access app
            public string Pincode { get; set; }
            // Log in on website once it's there + notify clients
            public string Email { get; set; }
            public string Phone { get; set; }
            public string PassWord { get; set; }
            public UserRole Role { get; set; }


        }

        public class Create
        {

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Pincode { get; set; }
            // Log in on website once it's there + notify clients
            public string Email { get; set; }
            public string Phone { get; set; }
            public UserRole Role { get; set; } = UserRole.Klant;
            public string Password { get; set; }

            public class Validator: AbstractValidator<Detail>
            {
                public Validator()
                {
                    RuleFor(x => x.FirstName).NotNull().NotEmpty().WithName("Voornaam");
                    RuleFor(x => x.LastName).NotNull().NotEmpty().WithName("Achternaam");
                    RuleFor(x => x.Email).EmailAddress().NotNull().NotEmpty().WithName("Email");
                    RuleFor(x => x.Phone).NotNull().NotEmpty().WithName("Telefoon");


                    When(x => x.Role != UserRole.Klant, () =>
                    {
                        RuleFor(x => x.Pincode).MinimumLength(4).WithName("Pincode");
                        RuleFor(x => x.PassWord).MinimumLength(6).WithName("Wachtwoord");
                    });
                }
            }

        }
    }
}
