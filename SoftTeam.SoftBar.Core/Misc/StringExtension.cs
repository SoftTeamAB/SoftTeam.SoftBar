using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTeam.SoftBar.Core.Misc
{
    public static class StringExtension
    {
        public static int NumberOfLines(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;

            int count = 1;
            int position = 0;
            while ((position = text.IndexOf('\n', position)) != -1)
            {
                count++;
                position++;         // Skip this occurrence!
            }
            return count;
        }

        public static string RestrictSize(this string text, int maxRows = 3, int maxCols = 40)
        {
            if (maxRows <= 0)
                throw new ArgumentOutOfRangeException("MaxRows must be 1 or higher!");
            if (maxCols <= 0)
                throw new ArgumentOutOfRangeException("MaxCols must be 1 or higher!");
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            string[] lines = text.Split('\n');
            string newText = string.Empty;

            for (int i = 0; i < Math.Min(maxRows, lines.Length); i++)
            {
                if (!string.IsNullOrEmpty(newText))
                    newText += '\n';
                var line = lines[i].Trim();
                newText += (line == null) ? string.Empty : line.Substring(0, Math.Min(maxCols, line.Length));
            }

            return newText;
        }
    }
}
