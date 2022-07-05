using System.ComponentModel.DataAnnotations;
using TicketSystem.Managers;

namespace TicketSystem.Models
{
    public class DisplayAdminTicketModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public TicketStatus Status { get; set; }
    }
}
