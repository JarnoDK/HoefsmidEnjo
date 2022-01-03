using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoefsmidEnjo.Shared.InvoiceItem
{
    public abstract class InvoiceItemDto
    {
        public class Index
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public double UnitPrice { get; set; }
        }

        public class Create
        {
            public string Name { get; set; }
            public double UnitPrice { get; set; }
            public class Validator : AbstractValidator<Create>
            {
                public Validator()
                {
                    RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(3).WithName("Item naam");
                    RuleFor(x => x.UnitPrice).GreaterThan(0).WithName("Prijs per stuk");
                }
            }
        }

    }
}
