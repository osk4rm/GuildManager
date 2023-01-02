namespace GuildManagerAPI.Models.Auth
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int RoleId { get; } = 1;
    }
}
