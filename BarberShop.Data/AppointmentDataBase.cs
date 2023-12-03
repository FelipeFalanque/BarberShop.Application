

using BarberShop.Application.BarberShop.Domain.Entities;

namespace BarberShop.Application.BarberShop.Data
{
    public static class AppointmentDataBase
    {
        public static List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
