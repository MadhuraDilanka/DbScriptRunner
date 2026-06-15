namespace DbScriptRunner;

public sealed record ScriptRunnerOptions(
    string ConnectionString,
    string ScriptsFolder,
    IReadOnlyList<string> SourceTables,
    IReadOnlyList<string> DocumentTables,
    int CommandTimeoutSeconds,
    bool UseTransaction,
    bool DryRun);
