
using HoefsmidEnjo.Shared.Invoice;
using HoefsmidEnjo.Shared.InvoiceItem;
using HoefsmidEnjo.Shared.InvoiceLine;
using HoefsmidEnjo.Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.InvoiceService
{
    public class FakeInvoiceService : IInvoiceService
    {

        private static readonly List<InvoiceDto.Index> Invoices = new();
        private static readonly List<UserDto.Detail> Users = new()
        {
            new UserDto.Detail
            {
                Id = 0,
                Email = "Test@Test.be",
                FirstName = "Marie",
                LastName = "Dubois",
                Role = UserRole.Klant
            },
            new UserDto.Detail
            {
                Id = 1,
                Email = "StevenStone@Test.be",
                FirstName = "Steven",
                LastName = "Stone",
                Role = UserRole.Klant
            },
            new UserDto.Detail
            {
                Id = 2,
                Email = "CynthiaChamp@Test.be",
                FirstName = "Cynthia",
                LastName = "Champ",
                Role = UserRole.Klant
            }
        };


        static FakeInvoiceService()
        {

            List<InvoiceItemDto.Index> Items = new()
            {
                new InvoiceItemDto.Index { Id = 0, Name = "Item1", UnitPrice = 10.00},
                new InvoiceItemDto.Index { Id = 1, Name = "Item2", UnitPrice = 20.00 },
                new InvoiceItemDto.Index { Id = 2, Name = "Item3", UnitPrice = 30.00 },
                new InvoiceItemDto.Index { Id = 3, Name = "Item4", UnitPrice = 40.00 },

            };

            Invoices = new()
            {
                new InvoiceDto.Index {

                    Id = 1,
                    Time = DateTime.Now,
                    Client = Users[0],
                    InvoiceLines = new()
                    {
                        new InvoiceLineDto.Index()
                        {
                            Id = 0,
                            Amount = 2,
                            Item = Items[0]
                        },
                        new InvoiceLineDto.Index()
                        {
                            Id = 0,
                            Amount = 1,
                            Item = Items[1]
                        },
                        new InvoiceLineDto.Index()
                        {
                            Id = 0,
                            Amount = 5,
                            Item = Items[2]
                        }
                    }
                }
            };
        }
        public async Task<InvoiceDto.Index> CreateAsync(InvoiceDto.Create model)
        {
            await Task.Delay(100);
            InvoiceDto.Index inv = new()
            { 
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
