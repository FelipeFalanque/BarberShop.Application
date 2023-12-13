namespace BarberShop.Application.BarberShop.Domain.Entities
{
    public class Settings
    {
        public string Code { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public TypeSettings TypeSettings { get; set; }

        public string Identifier { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }
    }
    public enum TypeSettings
    {
        DayWork = 1,
        ReservedTimes = 2,
        AppointmentsHour = 3
    }
}
