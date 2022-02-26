
using FinalProject.Common.PasswordValidator;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.WebApi.Models.User
{
    public class AddAppUserModel
    {

        [Required(ErrorMessage ="Email adresi gereklidir!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon numarası gereklidir")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur!")]
        [Password(ErrorMessage = "Şifreniz en az bir büyük harf, bir küçük harf ve bir sayı içermeli, aynı zamanda en az 8 karakter olmalıdır!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "İsim girişi zorunludur!")]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olmaz")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim girişi zorunludur!")]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olmaz")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Adres girişi zorunludur!")]
        [MaxLength(250, ErrorMessage = "250 karakterden fazla olamaz")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Şehrinizi belirtiniz!")]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olmaz")]
        public string City { get; set; }

        [Required(ErrorMessage = "İlçenizi belirtiniz!")]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olmaz")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Doğum tarihi giriş yapmanız gereklidir!")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        public bool? Gender { get; set; } // True Male- False Female


    }
}
