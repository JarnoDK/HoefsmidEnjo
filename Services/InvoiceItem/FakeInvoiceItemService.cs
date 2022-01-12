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
        static FakeInvoiceItemService()
        {
            Items = new List<InvoiceItemDto.Index>{
                new InvoiceItemDto.Index
                {
                    Id = 0, Name = "Item1" , UnitPrice = 5.25
                },
                new InvoiceItemDto.Index
                {
                    Id = 1, Name = "Item2" , UnitPrice = 2.35
                },
                new InvoiceItemDto.Index
                {
                    Id = 2, Name = "Item3" , UnitPrice = 7.45
                },
            };
        }

        public async Task<InvoiceItemDto.Index> CreateAsync(InvoiceItemDto.Create model)
        {
            await Task.Delay(100);
            InvoiceItemDto.Index item = new()
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
