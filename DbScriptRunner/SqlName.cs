using System.Text.RegularExpressions;

namespace DbScriptRunner;

internal static partial class SqlName
{
    public static string QuoteMultipart(string value)
    {
        var parts = value.Trim()
            .Split('.', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(UnwrapBracket)
            .ToArray();

        if (parts.Length == 0)
        {
            throw new InvalidOperationException("A SQL object name is empty.");
        }

        foreach (var part in parts)
        {
            if (!ValidIdentifier().IsMatch(part))
            {
                throw new InvalidOperationException($"SQL object name '{value}' contains unsupported characters.");
            }
        }

        return string.Join(".", parts.Select(part => $"[{part.Replace("]", "]]")}]"));
    }

    public static string QuoteDatabaseDboPrefix(string databaseName)
    {
        return string.IsNullOrWhiteSpace(databaseName)
            ? "[dbo]."
            : $"{QuoteMultipart(databaseName)}.[dbo].";
    }

    private static string UnwrapBracket(string part)
    {
        part = part.Trim();
        if (part.StartsWith("[", StringComparison.Ordinal) && part.EndsWith("]", StringComparison.Ordinal))
        {
            return part[1..^1].Replace("]]", "]");
        }

        return part;
    }

    [GeneratedRegex("^[A-Za-z0-9_-]+$")]
    private static partial Regex ValidIdentifier();
}

