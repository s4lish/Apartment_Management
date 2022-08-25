using System.ComponentModel.DataAnnotations;

namespace AM.Server.Data.DataModel
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Family { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = default!;
        public byte[] PasswordSalt { get; set; } = default!;

        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public bool IsLocked { get; set; } = false;
        public bool IsDelete { get; set; } = false;
    }
}
