using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdminApp.Common
{
    public static class ExtensionMethods
    {
        public static string RemoveHtml(this string value)
        {
            string PlainText = Regex.Replace(value, "<.*?>", String.Empty);

            return PlainText;
        }
    }
}
