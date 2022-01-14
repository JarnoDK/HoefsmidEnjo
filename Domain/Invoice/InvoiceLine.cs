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


        public int Item { get; set; }
        public int Amount { get; set; }
        
        public InvoiceLine(int amount, int item)
        {
            this.Amount = amount;
            this.Item = item;
        }
    }
}
