using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinalProject.Application.DTOs
{
    public class AppUserDto 
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [JsonPropertyName("phonenumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("activationkey")]
        public Guid ActivationKey { get; set; }
        [JsonPropertyName("isactive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("firstname")]
        [Required(ErrorMessage = "İsim girişi zorunludur!")]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olmaz")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastname")]
        [Required(ErrorMessage = "Soyisim girişi zorunludur!")]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olmaz")]
        public string LastName { get; set; }

        private string _fullname;

        [JsonPropertyName("fullname")]
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

        [JsonPropertyName("address")]
        [Required]
        [MaxLength(250, ErrorMessage = "250 karakterden fazla olamaz")]
        public string Address { get; set; }

        [JsonPropertyName("city")]
        [Required]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olmaz")]
        public string City { get; set; }

        [JsonPropertyName("region")]
        [Required]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olmaz")]
        public string Region { get; set; }

       

        [JsonPropertyName("birthdate")]
        [Required(ErrorMessage = "Doğum tarihi giriş yapmanız gereklidir!")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        private short _age;

        [JsonPropertyName("age")]
        public short Age
        {
            get
            {
                _age = Convert.ToInt16(DateTime.Now.Year - BirthDate.Year);
                return _age;
            }
        }

        [JsonPropertyName("products")]
        public List<ProductDto> Products { get; set; }
    }
}
