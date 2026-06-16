namespace DbScriptRunner;

public partial class Form1 : Form
{
    private CancellationTokenSource? _runCancellation;

    public Form1()
    {
        InitializeComponent();
        txtScriptsFolder.Text = Path.Combine(AppContext.BaseDirectory, "Scripts");
        txtSourceTables.Text = string.Join(Environment.NewLine, Enumerable.Range(1, 7).Select(i => $"[dbo].[BattaramullaFile_{i}]"));
        txtDocumentTables.Text = string.Join(Environment.NewLine, new[]
        {
            "[C514C7EC-DAA2-4DA5-8E82-98901BE1671C]",
            "[8F84E32E-C274-4602-B84F-636B05DEC873]",
            "[D8276AD1-1835-4E12-A1D0-DFF90D38F89B]",
            "[39FED7CB-4485-4F82-AEC8-86C5FFA66606]",
            "[324BE33C-7FE8-4A4E-8153-8C09D755EA37]",
            "[906F9D91-3CA7-49B5-82B9-4AD4CDF9ECA6]"
        });
        txtCommandTimeout.Text = "0";
    }

    private async void btnRun_Click(object sender, EventArgs e)
    {
        await RunAsync(dryRun: false);
    }

    private async void btnLoadBranches_Click(object sender, EventArgs e)
    {
        await LoadBranchesAsync();
    }

    private async void btnRunResults_Click(object sender, EventArgs e)
    {
        await RunResultQueriesAsync();
    }

    private async void btnPreview_Click(object sender, EventArgs e)
    {
        await RunAsync(dryRun: true);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        _runCancellation?.Cancel();
    }

    private void btnBrowseScripts_Click(object sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog
        {
            Description = "Select folder containing scripts 01 through 05",
            SelectedPath = Directory.Exists(txtScriptsFolder.Text) ? txtScriptsFolder.Text : AppContext.BaseDirectory
        };

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            txtScriptsFolder.Text = dialog.SelectedPath;
        }
    }

    private async Task RunAsync(bool dryRun)
    {
        ToggleRunning(true);
        txtLog.Clear();
        _runCancellation = new CancellationTokenSource();

        try
        {
            var options = ReadOptions(dryRun);
            var steps = SqlScriptBuilder.BuildSteps(options);

            Log($"Prepared {steps.Count} step(s).");
            if (!dryRun)
            {
                Log(options.UseTransaction ? "Running inside one transaction." : "Running without a transaction.");
            }

            var progress = new Progress<string>(Log);
            await new SqlServerScriptExecutor().ExecuteAsync(steps, options, progress, _runCancellation.Token);
            Log(dryRun ? "Preview complete." : "Run complete.");
        }
        catch (OperationCanceledException)
        {
            Log("Run cancelled.");
        }
        catch (Exception ex)
        {
            Log("ERROR: " + ex.Message);
        }
        finally
        {
            _runCancellation.Dispose();
            _runCancellation = null;
            ToggleRunning(false);
        }
    }

    private async Task LoadBranchesAsync()
    {
        ToggleRunning(true);
        txtLog.Clear();
        _runCancellation = new CancellationTokenSource();

        try
        {
            var connectionString = txtConnectionString.Text.Trim();
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Connection string is required.");
            }

            var branches = await new QueryResultService().LoadBranchesAsync(
                connectionString,
                ReadCommandTimeout(),
                _runCancellation.Token);

            cboBranch.Items.Clear();
            cboBranch.Items.AddRange(branches.Cast<object>().ToArray());

            if (cboBranch.Items.Count > 0)
            {
                cboBranch.SelectedIndex = 0;
            }

            Log($"Loaded {branches.Count} branch(es).");
        }
        catch (OperationCanceledException)
        {
            Log("Load branches cancelled.");
        }
        catch (Exception ex)
        {
            Log("ERROR: " + ex.Message);
        }
        finally
        {
            _runCancellation.Dispose();
            _runCancellation = null;
            ToggleRunning(false);
        }
    }

    private async Task RunResultQueriesAsync()
    {
        ToggleRunning(true);
        txtLog.Clear();
        _runCancellation = new CancellationTokenSource();

        try
        {
            var branchName = cboBranch.Text.Trim();
            if (string.IsNullOrWhiteSpace(branchName))
            {
                throw new InvalidOperationException("Select a branch first.");
            }

            var options = ReadOptions(dryRun: false);
            var results = await new QueryResultService().LoadResultsAsync(
                options.ConnectionString,
                options.SourceTables,
                options.DocumentTables,
                branchName,
                options.CommandTimeoutSeconds,
                _runCancellation.Token);

            gridDuplicateData.DataSource = results.DuplicateData;
            gridMissingDocuments.DataSource = results.MissingDocuments;

            Log($"Duplicated data rows: {results.DuplicateData.Rows.Count}");
            Log($"Missing documents rows: {results.MissingDocuments.Rows.Count}");
        }
        catch (OperationCanceledException)
        {
            Log("Result query cancelled.");
        }
        catch (Exception ex)
        {
            Log("ERROR: " + ex.Message);
        }
        finally
        {
            _runCancellation.Dispose();
            _runCancellation = null;
            ToggleRunning(false);
        }
    }

    private ScriptRunnerOptions ReadOptions(bool dryRun)
    {
        return new ScriptRunnerOptions(
            txtConnectionString.Text.Trim(),
            txtScriptsFolder.Text.Trim(),
            ParseLines(txtSourceTables.Text),
            ParseLines(txtDocumentTables.Text),
            ReadCommandTimeout(),
            chkTransaction.Checked,
            dryRun);
    }

    private int ReadCommandTimeout()
    {
        var timeout = int.TryParse(txtCommandTimeout.Text.Trim(), out var parsedTimeout) ? parsedTimeout : 0;
        return timeout <= 0 ? 0 : timeout;
    }

    private static IReadOnlyList<string> ParseLines(string text)
    {
        return text
            .Split(new[] { "\r\n", "\n", "\r", "," }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Where(line => !line.StartsWith("--", StringComparison.Ordinal))
            .ToArray();
    }

    private void ToggleRunning(bool isRunning)
    {
        btnRun.Enabled = !isRunning;
        btnPreview.Enabled = !isRunning;
        btnLoadBranches.Enabled = !isRunning;
        btnRunResults.Enabled = !isRunning;
        btnCancel.Enabled = isRunning;
        btnBrowseScripts.Enabled = !isRunning;
        UseWaitCursor = isRunning;
    }

    private void Log(string message)
    {
        if (txtLog.TextLength > 0)
        {
            txtLog.AppendText(Environment.NewLine);
        }

        txtLog.AppendText(message);
    }
}
