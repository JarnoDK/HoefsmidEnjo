using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Invoice
{
    public class InvoiceItem: Entity
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }

        public InvoiceItem()
        {

        }
        public InvoiceItem(String name, double unitprice)
        {
            Name = name;
            UnitPrice = unitprice;
        }
    }
}
