using System.Text;
using System.Text.RegularExpressions;

namespace DbScriptRunner;

internal static partial class SqlScriptBuilder
{
    public static IReadOnlyList<SqlExecutionStep> BuildSteps(ScriptRunnerOptions options)
    {
        ValidateOptions(options);

        var files = Directory
            .EnumerateFiles(options.ScriptsFolder, "*.sql")
            .OrderBy(Path.GetFileName, StringComparer.OrdinalIgnoreCase)
            .Where(path => Regex.IsMatch(Path.GetFileName(path), @"^0[1-5]\b", RegexOptions.IgnoreCase))
            .ToArray();

        if (files.Length == 0)
        {
            throw new InvalidOperationException("No SQL files named 01 through 05 were found in the script folder.");
        }

        var steps = new List<SqlExecutionStep>();
        foreach (var file in files)
        {
            var scriptName = Path.GetFileName(file);
            var rawSql = File.ReadAllText(file);

            if (scriptName.StartsWith("04", StringComparison.OrdinalIgnoreCase) ||
                scriptName.StartsWith("05", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var documentTable in options.DocumentTables)
                {
                    var documentTableSql = ApplyReplacements(rawSql, options, documentTable);
                    steps.Add(new SqlExecutionStep(scriptName, $"Document table {documentTable}", documentTableSql.Trim()));
                }

                continue;
            }

            var sql = ApplyReplacements(rawSql, options);
            var markers = RunMarker().Matches(sql);

            if (markers.Count == 0)
            {
                steps.Add(new SqlExecutionStep(scriptName, "Full script", sql.Trim()));
                continue;
            }

            var sharedSql = sql[..markers[0].Index].TrimEnd();
            for (var i = 0; i < markers.Count; i++)
            {
                var marker = markers[i];
                var blockStart = marker.Index + marker.Length;
                var blockEnd = i + 1 < markers.Count ? markers[i + 1].Index : sql.Length;
                var block = UncommentSql(sql[blockStart..blockEnd]).Trim();

                if (string.IsNullOrWhiteSpace(block))
                {
                    continue;
                }

                steps.Add(new SqlExecutionStep(scriptName, $"Run {marker.Groups["run"].Value}", $"{sharedSql}{Environment.NewLine}{Environment.NewLine}{block}"));
            }
        }

        return steps;
    }

    private static void ValidateOptions(ScriptRunnerOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.ConnectionString) && !options.DryRun)
        {
            throw new InvalidOperationException("Connection string is required.");
        }

        if (string.IsNullOrWhiteSpace(options.ScriptsFolder) || !Directory.Exists(options.ScriptsFolder))
        {
            throw new InvalidOperationException("Script folder does not exist.");
        }

        if (options.SourceTables.Count == 0)
        {
            throw new InvalidOperationException("At least one source table is required.");
        }

        if (options.DocumentTables.Count == 0)
        {
            throw new InvalidOperationException("At least one document table is required.");
        }
    }

    private static string ApplyReplacements(string sql, ScriptRunnerOptions options, string? indexTableName = null)
    {
        sql = ReplaceSourceUnion(sql, options.SourceTables);

        if (options.DocumentTables.Count > 0)
        {
            sql = ReplaceDocumentUnion(sql, options.DocumentTables);
        }

        if (!string.IsNullOrWhiteSpace(indexTableName))
        {
            sql = sql.Replace("[IndexTbaleName]", SqlName.QuoteMultipart(indexTableName), StringComparison.OrdinalIgnoreCase);
        }

        sql = sql.Replace("[Enadoc12688B9B38A4000].[dbo].", "[dbo].", StringComparison.OrdinalIgnoreCase);

        return sql;
    }

    private static string ReplaceSourceUnion(string sql, IReadOnlyList<string> sourceTables)
    {
        return SourceUnion().Replace(sql, match =>
        {
            var indent = match.Groups["indent"].Value;
            var columns = match.Groups["cols"].Value.Trim();
            return BuildUnion(indent, columns, sourceTables);
        });
    }

    private static string ReplaceDocumentUnion(string sql, IReadOnlyList<string> documentTables)
    {
        return DocumentUnion().Replace(sql, match =>
        {
            var indent = match.Groups["indent"].Value;
            var columns = match.Groups["cols"].Value.Trim();
            return BuildUnion(indent, columns, documentTables);
        });
    }

    private static string BuildUnion(string indent, string columns, IReadOnlyList<string> tables)
    {
        var builder = new StringBuilder();

        for (var i = 0; i < tables.Count; i++)
        {
            if (i > 0)
            {
                builder.AppendLine();
                builder.Append(indent).AppendLine("UNION ALL");
            }

            builder.Append(indent)
                .Append("SELECT ")
                .Append(columns)
                .Append(" FROM ")
                .Append(SqlName.QuoteMultipart(tables[i]));
        }

        return builder.ToString();
    }

    private static string UncommentSql(string block)
    {
        return CommentPrefix().Replace(block, string.Empty);
    }

    [GeneratedRegex(@"(?m)^\s*--\s*(?:Uncomment\s+and\s+)?Run\s+(?<run>\d+)(?:st|nd|rd|th)?\s*$", RegexOptions.IgnoreCase)]
    private static partial Regex RunMarker();

    [GeneratedRegex(@"(?m)^\s*-- ?", RegexOptions.IgnoreCase)]
    private static partial Regex CommentPrefix();

    [GeneratedRegex(@"(?s)(?<indent>[ \t]*)SELECT\s+(?<cols>[^\r\n]+?)\s+FROM\s+\[dbo\]\.\[BattaramullaFile_1\](?:\s*UNION\s+ALL\s*SELECT\s+[^\r\n]+?\s+FROM\s+\[dbo\]\.\[BattaramullaFile_\d+\])+", RegexOptions.IgnoreCase)]
    private static partial Regex SourceUnion();

    [GeneratedRegex(@"(?s)(?<indent>[ \t]*)SELECT\s+(?<cols>DOCUMENTID,\s*DocumentUID)\s+FROM\s+\[[0-9A-F-]{36}\](?:\s*UNION\s+ALL\s*SELECT\s+DOCUMENTID,\s*DocumentUID\s+FROM\s+\[[0-9A-F-]{36}\])+", RegexOptions.IgnoreCase)]
    private static partial Regex DocumentUnion();
}
