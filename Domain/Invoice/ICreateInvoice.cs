using HoefsmidEnjo.Shared.Invoice;
using HoefsmidEnjo.Shared.InvoiceItem;
using HoefsmidEnjo.Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Invoice;

public interface ICreateInvoice
{
    ICreateInvoice Initialize(InvoiceDto.Index invoice);
    ICreateInvoice AddSeller();
    ICreateInvoice AddBuyer();
    ICreateInvoice AddItems();
    ICreateInvoice AddConditions();
    ICreateInvoice AddPriceCalculation();
    void Save();

}
