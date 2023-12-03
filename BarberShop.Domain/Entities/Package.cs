namespace BarberShop.Application.BarberShop.Domain.Entities
{
    public class Package
    {
        public string Code { get; set; }

        public DateTime DateRegister { get; set; } = DateTime.Now;

        public bool Canceled { get; set; }

        public short DayWeek { get; set; }

        public short Hour { get; set; }

        public short Minute { get; set; }

        public string ClientCode { get; set; }

        public string ClientName { get; set; }

        public string Description { get; set; }

        public double Value { get; set; }

        public DateTime LastPayment { get; set; } = DateTime.Now;

        public IEnumerable<PackagePayment> PackagePayments { get; set; }

        public Package()
        {
            Code = string.Empty;
            DateRegister = DateTime.Now;
            DayWeek = 0;
            Hour = 0;
            Minute = 0;
            ClientCode = string.Empty;
            Description = string.Empty;
            Value = 0;
            LastPayment = DateTime.Now;
            PackagePayments = new List<PackagePayment>();
        }
    }

    public class PackagePayment
    {
        public DateTime DateRegister { get; set; } = DateTime.Now;

        public double Value { get; set; } = 0;
    }
}
