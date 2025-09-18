namespace FunTickets.Models
{
    public class Tickets
    {
        public int TicketId { get; set; }
        public string TicketName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Foreign key
        public int CategoryId { get; set; }
        //Navigation property
        public Categorys? Category { get; set; }

        public int EventId { get; set; }

        public Event? Event { get; set; }
    }
}
