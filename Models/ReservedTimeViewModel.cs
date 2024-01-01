using BarberShop.Application.BarberShop.Domain.Entities;

namespace BarberShop.Application.Models
{
    public class ReservedTimeViewModel
    {
        public string Code { get; set; }

        public string Start { get; set; }

        public string Day { get; set; }

        public string Description { get; set; }

        public ReservedTimeViewModel()
        {
            
        }

        public ReservedTimeViewModel(Settings settingsDB)
        {
            this.Code = settingsDB.Code;
            this.Start = settingsDB.Start;
            this.Day = settingsDB.Identifier;
            this.Description = settingsDB.Description;
        }
    }
}
