
using HoefsmidEnjo.Shared.Invoice;

namespace Services.InvoiceService
{
    public class FakeInvoiceService : IInvoiceService
    {

        private static readonly List<InvoiceDto.Index> Invoices = new();

        static FakeInvoiceService()
        {

        }
        public async Task<InvoiceDto.Index> CreateAsync(InvoiceDto.Create model)
        {
            await Task.Delay(100);
            InvoiceDto.Index inv = new InvoiceDto.Index { 
                Id = Invoices.Count +1,
                Client = model.Client,
                InvoiceLines = model.InvoiceLines,
                Time = DateTime.Now
            };
            Invoices.Add(inv);
            return inv;

        }

        public async Task DeleteAsync(int id)
        {
            await Task.Delay(100);
            InvoiceDto.Index inv = Invoices.FirstOrDefault(s => s.Id == id);
            if(inv != null)
            {
                Invoices.Remove(inv);
            }
        }

        public async Task<IEnumerable<InvoiceDto.Index>> GetAsync()
        {
            await Task.Delay(100);
            return Invoices.OrderBy(x => x.Time);
        }

        public async Task<InvoiceDto.Index> GetAsync(int id)
        {
            await Task.Delay(100);
            return Invoices.FirstOrDefault(s => s.Id == id);
        }
    }
}
