using HoefsmidEnjo.Shared.InvoiceItem;
using HoefsmidEnjo.Shared.InvoiceLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InvoiceService
{
    public class FakeInvoiceLineService: IInvoiceLineService
    {

        private readonly List<InvoiceLineDto.Index> InvoiceLines;
        private readonly IInvoiceItemService ItemService;

        public FakeInvoiceLineService(IInvoiceItemService service)
        {
            ItemService = service;

            InvoiceLines = new List<InvoiceLineDto.Index>
            {
                new InvoiceLineDto.Index{ Id = 0, Item = ItemService.GetAsync(0).Result ,Amount = 5 },
                new InvoiceLineDto.Index{ Id = 1, Item = ItemService.GetAsync(1).Result ,Amount = 3 },
                new InvoiceLineDto.Index{ Id = 2, Item = ItemService.GetAsync(2).Result ,Amount = 2 }

            };
        }

        public async Task<InvoiceLineDto.Index> CreateAsync(InvoiceLineDto.Create model)
        {
            int id = InvoiceLines.Max(s => s.Id) + 1;
            InvoiceLineDto.Index index=  new() { Id = id, Amount = model.Amount, Item = model.Item };
            InvoiceLines.Add(index);
            return index;
        }

        public async Task<InvoiceLineDto.Index> DeleteAsync(int id)
        {
            InvoiceLineDto.Index index =  InvoiceLines.FirstOrDefault(s => s.Id == id);
            InvoiceLines.Remove(index);
            return index ?? null;
        }

        public async Task<List<InvoiceLineDto.Index>> GetAsync()
        {
            return InvoiceLines;
        }

        public async Task<InvoiceLineDto.Index> GetAsync(int id)
        {
            return InvoiceLines.FirstOrDefault(s => s.Id == id);

        }
    }
}
