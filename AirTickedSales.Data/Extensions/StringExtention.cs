using System;
using System.Collections.Generic;
using System.Text;

namespace AirTickedSales.Data.Extensions
{
    public static class StringExtention
    {
        public static bool HasValue(this string s)
        {
            return !string.IsNullOrEmpty(s);
        }

        public static DateTime? ToDate(this string s, string fomat = "dd/MM/yyyy")
        {
            DateTime result;
            if (DateTime.TryParseExact(s, fomat, null, System.Globalization.DateTimeStyles.None, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

    }
}
