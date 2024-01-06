using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Helpers;

namespace BarberShop.Application.Models
{
    public class PackageViewModel
    {
        public string Code { get; set; }

        public bool Canceled { get; set; }

        public string DayWeek { get; set; }

        public string Hour { get; set; }

        public string Minute { get; set; }

        public string ClientCode { get; set; }

        public string ClientName { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        public string LastPayment { get; set; }

        public List<PackagePaymentViewModel> PackagePayments { get; set; }

        public PackageViewModel()
        {
            
        }

        public PackageViewModel(Package packageDB)
        {
            this.Code = packageDB.Code;
            this.Canceled = packageDB.Canceled;
            DayOfWeek dayOfWeek = (DayOfWeek)packageDB.DayWeek;
            this.DayWeek = Util.ConvertDayOfWeekEnglishToPortuguese(dayOfWeek.ToString());
            this.Hour = Util.GetTwoCharacters(packageDB.Hour);
            this.Minute = Util.GetTwoCharacters(packageDB.Minute);
            this.ClientCode = packageDB.ClientCode;
            this.ClientName = packageDB.ClientName;
            this.Description = packageDB.Description;
            this.Value = packageDB.Value.ToString();
            this.LastPayment = packageDB.LastPayment.ToString("dd/MM/yyyy");
            this.PackagePayments = new List<PackagePaymentViewModel>();
            foreach (var packagePayment in packageDB.PackagePayments)
            {
                PackagePayments.Add(new PackagePaymentViewModel() {
                    DateRegister = packagePayment.DateRegister.ToString("dd/MM/yyyy"),
                    Value = packagePayment.Value.ToString()
                });
            }

        }
    }

    public class PackagePaymentViewModel
    {
        public string DateRegister { get; set; }

        public string Value { get; set; }
    }
}
