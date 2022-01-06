using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoefsmidEnjo.Shared.InvoiceItem
{
    public interface IInvoiceItemService
    {
        /*
         * Get all invoice items
         */
        Task<IEnumerable<InvoiceItemDto.Index>> GetAsync();
        /*
         * Get Invoice item by id
         */
        Task<InvoiceItemDto.Index> GetAsync(int Id);
        /*
         * Create InvoiceItem using model
         */
        Task<InvoiceItemDto.Index> CreateAsync(InvoiceItemDto.Create model);
        /*
         * Remove InvoiceItem with given id
         */
        Task DeleteAsync(int id);
    }
}
