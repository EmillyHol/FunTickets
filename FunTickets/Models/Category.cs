using System.ComponentModel.DataAnnotations;

namespace FunTickets.Models
{
    public class Category
    {
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; } = string.Empty;

        public ICollection<Activite>? Activites { get; set; }
    }
}
