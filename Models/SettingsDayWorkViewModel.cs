using BarberShop.Application.BarberShop.Domain.Entities;

namespace BarberShop.Application.Models
{
    public class SettingsDayWorkViewModel
    {
        public string Code { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public string Day { get; set; }

        public bool Open { get; set; }

        public string Description { get; set; }

        public SettingsDayWorkViewModel()
        {
            
        }

        public SettingsDayWorkViewModel(Settings settingsDB)
        {
            this.Code = settingsDB.Code;
            this.Start = settingsDB.Start;
            this.End = settingsDB.End;
            this.Day = settingsDB.Identifier;
            this.Open = Convert.ToBoolean(settingsDB.Value);
            this.Description = settingsDB.Description;
        }
    }
}
