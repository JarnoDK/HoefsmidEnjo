

using HoefsmidEnjo.Shared.Users;

namespace Services.UserService
{
    public class FakeUserService : IUserService
    {

        private readonly static List<UserDto.Detail> Users = new();

        static FakeUserService()
        {

        }

        public async Task<UserDto.Detail> CreateAsync(UserDto.Create model)
        {
            await Task.Delay(100);
            UserDto.Detail user = new UserDto.Detail
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
