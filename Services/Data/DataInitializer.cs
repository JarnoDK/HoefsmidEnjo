using Domain.Event;
using Domain.Invoice;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data
{

        public class DataInitializer
        {
            private readonly ApplicationDbContext _dbContext;

            public DataInitializer(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public void SeedData()
            {
                _dbContext.Database.EnsureDeleted();
                if (_dbContext.Database.EnsureCreated())
                {
                FillData();
                }
            }

        private void FillData()
        {
            _dbContext.Users.Add(new User("Jarno", "Dekeyser", "Wachtwoord", "0468", "Jarnodekeyser@hotmail.be", "04 92 88 72 59", HoefsmidEnjo.Shared.Users.UserRole.Klant));
            _dbContext.Users.Add(new User("Enjo", "Dekeyser", "Wachtwoord", "0468", "Enjodekeyser@hotmail.be", "04 92 88 72 59", HoefsmidEnjo.Shared.Users.UserRole.Klant));

            _dbContext.Events.Add(new Event("Warm beslag Miro", "Manege Partege", DateTime.Now, 1));
            _dbContext.Events.Add(new Event("Jumping", "Manege sunkawakan", DateTime.Now.AddDays(1).AddHours(-6).AddMinutes(-7), 1));

            _dbContext.Items.Add(new InvoiceItem("Linker voorpoot bekappen",35.00));
            _dbContext.Items.Add(new InvoiceItem("Controle", 10.00));


            _dbContext.SaveChanges();

            
        }

        }
    }
