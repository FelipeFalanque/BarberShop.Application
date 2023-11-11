using BarberShop.Application.BarberShop.Domain.Interfaces;
using BarberShop.Application.Models;

namespace BarberShop.Application.Business
{
    public class Appointments
    {
        private readonly IAppointmentService _appointmentService;

        public Appointments()
        {
        }

        public Appointments(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public object GetAppointments()
        {

            // three four five
            var dayOne = new List<AppointmentViewModel>();
            var dayTwo = new List<AppointmentViewModel>();
            var dayThree = new List<AppointmentViewModel>();
            var dayFour = new List<AppointmentViewModel>();
            var dayFive = new List<AppointmentViewModel>();

            DateTime dateBase = DateTime.Now;

            int dayCurrent = 1;
            while (dayCurrent <= 5)
            {
                if (dateBase.DayOfWeek == DayOfWeek.Saturday || dateBase.DayOfWeek == DayOfWeek.Sunday)
                {
                    dateBase = dateBase.AddDays(1);
                }
                else
                {
                    switch (dayCurrent)
                    {
                        case 1:
                            dayOne = GetAppointmentsViewModel(new DateTime(dateBase.Year, dateBase.Month, dateBase.Day, 8, 0, 0));
                            break;
                        case 2:
                            dayTwo = GetAppointmentsViewModel(new DateTime(dateBase.Year, dateBase.Month, dateBase.Day, 8, 0, 0));
                            break;
                        case 3:
                            dayThree = GetAppointmentsViewModel(new DateTime(dateBase.Year, dateBase.Month, dateBase.Day, 8, 0, 0));
                            break;
                        case 4:
                            dayFour = GetAppointmentsViewModel(new DateTime(dateBase.Year, dateBase.Month, dateBase.Day, 8, 0, 0));
                            break;
                        case 5:
                            dayFive = GetAppointmentsViewModel(new DateTime(dateBase.Year, dateBase.Month, dateBase.Day, 8, 0, 0));
                            break;
                    }

                    dayCurrent++;
                    dateBase = dateBase.AddDays(1);
                }
            }

            return new { dayOne, dayTwo, dayThree, dayFour, dayFive };
        }

        private List<AppointmentViewModel> GetAppointmentsViewModel(DateTime date)
        {
            var list = new List<AppointmentViewModel>();

            for (int i = 0;i < 20;i++)
            {
                list.Add(new AppointmentViewModel(date));
                date.AddMinutes(30);
            }

            return list;
        }
    }
}
