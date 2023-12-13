using BarberShop.Application.BarberShop.Domain.Entities;

namespace BarberShop.Application.BarberShop.Domain.Interfaces
{
    public interface ISettingsRepository : IRepository<Settings>
    {
        IEnumerable<Settings> GetByType(TypeSettings typeSettings);
    }
}
