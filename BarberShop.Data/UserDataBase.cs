

using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Helpers;

namespace BarberShop.Application.BarberShop.Data
{
    public static class UserDataBase
    {
        public static List<User> Users { get; set; } = new List<User>() {
                new User() {
                    Code = "1228477a-cd70-4863-aec8-ee6bf0484451",
                    Name = "Cesar Felipe",
                    Email = "felipe@gmail.com",
                    Phone = "11111",
                    YearOfBirth = "2000",
                    Password = PasswordHelp.EncodePasswordToBase64("1234"),
                    Administrator = false,
                    DateRegister = DateTime.Now
                },
                new User() {
                    Code = "1228477a-cd70-4863-aec8-ee6bf0484452",
                    Name = "Eduardo Castor",
                    Email = "eduardo@gmail.com",
                    Phone = "22222",
                    YearOfBirth = "2000",
                    Password = PasswordHelp.EncodePasswordToBase64("1234"),
                    Administrator = true,
                    DateRegister = DateTime.Now
                },
                new User() {
                    Code = "1228477a-cd70-4863-aec8-ee6bf0484453",
                    Name = "Marai Felipe",
                    Email = "maria@gmail.com",
                    Phone = "33333",
                    YearOfBirth = "2000",
                    Password = PasswordHelp.EncodePasswordToBase64("1234"),
                    Administrator = false,
                    DateRegister = DateTime.Now
                },
                new User() {
                    Code = "1228477a-cd70-4863-aec8-ee6bf0484454",
                    Name = "Jose Felipe",
                    Email = "jose@gmail.com",
                    Phone = "44444",
                    YearOfBirth = "2000",
                    Password = PasswordHelp.EncodePasswordToBase64("1234"),
                    Administrator = false,
                    DateRegister = DateTime.Now
                },
                new User() {
                    Code = "1228477a-cd70-4863-aec8-ee6bf0484455",
                    Name = "Joao Felipe",
                    Email = "joao@gmail.com",
                    Phone = "55555",
                    YearOfBirth = "2000",
                    Password = PasswordHelp.EncodePasswordToBase64("1234"),
                    Administrator = false,
                    DateRegister = DateTime.Now
                }
            };
    }
}
