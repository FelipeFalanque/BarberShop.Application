namespace BarberShop.Application.BarberShop.Domain.Entities
{
    public class User
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string YearOfBirth { get; set; }

        public string Password { get; set; }

        public bool Administrator { get; set; }

        public DateTime DateRegister { get; set; }

        public User()
        {
            Code = string.Empty;
            Name = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            YearOfBirth = string.Empty;
            Password = string.Empty;
            Administrator = false;
            DateRegister = DateTime.MinValue;
        }
    }
}
