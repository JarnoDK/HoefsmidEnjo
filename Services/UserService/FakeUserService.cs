

using HoefsmidEnjo.Shared.Users;

namespace Services.UserService
{
    public class FakeUserService : IUserService
    {

        private readonly static List<UserDto.Detail> Users = new();

        static FakeUserService()
        {

        }

        public Task<UserDto.Index> CreateAsync(UserDto.Create model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto.Index>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto.Detail> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto.Detail> GetAsync(string firstname, string lastname)
        {
            throw new NotImplementedException();
        }
    }
}
