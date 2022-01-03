namespace HoefsmidEnjo.Shared.Invoice
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceDto.Index>> GetAsync();
        Task<InvoiceDto.Index> GetAsync(int id);
        Task<InvoiceDto.Index> CreateAsync(InvoiceDto.Create model);
        Task DeleteAsync(int id);
    }
}
