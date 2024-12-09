using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LvlUp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50, ErrorMessage = "O nome deve conter no máximo 50 caracteres.")]
        [Required]
        public string FullName { get; set; }

        [MaxLength(15, ErrorMessage = "O telefone deve conter no máximo 15 números.")]
        public string PhoneNumber { get; set; }

        public string? ProfilePictureUrl { get; set; } 
    }
}
