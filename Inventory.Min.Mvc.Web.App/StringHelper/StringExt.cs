//Microsoft Public License (Ms-PL)
//http://visualizer.codeplex.com/license

using System;
using System.Collections.Generic;

namespace Redwerb.BizArk.Core.StringExt;

/// <summary>
/// Provides extension methods for strings.
/// </summary>
public static class StringExt
{
    /// <summary>
    /// Forces the string to word wrap so that each line doesn't exceed the maxLineLength.
    /// </summary>
    /// <param name="str">The string to wrap.</param>
    /// <param name="maxLength">The maximum number of characters per line.</param>
    /// <returns></returns>
    public static string Wrap(this string str, int maxLength)
    {
        return Wrap(str, maxLength, "");
    }

    /// <summary>
    /// Forces the string to word wrap so that each line doesn't exceed the maxLineLength.
    /// </summary>
    /// <param name="str">The string to wrap.</param>
    /// <param name="maxLength">The maximum number of characters per line.</param>
    /// <param name="prefix">Adds this string to the beginning of each line.</param>
    /// <returns></returns>
    public static string Wrap(this string str, int maxLength, string prefix)
    {
        if (string.IsNullOrEmpty(str)) return "";
        if (maxLength <= 0) return prefix + str;

        var lines = new List<string>();

        // breaking the string into lines makes it easier to process.
        foreach (string line in str.Split("\n".ToCharArray()))
        {
            var remainingLine = line.Trim();
            do
            {
                var newLine = GetLine(remainingLine, maxLength - prefix.Length);
                lines.Add(newLine);
                remainingLine = remainingLine.Substring(newLine.Length).Trim();
                // Keep iterating as int as we've got words remaining 
                // in the line.
            } while (remainingLine.Length > 0);
        }

        return string.Join(Environment.NewLine + prefix, lines.ToArray());
    }
    
    private static string GetLine(string str, int maxLength)
    {
        // The string is less than the max length so just return it.
        if (str.Length <= maxLength) return str;

        // Search backwords in the string for a whitespace char
        // starting with the char one after the maximum length
        // (if the next char is a whitespace, the last word fits).
        for (int i = maxLength; i >= 0; i--)
        {
            if (char.IsWhiteSpace(str[i]))
                return str.Substring(0, i).TrimEnd();
        }

        // No whitespace chars, just break the word at the maxlength.
        return str.Substring(0, maxLength);
    }
}