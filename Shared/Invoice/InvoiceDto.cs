using FluentValidation;
using HoefsmidEnjo.Shared.InvoiceLine;
using HoefsmidEnjo.Shared.Users;
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
            public DateTime Time { get; set; }
            public UserDto.Index Client { get; set; } = new();
            public List<InvoiceLineDto.Index> InvoiceLines { get; set; }
        }

        public class Create
        {
            
            public UserDto.Index Client { get; set; }
            public List<InvoiceLineDto.Index> InvoiceLines { get; set; } = new();
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
