using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace DbScriptRunner;

internal sealed class QueryResultService
{
    public async Task<IReadOnlyList<string>> LoadBranchesAsync(
        string connectionString,
        int commandTimeoutSeconds,
        CancellationToken cancellationToken)
    {
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);

        await using var command = connection.CreateCommand();
        command.CommandText = "SELECT DISTINCT [Branch Name] FROM [dbo].[TempRefTable] WHERE [Branch Name] IS NOT NULL ORDER BY [Branch Name]";
        command.CommandTimeout = commandTimeoutSeconds;

        var branches = new List<string>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            branches.Add(reader.GetString(0));
        }

        return branches;
    }

    public async Task<QueryResults> LoadResultsAsync(
        string connectionString,
        IReadOnlyList<string> sourceTables,
        IReadOnlyList<string> documentTables,
        string branchName,
        int commandTimeoutSeconds,
        CancellationToken cancellationToken)
    {
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);

        var duplicateData = new DataTable("Duplicated Data");
        foreach (var documentTable in documentTables)
        {
            var tableResult = await ExecuteDataTableAsync(
                connection,
                BuildDuplicateSql(documentTable),
                branchName,
                commandTimeoutSeconds,
                cancellationToken);

            MergeTable(duplicateData, tableResult);
        }

        var missingDocuments = await ExecuteDataTableAsync(
            connection,
            BuildMissingDocumentsSql(sourceTables, documentTables),
            branchName,
            commandTimeoutSeconds,
            cancellationToken);
        missingDocuments.TableName = "Missing Documents";

        return new QueryResults(duplicateData, missingDocuments);
    }

    private static async Task<DataTable> ExecuteDataTableAsync(
        SqlConnection connection,
        string sql,
        string branchName,
        int commandTimeoutSeconds,
        CancellationToken cancellationToken)
    {
        await using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.CommandTimeout = commandTimeoutSeconds;
        command.Parameters.Add(new SqlParameter("@BranchName", SqlDbType.NVarChar, 255) { Value = branchName });

        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        var table = new DataTable();
        table.Load(reader);
        return table;
    }

    private static string BuildDuplicateSql(string documentTable)
    {
        var quotedDocumentTable = SqlName.QuoteMultipart(documentTable);
        return $"""
            SELECT '{quotedDocumentTable.Replace("'", "''")}' AS [DocumentTable], t.*
            FROM {quotedDocumentTable} t
            WHERE t.DocumentUID IN (
                SELECT DocumentUID
                FROM {quotedDocumentTable}
                WHERE Branch = @BranchName
                GROUP BY DocumentUID
                HAVING COUNT(DocumentUID) > 1
            )
            ORDER BY t.DocumentUID;
            """;
    }

    private static string BuildMissingDocumentsSql(IReadOnlyList<string> sourceTables, IReadOnlyList<string> documentTables)
    {
        var builder = new StringBuilder();

        builder.AppendLine("SELECT u.Unique_ID");
        builder.AppendLine("FROM (");
        AppendUnion(builder, sourceTables, table => $"    SELECT [Unique_ID] FROM {SqlName.QuoteMultipart(table)}");
        builder.AppendLine(") AS u");
        builder.AppendLine("WHERE NOT EXISTS (");
        builder.AppendLine("    SELECT 1");
        builder.AppendLine("    FROM (");
        AppendUnion(builder, documentTables, table => $"        SELECT DocumentUID FROM {SqlName.QuoteMultipart(table)} WHERE [Branch] = @BranchName");
        builder.AppendLine("    ) AS indextable");
        builder.AppendLine("    WHERE indextable.DocumentUID = u.Unique_ID");
        builder.AppendLine(");");

        return builder.ToString();
    }

    private static void AppendUnion(StringBuilder builder, IReadOnlyList<string> tables, Func<string, string> selectFactory)
    {
        for (var i = 0; i < tables.Count; i++)
        {
            if (i > 0)
            {
                builder.AppendLine("    UNION ALL");
            }

            builder.AppendLine(selectFactory(tables[i]));
        }
    }

    private static void MergeTable(DataTable target, DataTable source)
    {
        if (target.Columns.Count == 0)
        {
            foreach (DataColumn column in source.Columns)
            {
                target.Columns.Add(column.ColumnName, column.DataType);
            }
        }

        foreach (DataRow row in source.Rows)
        {
            target.ImportRow(row);
        }
    }
}

internal sealed record QueryResults(DataTable DuplicateData, DataTable MissingDocuments);

