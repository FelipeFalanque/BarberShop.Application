using BarberShop.Application.BarberShop.Domain.Helpers;
using Microsoft.VisualBasic;

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

        public AppointmentViewModel(DateTime date)
        {
            Day = Util.GetTwoCharacters(date.Day);
            DayText = date.DayOfWeek.ToString();
            Month = Util.GetTwoCharacters(date.Month);
            Year = date.Year.ToString();
            Hour = Util.GetTwoCharacters(date.Hour);
            Minute = Util.GetTwoCharacters(date.Minute);

            Title = String.Concat(Hour, ":", Minute);
        }
        

    }
}
