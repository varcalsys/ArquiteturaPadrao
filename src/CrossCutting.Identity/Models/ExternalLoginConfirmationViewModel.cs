using System.ComponentModel.DataAnnotations;

namespace CrossCutting.Identity.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}