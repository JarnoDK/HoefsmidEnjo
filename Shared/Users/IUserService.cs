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
        Task<IEnumerable<UserDto.Index>> GetAsync();
        /*
         * Get User with given id
         */
        Task<UserDto.Detail> GetAsync(int id);
        /*
         * Get Users with name containing the given firstname and lastname
         */
        Task<IEnumerable<UserDto.Detail>> GetAsync(string firstname, string lastname);
        /*
         * Create a new User using given model
         */
        Task<UserDto.Detail> CreateAsync(UserDto.Create model);
        /*
         * Delete user with given ID
         */
        Task DeleteAsync(int id);

    }
}
