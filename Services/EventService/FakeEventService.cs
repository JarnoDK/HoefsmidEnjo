using HoefsmidEnjo.Shared.Event;
using HoefsmidEnjo.Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.EventService
{
    public class FakeEventService : IEventService
    {

        private readonly List<EventDto.Index> Events;
        private readonly IUserService userService;
        public FakeEventService(IUserService userService)
        {
            Events = new List<EventDto.Index>()
            {
                new EventDto.Index
                {
                    Id = 0,
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
                    Id = 1,
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
                Time = ConvertDateTime(model.Time),
                Title = model.Title,
                Client = model.Client
            };

            Events.Add(ev);
            return ev;

            
        
        }

        private DateTime ConvertDateTime(String dt){
            
            String[] split = dt.Split(" ");
            int[] datesplit = split[0].Split("/").Select(s => int.Parse(s)).ToArray();
            int[] timesplit = split[1].Split(":").Select(s => int.Parse(s)).ToArray();

            return new DateTime(datesplit[2],datesplit[1],datesplit[0],timesplit[0],timesplit[1],0);
            
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
