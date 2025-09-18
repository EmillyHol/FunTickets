namespace FunTickets.Models
{
    public class Categorys
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        // Navigation property
        public List<Tickets>? Tickets { get; set; }
    }
}
