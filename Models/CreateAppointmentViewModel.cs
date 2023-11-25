using BarberShop.Application.BarberShop.Domain.Helpers;
using Microsoft.VisualBasic;

namespace BarberShop.Application.Models
{
    public class CreateAppointmentViewModel
    {

        public string Day { get; set; }

        public string Month { get; set; }

        public string Year { get; set; }

        public string Hour { get; set; }

        public string Minute { get; set; }

        public string Observation { get; set; }


    }
}
