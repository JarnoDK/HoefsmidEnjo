
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

        private readonly List<InvoiceDto.Index> Invoices = new();

        private readonly IInvoiceLineService LineService;


        private static readonly List<UserDto.Detail> Users = new()
        {
            new UserDto.Detail
            {
                Id = 0,
                Email = "Test@Test.be",
                FirstName = "Marie",
                LastName = "Dubois",
                Role = UserRole.Klant,
                Phone = "0492887259"
            },
            new UserDto.Detail
            {
                Id = 1,
                Email = "StevenStone@Test.be",
                FirstName = "Steven",
                LastName = "Stone",
                Phone = "0492887259",
                Role = UserRole.Klant
            },
            new UserDto.Detail
            {
                Id = 2,
                Email = "CynthiaChamp@Test.be",
                FirstName = "Cynthia",
                LastName = "Champ",
                Role = UserRole.Klant,
                Phone = "0492887259"
            }
        };


        public FakeInvoiceService(IInvoiceLineService invoicelineservice)
        {

            this.LineService = invoicelineservice;


            Invoices = new()
            {
                new InvoiceDto.Index {

                    Id = 1,
                    Time = DateTime.Now,
                    Client = Users[0],
                    InvoiceLines = new()
                    {
                        invoicelineservice.GetAsync(0).Result,
                        invoicelineservice.GetAsync(1).Result
                    }
                }
            };
        }
        public async Task<InvoiceDto.Index> CreateAsync(InvoiceDto.Create model)
        {
            await Task.Delay(100);

            String[] datetime = model.Time.Split(" ");
            string[] date = datetime[0].Split("/");
            int day = int.Parse(date[0]);
            int month = int.Parse(date[1]);
            int year = int.Parse(date[2]);

            string[] time = datetime[1].Split(":");

            int hour = int.Parse(time[0]);
            int minute = int.Parse(time[1]);

            DateTime dt = new(year,month,day,hour,minute,0); 
            InvoiceDto.Index inv = new()
            { 
                Id = Invoices.Count +1,
                Client = model.Client,
                InvoiceLines = await ConvertInvoiceLineCreate(model.InvoiceLines),
                Time = dt
            };
            Invoices.Add(inv);
            return inv;

        }


        private async Task<List<InvoiceLineDto.Index>> ConvertInvoiceLineCreate(List<InvoiceLineDto.Create> model)
        {
            List<InvoiceLineDto.Index> lines= new();

            foreach(InvoiceLineDto.Create item in model)
            {
                InvoiceLineDto.Index index = await LineService.CreateAsync(item);
                lines.Add(index);
            }
            return lines;
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
