using BarberShop.Application.BarberShop.Domain.Entities;

namespace BarberShop.Application.BarberShop.Domain.Interfaces
{
    public interface IAppointmentService
    {
        void Add(Appointment appointment);
        void Delete(Appointment appointment);
        void Edit(Appointment appointment);
        IEnumerable<Appointment> Get();
        Appointment Get(string code);
        IEnumerable<Appointment> GetByClientCode(string clientCode);
        bool IsAvailable(string virtualCode);
    }
}
