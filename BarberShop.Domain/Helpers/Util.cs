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

        public static string ConvertDayOfWeekEnglishToPortuguese(string dayInEnglish)
        {
            // Mapping between day names in English and Portuguese
            Dictionary<string, string> dayMapping = new Dictionary<string, string>
            {
                { "Monday", "Segunda" },
                { "Tuesday", "Terça" },
                { "Wednesday", "Quarta" },
                { "Thursday", "Quinta" },
                { "Friday", "Sexta" },
                { "Saturday", "Sábado" },
                { "Sunday", "Domingo" }
            };

            // Try to get the Portuguese equivalent
            if (dayMapping.TryGetValue(dayInEnglish, out string dayInPortuguese))
            {
                return dayInPortuguese;
            }
            else
            {
                // Return a default message if no match is found
                return "Day not found";
            }
        }

        public static string ConvertDayOfWeekPortugueseToEnglish(string dayInPortuguese)
        {
            // Reverse mapping between day names in Portuguese and English
            Dictionary<string, string> reverseDayMapping = new Dictionary<string, string>
            {
                { "Segunda", "Monday" },
                { "Terça", "Tuesday" },
                { "Quarta", "Wednesday" },
                { "Quinta", "Thursday" },
                { "Sexta", "Friday" },
                { "Sábado", "Saturday" },
                { "Domingo", "Sunday" }
            };

            // Try to get the English equivalent
            if (reverseDayMapping.TryGetValue(dayInPortuguese, out string dayInEnglish))
            {
                return dayInEnglish;
            }
            else
            {
                // Return a default message if no match is found
                return "Day not found";
            }
        }
    }
}
