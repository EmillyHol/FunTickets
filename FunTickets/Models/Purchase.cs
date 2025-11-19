using System.ComponentModel.DataAnnotations;

namespace FunTickets.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

        // Number of tickets
        
        public int TicketQuantity { get; set; }

        public string CustomerEmail { get; set; }

        public string CardExpiry { get; set; }
        public string CardCVC { get; set; }
        public int ActiviteId { get; set; }
        public Activite? Activite { get; set; }


    }
}
