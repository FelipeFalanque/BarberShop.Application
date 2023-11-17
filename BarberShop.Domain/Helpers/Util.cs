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
    }
}
