using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Application.DTOs
{
    public class AppUserDto 
    {
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public Guid ActivationKey { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "İsim girişi zorunludur!")]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olmaz")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim girişi zorunludur!")]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olmaz")]
        public string LastName { get; set; }

        private string _fullname;
        public string FullName
        {
            get
            {
                if (FirstName != null && LastName != null)
                {
                    _fullname = $"{FirstName} {LastName}";
                }
                else
                {
                    _fullname = "Name Surname";
                }
                return _fullname;
            }
        }

        [Required]
        [MaxLength(250, ErrorMessage = "250 karakterden fazla olamaz")]
        public string Address { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olmaz")]
        public string City { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olmaz")]
        public string Region { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olamaz")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Doğum tarihi giriş yapmanız gereklidir!")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        public bool? Gender { get; set; }

        private short _age;

        public short Age
        {
            get
            {
                _age = Convert.ToInt16(DateTime.Now.Year - BirthDate.Year);
                return _age;
            }
        }

        public List<ProductDto> Products { get; set; }
    }
}
