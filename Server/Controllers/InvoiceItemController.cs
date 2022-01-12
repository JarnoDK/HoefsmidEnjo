using HoefsmidEnjo.Shared.InvoiceItem;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoefsmidEnjo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceItemController : ControllerBase
    {
        private readonly IInvoiceItemService Service;
        public InvoiceItemController(IInvoiceItemService service)
        {
            this.Service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<InvoiceItemDto.Index>> GetAllAsync()
        {
            return await Service.GetAsync();
        }
        /*
         * Get by id
         */
        [HttpGet("{id}")]
        public async Task<InvoiceItemDto.Index> GetAsync(int id)
        {
            return await Service.GetAsync(id);
        }

        /*
        * Create invoice
        */
        [HttpPost]
        public async Task<InvoiceItemDto.Index> CreateAsync(InvoiceItemDto.Create model)
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
