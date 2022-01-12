using System.Collections.Generic;
using System.Threading.Tasks;

namespace HoefsmidEnjo.Shared.InvoiceLine{

    public interface IInvoiceLineService{
        Task<List<InvoiceLineDto.Index>> GetAsync();
        Task<InvoiceLineDto.Index> GetAsync(int id);
        Task<InvoiceLineDto.Index> CreateAsync(InvoiceLineDto.Create model);
        Task<InvoiceLineDto.Index> DeleteAsync(int id);


    }
}