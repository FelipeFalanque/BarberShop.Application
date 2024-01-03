using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Helpers;

namespace BarberShop.Application.Models
{
    public class ReservedTimeViewModel
    {
        public string Code { get; set; }

        public string Hour { get; set; }

        public string Day { get; set; }

        public string Description { get; set; }

        public ReservedTimeViewModel()
        {
            
        }

        public ReservedTimeViewModel(Settings settingsDB)
        {
            this.Code = settingsDB.Code;
            this.Hour = settingsDB.Start;
            this.Day = Util.ConvertDayOfWeekEnglishToPortuguese(settingsDB.Identifier);
            this.Description = settingsDB.Description;
        }
    }
}
