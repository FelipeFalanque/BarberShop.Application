using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Interfaces;

namespace BarberShop.Application.BarberShop.Domain.Services
{
    public class AppointmentService : IAppointmentService
    {
        public void Add(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public void Delete(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public void Edit(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> Get()
        {
            throw new NotImplementedException();
        }

        public Appointment Get(string code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetByClientCode(string clientCode)
        {
            throw new NotImplementedException();
        }

        public object GetAppointments()
        {
            return new object { };
        }
    }
}
