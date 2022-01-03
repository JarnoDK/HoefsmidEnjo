using FluentValidation;
using HoefsmidEnjo.Shared.InvoiceItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoefsmidEnjo.Shared.InvoiceLine
{
    public abstract class InvoiceLineDto
    {
        public class Index
        {
            public int Id { get; set; }
            public InvoiceItemDto.Index Item { get; set; }
            public int Amount { get; set; }
        }
        public class Create
        {
            public InvoiceItemDto.Index Item { get; set; }
            public int Amount { get; set; }
            public class Validator : AbstractValidator<Create>
            {
                public Validator()
                {
                    RuleFor(x => x.Item).NotNull().WithName("Product");
                    RuleFor(x => x.Amount).NotEmpty().GreaterThan(0).WithName("Aantal");
                }
            }
        }
    }
}
