using System.Numerics;

namespace BarberShop.Application.BarberShop.Domain.Helpers
{
    public static class Util
    {
        public static string GetTwoCharacters(int number)
        {
             if (number < 10) return string.Concat("0", number.ToString());
            else return string.Concat(number.ToString());
        }
        
        public static string GetOnlyNumbers(string text)
        {
            return String.Join("", System.Text.RegularExpressions.Regex.Split(text, @"[^\d]"));
        }        
        
        public static string GetFormattedPhone(string unformattedPhone)
        {
            return long.Parse(unformattedPhone).ToString(@"(00) 00000-0000"); // (49) 98807-0405
        }
        
        public static string GetDayOfWeekPTBR(DayOfWeek dayOfWeek)
        {
            string dayOfWeekPTBR = string.Empty;

            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    dayOfWeekPTBR = "Domingo";
                    break;
                case DayOfWeek.Monday:
                    dayOfWeekPTBR = "Segunda";
                    break;
                case DayOfWeek.Tuesday:
                    dayOfWeekPTBR = "Terça";
                    break;
                case DayOfWeek.Wednesday:
                    dayOfWeekPTBR = "Quarta";
                    break;
                case DayOfWeek.Thursday:
                    dayOfWeekPTBR = "Quinta";
                    break;
                case DayOfWeek.Friday:
                    dayOfWeekPTBR = "Sexta";
                    break;
                case DayOfWeek.Saturday:
                    dayOfWeekPTBR = "Sábado";
                    break;
                default:
                    dayOfWeekPTBR = string.Empty;
                    break;
            }

            return dayOfWeekPTBR;
        }

        public static TimeSpan ParseTimeString(string timeString)
        {
            // Dividindo a string em horas e minutos
            string[] timeComponents = timeString.Split(':');

            if (timeComponents.Length == 2 && int.TryParse(timeComponents[0], out int hours) && int.TryParse(timeComponents[1], out int minutes))
            {
                // Criando um TimeSpan com as horas e minutos
                return new TimeSpan(hours, minutes, 0);
            }
            else
            {
                // Se a string não estiver no formato esperado, lança uma exceção ou retorna um valor padrão
                throw new ArgumentException("A string de tempo não está no formato esperado (HH:mm).");
                // ou
                // return TimeSpan.Zero; // ou outro valor padrão
            }
        }
    }
}
