

using FinalProject.Common.PasswordValidator;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.WebApi.Models.User
{
    public class ChangeUserPassword
    {

        [Required(ErrorMessage = "Şifre zorunludur!")]
        [Password(ErrorMessage = "Şifreniz en az bir büyük harf, bir küçük harf ve bir sayı içermeli, aynı zamanda en az 8 karakter olmalıdır!")]
        public string newPassword { get; set; }

        [Required(ErrorMessage = "Şifre onayı zorunludur!")]
        [Compare("newPassword", ErrorMessage ="Yeni şifreniz ile aynı olmalıdır!")]
        public string newPasswordConfirm { get; set; }
    }
}
