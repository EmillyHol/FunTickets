using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace FunTickets.Models
{
    public class Activite
    {

        public int ActiviteId { get; set; }
        public string ActiviteName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;

     
        public int CategoryId { get; set; }
        public Category? Category { get; set; }


        public DateTime ActivityDateTime { get; set; }


        public string Owner { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? ImageFilename { get; set; }

        // For storing the photograph as a byte array
        [NotMapped]
        [Display(Name = "Photograph")]
        public IFormFile? FormFile { get; set; }//nullable
      
    }

}
