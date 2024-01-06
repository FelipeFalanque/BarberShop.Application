

using BarberShop.Application.BarberShop.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;

namespace BarberShop.Application.BarberShop.Data
{
    public static class PackageDataBase
    {
        public static List<Package> Packages { get; set; } = new List<Package>() {
            new Package ()
            {
                Code = "1228477a-cd70-4863-aec8-ee6bf0484452",
                Description = "Segunda",
                DayWeek = (short)DayOfWeek.Monday,
                Hour = 8,
                Minute = 0,
                Value =  120.0,
                Canceled = false,
                ClientCode = "1228477a-cd70-4863-aec8-ee6bf0484454",
                ClientName = "Jose Felipe",
                PackagePayments = new List<PackagePayment>
                {
                    new PackagePayment
                    {
                        Value = 50.00,
                        DateRegister = new DateTime(2023, 11, 16)
                    },
                    new PackagePayment
                    {
                        Value = 50.00,
                        DateRegister = new DateTime(2024, 01, 03)
                    }
                }
            },
            new Package ()
            {
                Code = "1228477a-cd70-4863-aec8-ee6bf0484453",
                Description = "Terça",
                DayWeek = (short)DayOfWeek.Tuesday,
                Hour = 13,
                Minute = 30,
                Value =  150.0,
                Canceled = false,
                ClientCode = "1228477a-cd70-4863-aec8-ee6bf0484455",
                ClientName = "Joao Felipe",
                PackagePayments = new List<PackagePayment>
                {
                    new PackagePayment
                    {
                        Value = 150.00,
                        DateRegister = new DateTime(2023, 10, 12)
                    },
                    new PackagePayment
                    {
                        Value = 250.00,
                        DateRegister = new DateTime(2023, 11, 10)
                    },
                    new PackagePayment
                    {
                        Value = 50.00,
                        DateRegister = new DateTime(2023, 12, 11)
                    }
                }
            }
        };
    }
}

