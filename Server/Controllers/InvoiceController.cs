using HoefsmidEnjo.Shared.Invoice;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoefsmidEnjo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService Service;
        public InvoiceController(IInvoiceService service)
        {
            this.Service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<InvoiceDto.Index>> GetAllAsync()
        {
            return await Service.GetAsync();
        }
        /*
         * Get by id
         */
        [HttpGet("{id}")]
        public async Task<InvoiceDto.Index> GetAsync(int id)
        {
            return await Service.GetAsync(id);
        }

        /*
        * Create invoice
        */
        [HttpPost]
        public async Task<InvoiceDto.Index> CreateAsync(InvoiceDto.Create model)
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
