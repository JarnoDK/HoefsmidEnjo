using HoefsmidEnjo.Shared.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoefsmidEnjo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService Service;
        public UserController(IUserService service)
        {
            Service = service;
        }


        /*
         * Get all users 
         */
        [HttpGet]
        public async Task<IEnumerable<UserDto.Index>> GetAllAsync()
        {
            return await Service.GetAsync();
        }

        /*
         * Get user by id
         */
        [HttpGet("{id}")]
        public async Task<UserDto.Detail> GetDetailAsync(int id)
        {
            return await Service.GetAsync(id);
        }


        /*
         * Get users with name containing firstname and lastname
         */
        [HttpGet("{firstname}/{lastname}")]
        public async Task<IEnumerable<UserDto.Index>> GetByNameAsync(string firstname,string lastname)
        {
            return await Service.GetAsync(firstname, lastname);
        }

        /*
        * Add user 
        */
        [HttpPost]
        public async Task<UserDto.Detail> AddAsync(UserDto.Create model)
        {
            return await Service.CreateAsync(model);
        }

        /*
        * Delete user 
        */
        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            await Service.DeleteAsync(id);
            return true;
        }


    }
}
