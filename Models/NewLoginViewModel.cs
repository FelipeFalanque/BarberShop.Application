using System.ComponentModel.DataAnnotations;

namespace BarberShop.Application.Models
{
    public class NewLoginViewModel
    {
        [Required, StringLength(100)]
        public string Nome { get; set; }

        [Required, StringLength(100)]
        public string Celular { get; set; }

        [Required, StringLength(10)]
        public string AnoNascimento { get; set; }

        public NewLoginViewModel()
        {
            Nome = string.Empty;
            Celular = string.Empty;
            AnoNascimento = string.Empty;
        }
    }
}
