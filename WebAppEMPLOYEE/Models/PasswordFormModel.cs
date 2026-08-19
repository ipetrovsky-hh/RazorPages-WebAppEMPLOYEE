using System.ComponentModel.DataAnnotations;

namespace WebAppEMPLOYEE.Models
{
    public class PasswordFormModel
    {
        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
