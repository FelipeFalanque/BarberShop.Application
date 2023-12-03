using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Interfaces;

namespace BarberShop.Application.BarberShop.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public AppointmentRepository()
        {
        }

        public void Add(Appointment appointment)
        {
            appointment.Code = Guid.NewGuid().ToString();
            AppointmentDataBase.Appointments.Add(appointment);
        }

        public void Delete(Appointment appointment)
        {
            AppointmentDataBase.Appointments.RemoveAll(x => x.Code == appointment.Code);
        }

        public void Edit(Appointment appointment)
        {
            AppointmentDataBase.Appointments.RemoveAll(x => x.Code == appointment.Code);
            AppointmentDataBase.Appointments.Add(appointment);
        }

        public IEnumerable<Appointment> Get()
        {
            return AppointmentDataBase.Appointments;
        }

        public Appointment Get(string code)
        {
            return AppointmentDataBase.Appointments.FirstOrDefault(x => x.Code == code);
        }

        public IEnumerable<Appointment> GetByClientCode(string clientCode)
        {
            return AppointmentDataBase.Appointments.Where(x => x.ClientCode == clientCode);
        }
    }
}
