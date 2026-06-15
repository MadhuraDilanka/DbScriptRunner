namespace DbScriptRunner;

internal sealed record SqlExecutionStep(string ScriptName, string StepName, string Sql);

