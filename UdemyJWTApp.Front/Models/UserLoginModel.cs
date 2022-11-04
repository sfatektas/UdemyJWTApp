using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace UdemyJWTApp.Front.Models
{
    public class UserLoginModel
    {
        [NotNull]
        public string Username { get; set; }  = string.Empty;

        [NotNull]
        [MaxLength(60)]
        public string Password { get; set; } = string.Empty;
    }
}
