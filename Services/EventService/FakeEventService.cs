using HoefsmidEnjo.Shared.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.EventService
{
    public class FakeEventService : IEventService
    {

        private static readonly List<EventDto.Index> Events;
        static FakeEventService()
        {
            Events = new List<EventDto.Index>()
            {
                new EventDto.Index
                {
                    Id = 1,
                    Location = "Manege t'paardje",
                    Time = DateTime.Now,
                    Title = "Linker voorpoot Aysha",
                    Client = new(){
                        FirstName = "Melissa",
                        LastName = "Benoit",
                        Email = "MelissaBenoit@Test.be",
                        Id = 1,
                        Phone = "0492887259"

                    }
                },
                new EventDto.Index
                {
                    Id = 2,
                    Location = "Manege t'paardje",
                    Time = DateTime.Now,
                    Title = "Rechter achterpoot Mira",
                    Client = new(){
                        FirstName = "Marie",
                        LastName = "Droite",
                        Email = "MarieDroit@Test.be",
                        Id = 2,
                        Phone = "0492887259"
                    }
                }
            };
        }
        public async Task<EventDto.Index> CreateAsync(EventDto.Create model)
        {
            await Task.Delay(100);
            EventDto.Index ev = new()
            {
                Id = (Events.Count + 1),
                Location = model.Location,
                Time = model.Time,
                Title = model.Title,
                Client = model.Client
            };

            Events.Add(ev);
            return ev;
        
                }

        public async Task DeleteAsync(int id)
        {
  
            await Task.Delay(100);
            EventDto.Index ev = Events.FirstOrDefault(x => x.Id == id);
            if(ev != null)
            {
                Events.Remove(ev);
            }
        }

        public async Task<IEnumerable<EventDto.Index>> GetAsync()
        {
            await Task.Delay(100);
            return Events.OrderBy(x => x.Time).ThenBy(x => x.Title);
        }

        public async Task<EventDto.Index> GetAsync(int id)
        {
            await Task.Delay(100);
            return Events.FirstOrDefault(x => x.Id == id);
        }
    }
}
