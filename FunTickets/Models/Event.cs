using System.Net.Sockets;

namespace FunTickets.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;

     
        public int CategoryId { get; set; }
        public Categorys? Category { get; set; }

        
        public DateTime EventDateTime { get; set; }

        public string Owner { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
