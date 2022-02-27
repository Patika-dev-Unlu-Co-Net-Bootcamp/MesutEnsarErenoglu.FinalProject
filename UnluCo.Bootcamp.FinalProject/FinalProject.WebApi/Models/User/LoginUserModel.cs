

using FinalProject.Common.PasswordValidator;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinalProject.WebApi.Models.User
{
    public class LoginUserModel
    {
        [Required(ErrorMessage = "Email adresi gereklidir!")]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur!")]
        [Password(ErrorMessage = "Şifreniz en az bir büyük harf, bir küçük harf ve bir sayı içermeli, aynı zamanda en az 8 karakter olmalıdır!")]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
