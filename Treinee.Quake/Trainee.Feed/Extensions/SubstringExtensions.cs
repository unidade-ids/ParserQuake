using System;
using System.Collections.Generic;
using System.Text;

namespace Treinee.Feed.Extensions
{
    //font::https://www.dotnetperls.com/between-before-after
    static class SubstringExtensions
    {
        public static string Between(this string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.LastIndexOf(b);

            if (posA == -1)
            {
                return "";
            }

            if (posB == -1)
            {
                return "";
            }

            int adjustPosA = posA + a.Length;
            if (adjustPosA > posB)
            {
                return string.Empty;
            }

            return value.Substring(adjustPosA, posB - adjustPosA);
        }

        public static string Before(this string value, string a)
        {
            int posA = value.IndexOf(a);
            if (posA == -1)
            {
                return string.Empty;
            }

            return value.Substring(0, posA);
        }

        public static string After(this string value, string a)
        {
            int posA = value.LastIndexOf(a);
            if (posA == -1)
            {
                return string.Empty;
            }

            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= value.Length)
            {
                return string.Empty;
            }

            return value.Substring(adjustedPosA);
        }
    }
}
