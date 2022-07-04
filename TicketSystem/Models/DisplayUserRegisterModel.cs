using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Models
{
    public class DisplayUserRegisterModel
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [MinLength(8)]
        public string RepeatPassword { get; set; }
    }
}
