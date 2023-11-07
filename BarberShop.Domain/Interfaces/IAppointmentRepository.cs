using BarberShop.Application.BarberShop.Domain.Entities;

namespace BarberShop.Application.BarberShop.Domain.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IEnumerable<Appointment> GetByClientCode(string clientCode);
    }
}
