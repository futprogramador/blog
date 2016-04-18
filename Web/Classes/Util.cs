using System.Text.RegularExpressions;

namespace Web.Classes
{
    public static class Util
    {
        public static string EncodeTextoParaUrl(string texto)
        {
            return Regex.Replace(texto, @"[^A-Za-z0-9_\.~]+", "-");
        }
    }
}