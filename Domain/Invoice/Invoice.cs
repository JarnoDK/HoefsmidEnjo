using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Users;

namespace Domain.Invoice
{
    public class Invoice:Entity
    {
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public List<InvoiceLine> invoiceLines { get; set; }
        public User User { get; set; }

        public Invoice()
        {

        }
        public Invoice(DateTime date, List<InvoiceLine> lines, User user)
        {
            this.Date = date;
            this.invoiceLines = lines;
            this.User = user;
        }
    }
}
