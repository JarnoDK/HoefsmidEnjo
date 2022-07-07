using HoefsmidEnjo.Shared.Event;
using Services.EventService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HoefsmidEnjoTesting.Services
{
    public class TestEventService
    {
        private readonly IEventService EventService = new FakeEventService();

        [Theory]
        [InlineData(-1, 1 , 2)]
        [InlineData(0, 1, 2)]
        [InlineData(0, 0, 2)]
        [InlineData(0, 20, 3)]
        [InlineData(-5, -3, 0)]
        public void EventServiceFromToIsValid(int st,int ed,int result)
        {
            DateTime start = DateTime.Now.AddDays(st);
            DateTime end = DateTime.Now.AddDays(ed);

            Assert.Equal(result,EventService.GetBetweenDatesAsync(start, end).Result.Count());
        }
    }
}
