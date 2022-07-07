using Domain.Invoice;
using HoefsmidEnjo.Shared;
using HoefsmidEnjo.Shared.Invoice;
using HoefsmidEnjo.Shared.InvoiceItem;
using HoefsmidEnjo.Shared.InvoiceLine;
using HoefsmidEnjo.Shared.Users;
using Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InvoiceService
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationDbContext _context;

        private readonly IUserService UserService;
        private readonly IInvoiceItemService ItemService;

        public InvoiceService(ApplicationDbContext context, IUserService service,IInvoiceItemService itemservice)
        {
            this._context = context;
            this.UserService = service;
            this.ItemService = itemservice;
        }
        public async Task<InvoiceDto.Index> CreateAsync(InvoiceDto.Create model)
        {
            List<InvoiceLine> lines = new(
                model.InvoiceLines.Select(s => new InvoiceLine(s.Amount,s.Item.Id)
                ));
            Invoice invoice = new (Converters.ConvertDateTime(model.Time),lines,model.Client.Id);
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
            InvoiceDto.Index index= new(){
                Id = invoice.Id,
                Time = invoice.Date,
                Client = model.Client,
                InvoiceLines = lines.Select(s => new InvoiceLineDto.Index { 
                    Id = s.Id,
                    Item = ItemService.GetAsync(s.Item).Result,
                    Amount = s.Amount
                }).ToList()
            };
            ICreateInvoice ci = new Excel();
            ci.Initialize(index)
                .AddBuyer()
                .AddItems()
                .Save();
            return index;
        }


        public async Task DeleteAsync(int id)
        {
            Invoice inv = _context.Invoices.FirstOrDefault(s => s.Id == id);
            if(inv != null)
            {
                _context.Invoices.Remove(inv);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<InvoiceDto.Index>> GetAsync()
        {
            return _context.Invoices
                .Select(s => new InvoiceDto.Index { 
                    Id = s.Id,
                    Time = s.Date,
                    Client = UserService.GetAsync(s.User).Result,
                    InvoiceLines = s.InvoiceLines.Select(sl => new InvoiceLineDto.Index { 
                        Id = sl.Id,
                        Amount = sl.Amount,
                        Item = ItemService.GetAsync(sl.Item).Result
                    }).ToList()
                })
                .ToList();
        }

        public async Task<InvoiceDto.Index> GetAsync(int id)
        {
            InvoiceDto.Index? index = _context.Invoices.Where(s => s.Id == id).Select(s => new InvoiceDto.Index
            {
                Id = s.Id,
                Time = s.Date,
                Client = UserService.GetAsync(s.User).Result,
                InvoiceLines = s.InvoiceLines.Select(sl => new InvoiceLineDto.Index
                {
                    Id = sl.Id,
                    Amount = sl.Amount,
                    Item = ItemService.GetAsync(sl.Item).Result
                }).ToList()
            }).SingleOrDefault();
            return index;
        }
    }
}
