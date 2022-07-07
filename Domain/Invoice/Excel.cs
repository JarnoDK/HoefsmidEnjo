using HoefsmidEnjo.Shared.Invoice;
using HoefsmidEnjo.Shared.InvoiceItem;
using HoefsmidEnjo.Shared.InvoiceLine;
using HoefsmidEnjo.Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;

namespace Domain.Invoice
{
    public class Excel : ICreateInvoice
    {

        private int RowNumber = 1;
        private bool IsInit;
        private ExcelWorksheet worksheet;
        private ExcelPackage excel;
        private InvoiceDto.Index Invoice;

        public ICreateInvoice AddBuyer()
        {
            if (!IsInit)
            {
                return this;
            }
            UserDto.Detail buyer = Invoice.Client;
            worksheet.Cells[$"A{RowNumber}"].Value = buyer.FirstName + " " + buyer.LastName;
            RowNumber++;
            return this;
        }

        public ICreateInvoice AddConditions()
        {
            if (!IsInit)
            {
                return this;
            }

            return this;
        }

        public ICreateInvoice AddItems()
        {
            if (!IsInit)
            {
                return this;
            }

            worksheet.Cells[$"A{RowNumber}"].Value = "Product";
            worksheet.Cells[$"B{RowNumber}"].Value = "Amount";
            worksheet.Cells[$"C{RowNumber}"].Value = "Unit Price";
            worksheet.Cells[$"D{RowNumber}"].Value = "Total Price";

            RowNumber++;
            foreach ( InvoiceLineDto.Index invoiceline in Invoice.InvoiceLines)
            {
                //worksheet.Cells[$"A{RowNumber}"].Value = invoiceline.Item.Name;
                worksheet.Cells[$"B{RowNumber}"].Value = invoiceline.Amount;
                worksheet.Cells[$"C{RowNumber}"].Value = invoiceline.Item.UnitPrice;
                worksheet.Cells[$"D{RowNumber}"].Value = invoiceline.Item.UnitPrice * invoiceline.Amount;
                RowNumber++;
            }
            return this;
        }

        public ICreateInvoice AddPriceCalculation()
        {
            return this;
        }

        public ICreateInvoice AddSeller()
        {
            return this;
        }

        public ICreateInvoice Initialize(InvoiceDto.Index invoice)
        {
            var excel = new ExcelPackage();
            excel.Workbook.Worksheets.Add("Worksheet1");
            worksheet = excel.Workbook.Worksheets["Worksheet1"];

            worksheet.Name = $"{ invoice.Id}_{ invoice.Client.Id}_{ invoice.Time.Date.ToString("dd-MM-yyyy")}";


            IsInit = true;
            Invoice = invoice;
            return this;
        }

        public void Save()
        {
            if (!IsInit)
            {
                return;
            }
            FileInfo excelFile = new FileInfo(@"C:\Users\jarno\Desktop\test.xlsx");
            excel.SaveAs(excelFile);
        }
    }
}
