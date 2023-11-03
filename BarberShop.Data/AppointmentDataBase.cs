

using BarberShop.Application.BarberShop.Domain.Entities;

namespace BarberShop.Application.BarberShop.Data
{
    public static class AppointmentDataBase
    {
        public static List<Appointment> Appointments { get; set; } = new List<Appointment>() {
                new Appointment() {
                    Code = "1228477a-cd70-4863-aec8-ee6bf04844522023",
                    ClientCode = "1228477a-cd70-4863-aec8-ee6bf0484451",
                    DateRegister = DateTime.Now,
                    Canceled = false,
                    Day = 7,
                    Month = 10,
                    Year = 2023,
                    Hour = 10,
                    Minute = 30,
                },
                new Appointment() {
                    Code = "1228477a-cd70-4863-aec8-ee6bf04844532023",
                    ClientCode = "1228477a-cd70-4863-aec8-ee6bf0484451",
                    DateRegister = DateTime.Now,
                    Day = 17,
                    Month = 9,
                    Year = 2023,
                    Hour = 10,
                    Minute = 30
                },
                new Appointment() {
                    Code = "1228477a-cd70-4863-aec8-ee6bf04844542023",
                    ClientCode = "1228477a-cd70-4863-aec8-ee6bf0484451",
                    DateRegister = DateTime.Now,                    
                    Day = 10,
                    Month = 9,
                    Year = 2023,
                    Hour = 9,
                    Minute = 0
                }
            };
    }
}
