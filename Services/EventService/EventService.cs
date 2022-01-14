using Domain.Event;
using Domain.Users;
using HoefsmidEnjo.Shared.Event;
using HoefsmidEnjo.Shared.Users;
using Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HoefsmidEnjo.Shared;

namespace Services.EventService
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;
        private static IUserService _userservice;

        public EventService(ApplicationDbContext context, IUserService service)
        {
            _context = context;
            _userservice = service;
        }
        public async Task<EventDto.Index> CreateAsync(EventDto.Create model)
        {

            Event ev = new(model.Title, model.Location, Converters.ConvertDateTime(model.Time),model.Client.Id);
            _context.Events.Add(ev);
            _context.SaveChanges();

            return await EventToEventDto(ev);

        }



        private static async Task<EventDto.Index> EventToEventDto(Event ev)
        {
            UserDto.Detail us = await _userservice.GetAsync(ev.Client);
            return new EventDto.Index
            {
                Id = ev.Id,
                Client = us,
                Location = ev.Location,
                Time = ev.Time,
                Title = ev.Title
            };
        }



        public async Task DeleteAsync(int id)
        {
            _context.Events.Remove(_context.Events.FirstOrDefault(s => s.Id == id));
            _context.SaveChanges();

        }

        public async Task<IEnumerable<EventDto.Index>> GetAsync()
        {
            return _context.Events.Select(s => EventToEventDto(s).Result).AsEnumerable();
        }

        public async Task<EventDto.Index> GetAsync(int id)
        {
            return await EventToEventDto(_context.Events.SingleOrDefault(s => s.Id == id));
        }
    }
}
