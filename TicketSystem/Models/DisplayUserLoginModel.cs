using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Models
{
    public class DisplayUserLoginModel
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
