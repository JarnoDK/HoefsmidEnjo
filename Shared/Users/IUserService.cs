using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoefsmidEnjo.Shared.Users
{
    public interface IUserService
    {
        
        /*
         * Get all users
         */
        public Task<IEnumerable<UserDto.Index>> GetAsync();
        /*
         * Get User with given id
         */
        public Task<UserDto.Detail> GetAsync(int id);
        /*
         * Get User with given firstname and lastname
         */
        public Task<UserDto.Detail> GetAsync(string firstname, string lastname);
        /*
         * Create a new User using given model
         */
        public Task<UserDto.Index> CreateAsync(UserDto.Create model);
        /*
         * Delete user with given ID
         */
        public Task DeleteAsync(int id);

    }
}
