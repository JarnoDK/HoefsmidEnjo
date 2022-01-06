

using HoefsmidEnjo.Shared.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.UserService
{
    public class FakeUserService : IUserService
    {

        private readonly static List<UserDto.Detail> Users = new();

        static FakeUserService()
        {
            Users = new()
            {
                new UserDto.Detail
                {
                    Id = 0,
                    Email = "Test@Test.be",
                    FirstName ="Marie",
                    LastName = "Dubois",
                    Role = UserRole.Klant,
                    Phone = "04 92 88 72 59"
                },
                new UserDto.Detail
                {
                    Id = 1,
                    Email = "StevenStone@Test.be",
                    FirstName = "Steven",
                    LastName = "Stone",
                    Role = UserRole.Klant,
                    Phone = "04 12 44 77 32"
                },
                new UserDto.Detail
                {
                    Id = 2,
                    Email = "CynthiaChamp@Test.be",
                    FirstName = "Cynthia",
                    LastName = "Champ",
                    Role = UserRole.Klant,
                    Phone = "04 55 67 88 33"
                }
            };
        }

        public async Task<UserDto.Detail> CreateAsync(UserDto.Create model)
        {
            await Task.Delay(100);
            UserDto.Detail user = new()
            {
                Id = Users.Count + 1,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PassWord = model.Password,
                Pincode = model.Pincode,
                Role = model.Role
            };

            Users.Add(user);
            return user;
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Delay(100);
            UserDto.Detail user = Users.SingleOrDefault(s => s.Id == id);
            if(user != null)
            {
                Users.Remove(user);
            }
        }

        public async Task<IEnumerable<UserDto.Index>> GetAsync()
        {
            await Task.Delay(100);
            return Users.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
        }

        public async Task<UserDto.Detail> GetAsync(int id)
        {
            await Task.Delay(100);
            return Users.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<UserDto.Detail>> GetAsync(string firstname = "", string lastname= "")
        {
            await Task.Delay(100);
            return Users
                .Where(x => x.FirstName.ToLower().Contains(firstname.ToLower()))
                .Where(x => x.LastName.ToLower().Contains(lastname.ToLower()));
        }
    }
}
