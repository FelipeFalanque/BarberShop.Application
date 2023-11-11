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
    }
}
