using System.Net.Sockets;

namespace FunTickets.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;

        // Category relationship
        public int CategoryId { get; set; }
        public Categorys? Category { get; set; }

        // Event schedule
        public DateTime EventDateTime { get; set; }

        public string Owner { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
