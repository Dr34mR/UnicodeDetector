using System;
using System.Text;

namespace UnicodeDetector
{
    internal static class StringExtensions
    {
        public static string EnsureAscii(this string inString)
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.convert?view=net-5.0

            // The example displays the following output:
            //    Original string: This string contains the unicode character Pi (Π)
            //    Ascii converted string: This string contains the unicode character Pi (?)

            if (string.IsNullOrEmpty(inString)) return inString;

            // Create two different encodings.
            var ascii = Encoding.ASCII;
            var unicode = Encoding.Unicode;

            // Convert the string into a byte array.
            var unicodeBytes = unicode.GetBytes(inString);

            // Perform the conversion from one encoding to the other.
            var asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            // Convert the new byte[] into a char[] and then into a string.
            var asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            var asciiString = new string(asciiChars);

            return asciiString;
        }

        public static int ComputeDistance(this string s, string t)
        {
            var n = s.Length;
            var m = t.Length;
            var d = new int[n + 1, m + 1];

            // Verify arguments.
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Initialize arrays.
            for (var i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (var j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Begin looping.
            for (var i = 1; i <= n; i++)
            {
                for (var j = 1; j <= m; j++)
                {
                    // Compute cost.
                    var cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Return cost.
            return d[n, m];
        }
    }
}
