using System.Collections.Generic;

namespace Models
{
    public class UserAccount
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
