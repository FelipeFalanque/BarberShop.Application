using System.ComponentModel.DataAnnotations;

namespace BarberShop.Application.Models
{
    public class LoginViewModel
    {
        [Required, StringLength(100)]
        public string Celular { get; set; }

        [Required, StringLength(10)]
        public string Senha { get; set; }

        public bool Relembrar { get; set; }

        public string ReturnURL { get; set; }

        public LoginViewModel()
        {
            Celular = string.Empty;
            Senha = string.Empty;
            Relembrar = false;
            ReturnURL = string.Empty;
        }
    }
}
