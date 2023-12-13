using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Interfaces;

namespace BarberShop.Application.BarberShop.Domain.Services
{
    public class SettingsServices : BaseService<Settings>, ISettingsService
    {
        private readonly ISettingsRepository settingsRepository;

        public SettingsServices(ISettingsRepository settingsRepository)
            : base(settingsRepository)
        {
            this.settingsRepository = settingsRepository ?? throw new ArgumentNullException(nameof(settingsRepository));
        }

        public IEnumerable<Settings> GetByType(TypeSettings typeSettings)
        {
            return settingsRepository.GetByType(typeSettings);
        }
    }
}
