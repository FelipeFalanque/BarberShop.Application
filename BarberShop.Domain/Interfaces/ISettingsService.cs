using BarberShop.Application.BarberShop.Domain.Entities;

namespace BarberShop.Application.BarberShop.Domain.Interfaces
{
    public interface ISettingsService : IService<Settings>
    {
        IEnumerable<Settings> GetByType(TypeSettings typeSettings);
    }
}
