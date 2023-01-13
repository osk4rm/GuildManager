using System.ComponentModel.DataAnnotations;

namespace GuildManager_Models
{
    public class RegisterUserDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required, StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Password and confirm password must match.")]
        public string ConfirmPassword { get; set; }
        public int RoleId { get; } = 1;
    }
}
