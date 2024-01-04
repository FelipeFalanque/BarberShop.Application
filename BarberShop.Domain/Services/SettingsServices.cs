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

        // Sobreescrita do método Add
        public new void Add(Settings settings)
        {
            // Lógica adicional, se necessário, antes de chamar o método da base
            if (String.IsNullOrEmpty(settings.Code))
            {
                settings.Code = Guid.NewGuid().ToString();
            }

            // Chama o método Add da classe base
            base.Add(settings);

            // Lógica adicional, se necessário, após chamar o método da base
            // ...
        }
    }
}
