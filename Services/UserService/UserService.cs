using Domain.Users;
using HoefsmidEnjo.Shared.Users;
using Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserService
{
    public class UserService: IUserService
    {


        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<UserDto.Detail> CreateAsync(UserDto.Create model)
        {

            User us = new(model.FirstName, model.LastName, model.Password, model.Pincode, model.Email, model.Phone, model.Role);
            _context.Users.Add(us);
            _context.SaveChanges();


            return new UserDto.Detail
            {
                Id = us.Id,
                Phone = us.Telephone,
                Email = us.Email,
                FirstName = us.Firstname,
                LastName = us.Lastname,
                Password = us.Password,
                Pincode = us.Pincode,
                Role = us.Role
            };

        }

        public async Task DeleteAsync(int id)
        {
            _context.Users.Remove(_context.Users.FirstOrDefault(s => s.Id == id));
            _context.SaveChanges();
        }

        public async Task<IEnumerable<UserDto.Index>> GetAsync()
        {
            return _context.Users
                .Select(us => new UserDto.Detail{
                    Id = us.Id,
                    Phone = us.Telephone,
                    Email = us.Email,
                    FirstName = us.Firstname,
                    LastName = us.Lastname,
                    Password = us.Password,
                    Pincode = us.Pincode,
                    Role = us.Role
                })
                .AsEnumerable();
        }

        public async Task<UserDto.Detail> GetAsync(int id)
        {
            return _context.Users.Where(s => s.Id == id).Select(us => new UserDto.Detail
            {
                Id = us.Id,
                Phone = us.Telephone,
                Email = us.Email,
                FirstName = us.Firstname,
                LastName = us.Lastname,
                Password = us.Password,
                Pincode = us.Pincode,
                Role = us.Role
            }).SingleOrDefault();
        }

        public async Task<IEnumerable<UserDto.Detail>> GetAsync(string firstname, string lastname)
        {
            return _context.Users
                .Where(s => s.Firstname.ToLower().Contains(firstname.ToLower()))
                .Where(s => s.Lastname.ToLower().Contains(lastname.ToLower()))
                .Select(us => new UserDto.Detail
                {
                    Id = us.Id,
                    Phone = us.Telephone,
                    Email = us.Email,
                    FirstName = us.Firstname,
                    LastName = us.Lastname,
                    Password = us.Password,
                    Pincode = us.Pincode,
                    Role = us.Role
                })
                .AsEnumerable();
        }

  
    }
}
