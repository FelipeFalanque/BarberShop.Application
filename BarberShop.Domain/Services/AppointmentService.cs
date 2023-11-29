using BarberShop.Application.BarberShop.Data.Repositories;
using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Interfaces;

namespace BarberShop.Application.BarberShop.Domain.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public void Add(Appointment appointment)
        {
            _appointmentRepository.Add(appointment);
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
            return _appointmentRepository.Get();
        }

        public Appointment Get(string code)
        {
            return _appointmentRepository.Get(code);
        }

        public IEnumerable<Appointment> GetByClientCode(string clientCode)
        {
            return _appointmentRepository.Get();
        }
    }
}
