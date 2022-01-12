using HoefsmidEnjo.Shared.Event;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoefsmidEnjo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService Service;
        public EventController(IEventService service)
        {
            this.Service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<EventDto.Index>> GetAllAsync()
        {
            return await Service.GetAsync();
        }
        /*
         * Get by id
         */
        [HttpGet("{id}")]
        public async Task<EventDto.Index> GetAsync(int id)
        {
            return await Service.GetAsync(id);
        }

        /*
        * Create event
        */
        [HttpPost]
        public async Task<EventDto.Index> CreateAsync(EventDto.Create model)
        {

            return await Service.CreateAsync(model);

        }

        /*
        * remove invoice
        */
        [HttpDelete]
        public async Task DeleteAsync(int id)
        {
            await Service.DeleteAsync(id);
        }

    }
}
