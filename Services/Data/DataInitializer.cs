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
                fillData();
                }
            }

        private void fillData()
        {
            _dbContext.Users.Add(new User("Jarno", "Dekeyser", "Wachtwoord", "0468", "Jarnodekeyser@hotmail.be", "04 92 88 72 59", HoefsmidEnjo.Shared.Users.UserRole.Klant));


            _dbContext.SaveChanges();

            
        }

        }
    }
