using Domain.Event;
using Domain.Invoice;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data
{
    public class ApplicationDbContext:DbContext
    {

            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<Invoice> Invoices { get; set; }
            public DbSet<InvoiceLine> InvoiceLine { get; set; }
            public DbSet<Event> Events { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<InvoiceItem> Items { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
        }
    }

