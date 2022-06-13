using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Helpers
{
    public class Utility
    {
        public static string UrlSeo(string text)
        {
            text = text.Trim();
            var ci = new CultureInfo("tr-TR");
            text = text.ToLower(ci);
            text = text.Replace(" ", "-");
            text = text.Replace("'", "");
            text = text.Replace(".", "");
            text = text.Replace(":", "");
            text = text.Replace(",", "");
            text = text.Replace(";", "");
            text = text.Replace("#", "");
            text = text.Replace("#8217;", "");
            text = text.Replace("/", "-");
            text = text.Replace("|", "");
            text = text.Replace(@"\", "-");
            text = text.Replace("<", "");
            text = text.Replace(">", "");
            text = text.Replace("&", "");
            text = text.Replace("[", "");
            text = text.Replace("]", "");
            text = text.Replace("+", "-");
            text = text.Replace("*", "-");
            text = text.Replace("(", "");
            text = text.Replace(")", "");
            text = text.Replace("$", "");
            text = text.Replace("=", "");
            text = text.Replace("?", "");
            text = text.Replace("€", "");
            text = text.Replace("ı", "i");
            text = text.Replace("ö", "o");
            text = text.Replace("ü", "u");
            text = text.Replace("ş", "s");
            text = text.Replace("ç", "c");
            text = text.Replace("ğ", "g");
            text = text.Replace("İ", "i");
            text = text.Replace("Ö", "o");
            text = text.Replace("Ü", "u");
            text = text.Replace("Ş", "s");
            text = text.Replace("Ç", "c");
            text = text.Replace("Ğ", "g");
            text = text.Replace("I", "i");
            text = text.Replace("!", "");
            text = text.Replace("?", "");
            text = text.Replace("!", "");
            text = text.Replace("?", "");
            text = text.Replace("`", "");
            text = text.Replace("´", "");
            text = text.Replace("’", "");
            text = text.Replace("ʻ", "");
            text = text.Replace("ʽ", "");
            text = text.Replace("ʾ", "");
            text = text.Replace("ʿ", "");
            text = text.Replace("ˊ", "");
            text = text.Replace("˝", "");
            text = text.Replace("ˮ", "");
            text = text.Replace("΄", "");
            text = text.Replace("ʹ", "");
            text = text.Replace("΄", "");
            text = text.Replace("′", "");
            text = text.Replace("‴", "");
            return text;
        }
    }
}
