using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Helpers;
using System.ComponentModel.DataAnnotations;

namespace BarberShop.Application.Models
{
    public class UserViewModel
    {
        [Required]
        public string Code { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public string? Email { get; set; }

        [Required, MinLength(15), MaxLength(15)]
        public string Phone { get; set; }

        [Required, MinLength(4), MaxLength(4)]
        public string YearOfBirth { get; set; }

        public string? Password { get; set; }

        public string RegistrationDate { get; set; }

        public UserViewModel()
        {
            Code = string.Empty;
            Name = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            YearOfBirth = string.Empty;
            Password = string.Empty;
            RegistrationDate = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public UserViewModel(User userDB)
        {
            Code = userDB.Code;
            Name = userDB.Name;
            Email = userDB.Email;
            Phone = Util.GetFormattedPhone(userDB.Phone);
            YearOfBirth = userDB.YearOfBirth;
            Password = string.Empty;
            RegistrationDate = userDB.DateRegister.ToString("dd/MM/yyyy");
        }
    }
}
