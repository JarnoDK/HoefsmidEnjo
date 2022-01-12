using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Users;

namespace Domain.Event
{
    public class Event:Entity
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public int Client { get; set; }

        public Event()
        {

        }

        public Event(string title, string location, DateTime time, int client)
        {
            this.Title = title;
            this.Location = location;
            this.Time = time;
            this.Client = client;
        }
    }
}
