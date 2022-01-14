using Domain.Invoice;
using HoefsmidEnjo.Shared.InvoiceItem;
using Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InvoiceItemService
{

    public class InvoiceItemService:IInvoiceItemService
    {
        private readonly ApplicationDbContext _context;

        public InvoiceItemService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<InvoiceItemDto.Index> CreateAsync(InvoiceItemDto.Create model)
        {
            InvoiceItem ii = new(model.Name,model.UnitPrice);
            _context.Items.Add(ii);
            await _context.SaveChangesAsync();
            return new InvoiceItemDto.Index { 
                Id = ii.Id,
                Name= ii.Name,
                UnitPrice = ii.UnitPrice
            };
        }

        public async Task DeleteAsync(int id)
        {
            InvoiceItem ii = _context.Items.SingleOrDefault(s => s.Id == id);
            if(!ii.Equals(null))
            {
                _context.Items.Remove(ii);
            }
        }

        public async Task<IEnumerable<InvoiceItemDto.Index>> GetAsync()
        {
            return _context.Items
                .Select(s => new InvoiceItemDto.Index {
                    Id = s.Id,
                    Name = s.Name,
                    UnitPrice = s.UnitPrice
                })
                .AsEnumerable();
        }

        public async Task<InvoiceItemDto.Index> GetAsync(int Id)
        {
            return _context.Items.Where(s => s.Id == Id)
                .Select(s => new InvoiceItemDto.Index
                {
                    Id = s.Id,
                    Name = s.Name,
                    UnitPrice = s.UnitPrice
                }).SingleOrDefault();
        }
    }
}
