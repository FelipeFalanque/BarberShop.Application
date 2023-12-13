

using BarberShop.Application.BarberShop.Domain.Entities;

namespace BarberShop.Application.BarberShop.Data
{
    public static class SettingsDataBase
    {
        public static List<Settings> Settings { get; set; } = new List<Settings>() {
            new Settings() {
                Code = "1228477a-cd70-4863-aec8-ee6bf0484452",
                Description = "Segunda",
                Start = "08:00",
                End = "20:00",
                Identifier = DayOfWeek.Monday.ToString(),
                TypeSettings = TypeSettings.DayWork,
                Value = false.ToString()
            },
            new Settings() {
                Code = "1228477a-cd70-4863-aec8-ee6bf0484453",
                Description = "Terça",
                Start = "08:00",
                End = "20:00",
                Identifier = DayOfWeek.Tuesday.ToString(),
                TypeSettings = TypeSettings.DayWork,
                Value = true.ToString()
            },
            new Settings() {
                Code = "1228477a-cd70-4863-aec8-ee6bf0484454",
                Description = "Quarta",
                Start = "08:00",
                End = "20:00",
                Identifier = DayOfWeek.Wednesday.ToString(),
                TypeSettings = TypeSettings.DayWork,
                Value = true.ToString()
            },
            new Settings() {
                Code = "1228477a-cd70-4863-aec8-ee6bf0484455",
                Description = "Quinta",
                Start = "08:00",
                End = "20:00",
                Identifier = DayOfWeek.Thursday.ToString(),
                TypeSettings = TypeSettings.DayWork,
                Value = false.ToString()
            },
            new Settings() {
                Code = "1228477a-cd70-4863-aec8-ee6bf0484456",
                Description = "Sexta",
                Start = "08:00",
                End = "20:00",
                Identifier = DayOfWeek.Friday.ToString(),
                TypeSettings = TypeSettings.DayWork,
                Value = false.ToString()
            },
            new Settings() {
                Code = "1228477a-cd70-4863-aec8-ee6bf0484457",
                Description = "Sábado",
                Start = "08:00",
                End = "20:00",
                Identifier = DayOfWeek.Saturday.ToString(),
                TypeSettings = TypeSettings.DayWork,
                Value = true.ToString()
            },
            new Settings() {
                Code = "1228477a-cd70-4863-aec8-ee6bf0484458",
                Description = "Domingo",
                Start = "08:00",
                End = "20:00",
                Identifier = DayOfWeek.Sunday.ToString(),
                TypeSettings = TypeSettings.DayWork,
                Value = false.ToString()
            }
        };
    }
}
