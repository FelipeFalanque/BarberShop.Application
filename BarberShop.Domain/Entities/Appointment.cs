namespace BarberShop.Application.BarberShop.Domain.Entities
{
    public class Appointment
    {
        public string Code { get; set; }

        public string VirtualCode { get; set; }

        public DateTime DateRegister { get; set; } = DateTime.Now;

        public bool Canceled { get; set; }

        public short Day { get; set; }

        public short Month { get; set; }

        public short Year { get; set; }

        public short Hour { get; set; }

        public short Minute { get; set; }

        public string ClientCode { get; set; }

        public string Description { get; set; }

        public Appointment()
        {
            Code = string.Empty;
            VirtualCode = string.Empty;
            DateRegister = DateTime.Now;
            Day = 0;
            Month = 0;
            Year = 0;
            Hour = 0;
            Minute = 0;
            ClientCode = string.Empty;
            Description = string.Empty;
        }
    }
}
