using System.Text.RegularExpressions;

namespace nexaas.heineken.model
{
    public static class Utils
    {
        public static string RemoveDots(this string str)
        {
            return Regex.Replace(str, "[ ().-]+", "");
        }
    }
}
