using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoefsmidEnjo.Shared.Event
{
    public interface IEventService
    {
        /*
         * Get all events
         */
        Task<IEnumerable<EventDto.Index>> GetAsync();

        Task<IEnumerable<EventDto.Index>> GetBetweenDatesAsync(DateTime start, DateTime end);

        Task<EventDto.Index> GetAsync(int id);
        Task<EventDto.Index> CreateAsync(EventDto.Create model);
        Task DeleteAsync(int id);
    }
}
