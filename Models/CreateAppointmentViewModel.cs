using BarberShop.Application.BarberShop.Domain.Entities;
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

        public string AppointmentCode { get
            {
                return this.Day + this.Month + this.Year + this.Hour + this.Minute;
            }
        }

        public Appointment GetAppointmentBD(string clientCode)
        {
            Appointment appointment = new Appointment();

            appointment.VirtualCode = this.AppointmentCode;
            appointment.Day = Convert.ToInt16(this.Day);
            appointment.Month = Convert.ToInt16(this.Month);
            appointment.Year = Convert.ToInt16(this.Year);
            appointment.Hour = Convert.ToInt16(this.Hour);
            appointment.Minute = Convert.ToInt16(this.Minute);
            appointment.Description = Observation;
            appointment.ClientCode = clientCode;

            return appointment;
        } 
    }
}
