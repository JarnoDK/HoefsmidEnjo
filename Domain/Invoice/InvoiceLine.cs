using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Invoice
{
    public class InvoiceLine : Entity
    {
        public InvoiceLine()
        {

        }


        public InvoiceItem Item { get; set; }
        public int Amount { get; set; }
        
        public InvoiceLine(int amount, InvoiceItem item)
        {
            this.Amount = amount;
            this.Item = item;
        }
    }
}
