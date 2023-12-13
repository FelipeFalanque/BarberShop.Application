using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Interfaces;

namespace BarberShop.Application.BarberShop.Data.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        public SettingsRepository()
        {
        }

        public void Add(Settings settings)
        {
            settings.Code = Guid.NewGuid().ToString();
            SettingsDataBase.Settings.Add(settings);
        }

        public void Delete(Settings settings)
        {
            SettingsDataBase.Settings.RemoveAll(x => x.Code == settings.Code);
        }

        public void Edit(Settings settings)
        {
            SettingsDataBase.Settings.RemoveAll(x => x.Code == settings.Code);
            SettingsDataBase.Settings.Add(settings);
        }

        public IEnumerable<Settings> Get()
        {
            return SettingsDataBase.Settings;
        }

        public Settings Get(string code)
        {
            return SettingsDataBase.Settings.FirstOrDefault(x => x.Code == code);
        }

        public IEnumerable<Settings> GetByType(TypeSettings typeSettings)
        {
            return SettingsDataBase.Settings.Where(x => x.TypeSettings == typeSettings);
        }
    }
}
