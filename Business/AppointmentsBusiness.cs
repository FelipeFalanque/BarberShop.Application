using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Helpers;
using BarberShop.Application.BarberShop.Domain.Interfaces;
using BarberShop.Application.Models;

namespace BarberShop.Application.Business
{
    public class AppointmentsBusiness
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ISettingsRepository _settingsRepository;

        public AppointmentsBusiness(IAppointmentService appointmentService, ISettingsRepository settingsRepository)
        {
            _appointmentService = appointmentService;
            _settingsRepository = settingsRepository;
        }

        public object GetAppointments()
        {
            //TODO : Trazar somente agendamentos do dia em questao.
            var appointmentsBD = _appointmentService.Get();
            var settings = _settingsRepository.GetByType(TypeSettings.DayWork);

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
                var configDay = settings.First(c => c.Identifier == dateBase.DayOfWeek.ToString());

                // Se verdadeiro, trabalhamos neste dia 
                if (!Convert.ToBoolean(configDay.Value))
                {
                    dateBase = dateBase.AddDays(1);
                }
                else
                {
                    TimeSpan timeSpanStart = Util.ParseTimeString(configDay.Start);
                    TimeSpan timeSpanEnd = Util.ParseTimeString(configDay.End);

                    switch (dayCurrent)
                    {
                        case 1:
                            dayOne = GetAppointmentsViewModel(new DateTime(dateBase.Year, dateBase.Month, dateBase.Day, timeSpanStart.Hours, 0, 0), appointmentsBD, timeSpanEnd);
                            break;
                        case 2:
                            dayTwo = GetAppointmentsViewModel(new DateTime(dateBase.Year, dateBase.Month, dateBase.Day, timeSpanStart.Hours, 0, 0), appointmentsBD, timeSpanEnd);
                            break;
                        case 3:
                            dayThree = GetAppointmentsViewModel(new DateTime(dateBase.Year, dateBase.Month, dateBase.Day, timeSpanStart.Hours, 0, 0), appointmentsBD, timeSpanEnd);
                            break;
                        case 4:
                            dayFour = GetAppointmentsViewModel(new DateTime(dateBase.Year, dateBase.Month, dateBase.Day, timeSpanStart.Hours, 0, 0), appointmentsBD, timeSpanEnd);
                            break;
                        case 5:
                            dayFive = GetAppointmentsViewModel(new DateTime(dateBase.Year, dateBase.Month, dateBase.Day, timeSpanStart.Hours, 0, 0), appointmentsBD, timeSpanEnd);
                            break;
                    }

                    dayCurrent++;
                    dateBase = dateBase.AddDays(1);
                }
            }

            return new { dayOne, dayTwo, dayThree, dayFour, dayFive };
        }

        private List<AppointmentViewModel> GetAppointmentsViewModel(DateTime date, IEnumerable<Appointment> appointmentsBD, TimeSpan lastTime)
        {
            var list = new List<AppointmentViewModel>();

            while (date.TimeOfDay <= lastTime)
            {
                AppointmentViewModel appointment = new AppointmentViewModel(date);

                if (appointmentsBD.Any( a => a.Day == date.Day &&
                                        a.Hour == date.Hour &&
                                        a.Minute == date.Minute &&
                                        a.Canceled == false))
                {
                    appointment.Available = false;
                }

                list.Add(appointment);

                date = date.AddMinutes(30);
            }

            return list;
        }
    }
}
