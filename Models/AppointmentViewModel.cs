using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Helpers;
using Microsoft.VisualBasic;
using System;

namespace BarberShop.Application.Models
{
    public class AppointmentViewModel
    {
        public string Title { get; set; }

        public string Day { get; set; }

        public string DayText { get; set; }

        public string Month { get; set; }

        public string Year { get; set; }

        public string Hour { get; set; }

        public string Minute { get; set; }

        public bool Available { get; set; } = true;

        public string Code { get; set; }

        public AppointmentViewModel(DateTime date)
        {
            Code = string.Empty;
            Available = true;
            Day = Util.GetTwoCharacters(date.Day);
            DayText = string.Format("{0} {1}/{2}", Util.GetDayOfWeekPTBR(date.DayOfWeek), Util.GetTwoCharacters(date.Day), Util.GetTwoCharacters(date.Month));
            Month = Util.GetTwoCharacters(date.Month);
            Year = date.Year.ToString();
            Hour = Util.GetTwoCharacters(date.Hour);
            Minute = Util.GetTwoCharacters(date.Minute);

            Title = String.Concat(Hour, ":", Minute);
        }

        public AppointmentViewModel(Appointment appointmentDB)
        {
            Code = appointmentDB.Code;
            Available = !appointmentDB.Canceled;
            Day = Util.GetTwoCharacters(appointmentDB.Day);
            DayText = string.Format("{0} {1}/{2}", Util.GetDayOfWeekPTBR((new DateTime(appointmentDB.Year, appointmentDB.Month, appointmentDB.Day)).DayOfWeek), Util.GetTwoCharacters(appointmentDB.Day), Util.GetTwoCharacters(appointmentDB.Month));
            Month = Util.GetTwoCharacters(appointmentDB.Month);
            Year = appointmentDB.Year.ToString();
            Hour = Util.GetTwoCharacters(appointmentDB.Hour);
            Minute = Util.GetTwoCharacters(appointmentDB.Minute);

            Title = String.Concat(Hour, ":", Minute);
        }

    }
}
