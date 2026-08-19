using System.ComponentModel.DataAnnotations;

namespace WebAppEMPLOYEE.Models
{
    public class ProfileFormModel
    {
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
