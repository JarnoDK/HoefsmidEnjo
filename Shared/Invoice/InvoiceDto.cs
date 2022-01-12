using FluentValidation;
using HoefsmidEnjo.Shared.InvoiceLine;
using HoefsmidEnjo.Shared.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoefsmidEnjo.Shared.Invoice
{
    public abstract class InvoiceDto
    {
        public class Index
        {
            public int Id { get; set; }
            [JsonConverter(typeof(DateFormatConverter),"dd/MM/yyyy HH:mm")]
            public DateTime Time { get; set; }
            public UserDto.Index Client { get; set; } = new();
            public List<InvoiceLineDto.Index> InvoiceLines { get; set; } = new();
        }

        public class Create
        {
            
            public UserDto.Index Client { get; set; }
            public List<InvoiceLineDto.Create> InvoiceLines { get; set; } = new();
            public string Time { get; set; }

            public class Validator : AbstractValidator<Create> {

                public Validator()
                {
                    RuleFor(x => x.Client).NotNull().WithMessage("Klant");
                    RuleFor(x => x.InvoiceLines).Must(x => x.Count > 0);
                }
            }


        }


    }
}
