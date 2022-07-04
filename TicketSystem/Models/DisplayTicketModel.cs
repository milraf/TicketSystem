using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Models
{
    public class DisplayTicketModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
