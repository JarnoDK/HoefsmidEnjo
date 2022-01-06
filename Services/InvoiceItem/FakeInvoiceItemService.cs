using HoefsmidEnjo.Shared.InvoiceItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InvoiceItem
{
    public class FakeInvoiceItemService : IInvoiceItemService
    {
        private static readonly List<InvoiceItemDto.Index> Items = new();
        public FakeInvoiceItemService()
        {

        }

        public async Task<InvoiceItemDto.Index> CreateAsync(InvoiceItemDto.Create model)
        {
            await Task.Delay(100);
            InvoiceItemDto.Index item = new InvoiceItemDto.Index
            {
                Id = Items.Count,
                Name = model.Name,
                UnitPrice = model.UnitPrice
            };
            Items.Add(item);
            return item;
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Delay(100);
            InvoiceItemDto.Index item = Items.FirstOrDefault(x => x.Id == id);

            if(item != null)
            {
                Items.Remove(item);
            }
        }

        public async Task<IEnumerable<InvoiceItemDto.Index>> GetAsync()
        {
            return Items.OrderBy(x => x.Name);
        }

        public async Task<InvoiceItemDto.Index> GetAsync(int Id)
        {
            return Items.FirstOrDefault(x => x.Id == Id);
        }
    }
}
