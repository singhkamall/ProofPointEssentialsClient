using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofPointEssentialsCSharpClient.Utility
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string text) => string.IsNullOrEmpty(text);

        public static bool IsNullOrWhiteSpace(this string text) => string.IsNullOrWhiteSpace(text);

        public static string EnsureEndsWith(this string text, string endsWith)
        {
            if (text.Substring(text.Length - endsWith.Length) == endsWith)
                return text;

            return text + endsWith;
        }
    }
}
