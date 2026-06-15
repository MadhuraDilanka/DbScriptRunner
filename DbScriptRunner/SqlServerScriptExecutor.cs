using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace DbScriptRunner;

internal sealed partial class SqlServerScriptExecutor
{
    public async Task ExecuteAsync(
        IReadOnlyList<SqlExecutionStep> steps,
        ScriptRunnerOptions options,
        IProgress<string> progress,
        CancellationToken cancellationToken)
    {
        if (options.DryRun)
        {
            foreach (var step in steps)
            {
                progress.Report($"{step.ScriptName} - {step.StepName}");
                progress.Report(step.Sql);
                progress.Report(string.Empty);
            }

            return;
        }

        await using var connection = new SqlConnection(options.ConnectionString);
        await connection.OpenAsync(cancellationToken);

        SqlTransaction? transaction = null;
        if (options.UseTransaction)
        {
            transaction = (SqlTransaction)await connection.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        }

        try
        {
            foreach (var step in steps)
            {
                progress.Report($"Starting {step.ScriptName} - {step.StepName}");
                var totalRows = 0;

                foreach (var batch in SplitBatches(step.Sql))
                {
                    await using var command = connection.CreateCommand();
                    command.CommandText = batch;
                    command.CommandTimeout = options.CommandTimeoutSeconds;
                    command.Transaction = transaction;

                    var rows = await command.ExecuteNonQueryAsync(cancellationToken);
                    if (rows > 0)
                    {
                        totalRows += rows;
                    }
                }

                progress.Report($"Completed {step.ScriptName} - {step.StepName}. Rows affected: {totalRows}");
            }

            if (transaction is not null)
            {
                await transaction.CommitAsync(cancellationToken);
                progress.Report("Transaction committed.");
            }
        }
        catch
        {
            if (transaction is not null)
            {
                await transaction.RollbackAsync(CancellationToken.None);
                progress.Report("Transaction rolled back.");
            }

            throw;
        }
    }

    private static IEnumerable<string> SplitBatches(string sql)
    {
        var start = 0;
        foreach (Match match in GoBatchSeparator().Matches(sql))
        {
            var batch = sql[start..match.Index].Trim();
            if (!string.IsNullOrWhiteSpace(batch))
            {
                yield return batch;
            }

            start = match.Index + match.Length;
        }

        var last = sql[start..].Trim();
        if (!string.IsNullOrWhiteSpace(last))
        {
            yield return last;
        }
    }

    [GeneratedRegex(@"(?im)^\s*GO\s*(?:--.*)?$")]
    private static partial Regex GoBatchSeparator();
}

