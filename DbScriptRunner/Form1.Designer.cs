namespace DbScriptRunner;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        lblConnectionString = new Label();
        txtConnectionString = new TextBox();
        lblScriptsFolder = new Label();
        txtScriptsFolder = new TextBox();
        btnBrowseScripts = new Button();
        lblSourceTables = new Label();
        txtSourceTables = new TextBox();
        lblDocumentTables = new Label();
        txtDocumentTables = new TextBox();
        lblCommandTimeout = new Label();
        txtCommandTimeout = new TextBox();
        chkTransaction = new CheckBox();
        btnPreview = new Button();
        btnRun = new Button();
        btnCancel = new Button();
        lblBranch = new Label();
        cboBranch = new ComboBox();
        btnLoadBranches = new Button();
        btnRunResults = new Button();
        txtLog = new TextBox();
        gridDuplicateData = new DataGridView();
        gridMissingDocuments = new DataGridView();
        layout = new TableLayoutPanel();
        inputLayout = new TableLayoutPanel();
        scriptsFolderLayout = new TableLayoutPanel();
        bottomPanel = new FlowLayoutPanel();
        tabs = new TabControl();
        tabLog = new TabPage();
        tabDuplicateData = new TabPage();
        tabMissingDocuments = new TabPage();
        ((System.ComponentModel.ISupportInitialize)gridDuplicateData).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridMissingDocuments).BeginInit();
        layout.SuspendLayout();
        inputLayout.SuspendLayout();
        scriptsFolderLayout.SuspendLayout();
        bottomPanel.SuspendLayout();
        tabs.SuspendLayout();
        tabLog.SuspendLayout();
        tabDuplicateData.SuspendLayout();
        tabMissingDocuments.SuspendLayout();
        SuspendLayout();
        // 
        // lblConnectionString
        // 
        lblConnectionString.AutoSize = true;
        lblConnectionString.Dock = DockStyle.Fill;
        lblConnectionString.Location = new Point(3, 0);
        lblConnectionString.Name = "lblConnectionString";
        lblConnectionString.Size = new Size(142, 34);
        lblConnectionString.TabIndex = 0;
        lblConnectionString.Text = "Connection string";
        lblConnectionString.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtConnectionString
        // 
        txtConnectionString.Dock = DockStyle.Fill;
        txtConnectionString.Location = new Point(151, 3);
        txtConnectionString.Name = "txtConnectionString";
        txtConnectionString.PlaceholderText = "Server=.;Database=Enadoc12688B9B38A4000;Trusted_Connection=True;TrustServerCertificate=True;";
        txtConnectionString.Size = new Size(1012, 27);
        txtConnectionString.TabIndex = 1;
        // 
        // lblScriptsFolder
        // 
        lblScriptsFolder.AutoSize = true;
        lblScriptsFolder.Dock = DockStyle.Fill;
        lblScriptsFolder.Location = new Point(3, 34);
        lblScriptsFolder.Name = "lblScriptsFolder";
        lblScriptsFolder.Size = new Size(142, 35);
        lblScriptsFolder.TabIndex = 2;
        lblScriptsFolder.Text = "Scripts folder";
        lblScriptsFolder.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtScriptsFolder
        // 
        txtScriptsFolder.Dock = DockStyle.Fill;
        txtScriptsFolder.Location = new Point(3, 3);
        txtScriptsFolder.Name = "txtScriptsFolder";
        txtScriptsFolder.Size = new Size(925, 27);
        txtScriptsFolder.TabIndex = 3;
        // 
        // btnBrowseScripts
        // 
        btnBrowseScripts.Dock = DockStyle.Fill;
        btnBrowseScripts.Location = new Point(934, 3);
        btnBrowseScripts.Name = "btnBrowseScripts";
        btnBrowseScripts.Size = new Size(75, 29);
        btnBrowseScripts.TabIndex = 4;
        btnBrowseScripts.Text = "Browse";
        btnBrowseScripts.UseVisualStyleBackColor = true;
        btnBrowseScripts.Click += btnBrowseScripts_Click;
        // 
        // lblSourceTables
        // 
        lblSourceTables.AutoSize = true;
        lblSourceTables.Dock = DockStyle.Fill;
        lblSourceTables.Location = new Point(3, 69);
        lblSourceTables.Name = "lblSourceTables";
        lblSourceTables.Size = new Size(142, 150);
        lblSourceTables.TabIndex = 5;
        lblSourceTables.Text = "Source DB tables";
        lblSourceTables.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtSourceTables
        // 
        txtSourceTables.AcceptsReturn = true;
        txtSourceTables.AcceptsTab = true;
        txtSourceTables.Dock = DockStyle.Fill;
        txtSourceTables.Font = new Font("Consolas", 9F);
        txtSourceTables.Location = new Point(151, 72);
        txtSourceTables.Multiline = true;
        txtSourceTables.Name = "txtSourceTables";
        txtSourceTables.ScrollBars = ScrollBars.Vertical;
        txtSourceTables.Size = new Size(1012, 144);
        txtSourceTables.TabIndex = 6;
        // 
        // lblDocumentTables
        // 
        lblDocumentTables.AutoSize = true;
        lblDocumentTables.Dock = DockStyle.Fill;
        lblDocumentTables.Location = new Point(3, 219);
        lblDocumentTables.Name = "lblDocumentTables";
        lblDocumentTables.Size = new Size(142, 150);
        lblDocumentTables.TabIndex = 7;
        lblDocumentTables.Text = "Document tables";
        lblDocumentTables.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtDocumentTables
        // 
        txtDocumentTables.AcceptsReturn = true;
        txtDocumentTables.AcceptsTab = true;
        txtDocumentTables.Dock = DockStyle.Fill;
        txtDocumentTables.Font = new Font("Consolas", 9F);
        txtDocumentTables.Location = new Point(151, 222);
        txtDocumentTables.Multiline = true;
        txtDocumentTables.Name = "txtDocumentTables";
        txtDocumentTables.ScrollBars = ScrollBars.Vertical;
        txtDocumentTables.Size = new Size(1012, 144);
        txtDocumentTables.TabIndex = 8;
        // 
        // lblCommandTimeout
        // 
        lblCommandTimeout.AutoSize = true;
        lblCommandTimeout.Dock = DockStyle.Fill;
        lblCommandTimeout.Location = new Point(3, 369);
        lblCommandTimeout.Name = "lblCommandTimeout";
        lblCommandTimeout.Size = new Size(142, 76);
        lblCommandTimeout.TabIndex = 9;
        lblCommandTimeout.Text = "Actions";
        lblCommandTimeout.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtCommandTimeout
        // 
        txtCommandTimeout.Location = new Point(3, 3);
        txtCommandTimeout.Name = "txtCommandTimeout";
        txtCommandTimeout.Size = new Size(80, 27);
        txtCommandTimeout.TabIndex = 10;
        // 
        // chkTransaction
        // 
        chkTransaction.AutoSize = true;
        chkTransaction.Checked = true;
        chkTransaction.CheckState = CheckState.Checked;
        chkTransaction.Location = new Point(89, 3);
        chkTransaction.Name = "chkTransaction";
        chkTransaction.Size = new Size(161, 24);
        chkTransaction.TabIndex = 11;
        chkTransaction.Text = "Use one transaction";
        chkTransaction.UseVisualStyleBackColor = true;
        // 
        // btnPreview
        // 
        btnPreview.Location = new Point(256, 3);
        btnPreview.Name = "btnPreview";
        btnPreview.Size = new Size(125, 30);
        btnPreview.TabIndex = 12;
        btnPreview.Text = "Preview SQL";
        btnPreview.UseVisualStyleBackColor = true;
        btnPreview.Click += btnPreview_Click;
        // 
        // btnRun
        // 
        btnRun.Location = new Point(387, 3);
        btnRun.Name = "btnRun";
        btnRun.Size = new Size(110, 30);
        btnRun.TabIndex = 13;
        btnRun.Text = "Run Scripts";
        btnRun.UseVisualStyleBackColor = true;
        btnRun.Click += btnRun_Click;
        // 
        // btnCancel
        // 
        btnCancel.Enabled = false;
        btnCancel.Location = new Point(964, 3);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(85, 30);
        btnCancel.TabIndex = 14;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // lblBranch
        // 
        lblBranch.AutoSize = true;
        lblBranch.Location = new Point(503, 7);
        lblBranch.Margin = new Padding(3, 7, 3, 0);
        lblBranch.Name = "lblBranch";
        lblBranch.Size = new Size(54, 20);
        lblBranch.TabIndex = 15;
        lblBranch.Text = "Branch";
        // 
        // cboBranch
        // 
        cboBranch.DropDownStyle = ComboBoxStyle.DropDownList;
        cboBranch.FormattingEnabled = true;
        cboBranch.Location = new Point(563, 3);
        cboBranch.Name = "cboBranch";
        cboBranch.Size = new Size(205, 28);
        cboBranch.TabIndex = 16;
        // 
        // btnLoadBranches
        // 
        btnLoadBranches.Location = new Point(774, 3);
        btnLoadBranches.Name = "btnLoadBranches";
        btnLoadBranches.Size = new Size(88, 30);
        btnLoadBranches.TabIndex = 17;
        btnLoadBranches.Text = "Load";
        btnLoadBranches.UseVisualStyleBackColor = true;
        btnLoadBranches.Click += btnLoadBranches_Click;
        // 
        // btnRunResults
        // 
        btnRunResults.Location = new Point(868, 3);
        btnRunResults.Name = "btnRunResults";
        btnRunResults.Size = new Size(90, 30);
        btnRunResults.TabIndex = 18;
        btnRunResults.Text = "Results";
        btnRunResults.UseVisualStyleBackColor = true;
        btnRunResults.Click += btnRunResults_Click;
        // 
        // txtLog
        // 
        txtLog.Dock = DockStyle.Fill;
        txtLog.Font = new Font("Consolas", 9F);
        txtLog.Location = new Point(3, 3);
        txtLog.Multiline = true;
        txtLog.Name = "txtLog";
        txtLog.ReadOnly = true;
        txtLog.ScrollBars = ScrollBars.Both;
        txtLog.Size = new Size(1152, 236);
        txtLog.TabIndex = 19;
        txtLog.WordWrap = false;
        // 
        // gridDuplicateData
        // 
        gridDuplicateData.AllowUserToAddRows = false;
        gridDuplicateData.AllowUserToDeleteRows = false;
        gridDuplicateData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        gridDuplicateData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridDuplicateData.Dock = DockStyle.Fill;
        gridDuplicateData.Location = new Point(3, 3);
        gridDuplicateData.Name = "gridDuplicateData";
        gridDuplicateData.ReadOnly = true;
        gridDuplicateData.RowHeadersWidth = 51;
        gridDuplicateData.Size = new Size(1152, 236);
        gridDuplicateData.TabIndex = 20;
        // 
        // gridMissingDocuments
        // 
        gridMissingDocuments.AllowUserToAddRows = false;
        gridMissingDocuments.AllowUserToDeleteRows = false;
        gridMissingDocuments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        gridMissingDocuments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridMissingDocuments.Dock = DockStyle.Fill;
        gridMissingDocuments.Location = new Point(3, 3);
        gridMissingDocuments.Name = "gridMissingDocuments";
        gridMissingDocuments.ReadOnly = true;
        gridMissingDocuments.RowHeadersWidth = 51;
        gridMissingDocuments.Size = new Size(1152, 236);
        gridMissingDocuments.TabIndex = 21;
        // 
        // layout
        // 
        layout.ColumnCount = 1;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Controls.Add(inputLayout, 0, 0);
        layout.Controls.Add(tabs, 0, 1);
        layout.Dock = DockStyle.Fill;
        layout.Location = new Point(0, 0);
        layout.Name = "layout";
        layout.Padding = new Padding(15);
        layout.RowCount = 2;
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 455F));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layout.Size = new Size(1202, 753);
        layout.TabIndex = 22;
        // 
        // inputLayout
        // 
        inputLayout.ColumnCount = 2;
        inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 148F));
        inputLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        inputLayout.Controls.Add(lblConnectionString, 0, 0);
        inputLayout.Controls.Add(txtConnectionString, 1, 0);
        inputLayout.Controls.Add(lblScriptsFolder, 0, 1);
        inputLayout.Controls.Add(scriptsFolderLayout, 1, 1);
        inputLayout.Controls.Add(lblSourceTables, 0, 2);
        inputLayout.Controls.Add(txtSourceTables, 1, 2);
        inputLayout.Controls.Add(lblDocumentTables, 0, 3);
        inputLayout.Controls.Add(txtDocumentTables, 1, 3);
        inputLayout.Controls.Add(lblCommandTimeout, 0, 4);
        inputLayout.Controls.Add(bottomPanel, 1, 4);
        inputLayout.Dock = DockStyle.Fill;
        inputLayout.Location = new Point(18, 18);
        inputLayout.Name = "inputLayout";
        inputLayout.RowCount = 5;
        inputLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        inputLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        inputLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
        inputLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
        inputLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 76F));
        inputLayout.Size = new Size(1166, 449);
        inputLayout.TabIndex = 0;
        // 
        // scriptsFolderLayout
        // 
        scriptsFolderLayout.ColumnCount = 2;
        scriptsFolderLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        scriptsFolderLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 81F));
        scriptsFolderLayout.Controls.Add(txtScriptsFolder, 0, 0);
        scriptsFolderLayout.Controls.Add(btnBrowseScripts, 1, 0);
        scriptsFolderLayout.Dock = DockStyle.Fill;
        scriptsFolderLayout.Location = new Point(151, 37);
        scriptsFolderLayout.Name = "scriptsFolderLayout";
        scriptsFolderLayout.RowCount = 1;
        scriptsFolderLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        scriptsFolderLayout.Size = new Size(1012, 29);
        scriptsFolderLayout.TabIndex = 23;
        // 
        // bottomPanel
        // 
        bottomPanel.Controls.Add(txtCommandTimeout);
        bottomPanel.Controls.Add(chkTransaction);
        bottomPanel.Controls.Add(btnPreview);
        bottomPanel.Controls.Add(btnRun);
        bottomPanel.Controls.Add(lblBranch);
        bottomPanel.Controls.Add(cboBranch);
        bottomPanel.Controls.Add(btnLoadBranches);
        bottomPanel.Controls.Add(btnRunResults);
        bottomPanel.Controls.Add(btnCancel);
        bottomPanel.Dock = DockStyle.Fill;
        bottomPanel.Location = new Point(151, 372);
        bottomPanel.Name = "bottomPanel";
        bottomPanel.Size = new Size(1012, 70);
        bottomPanel.TabIndex = 24;
        // 
        // tabs
        // 
        tabs.Controls.Add(tabLog);
        tabs.Controls.Add(tabDuplicateData);
        tabs.Controls.Add(tabMissingDocuments);
        tabs.Dock = DockStyle.Fill;
        tabs.Location = new Point(18, 473);
        tabs.Name = "tabs";
        tabs.SelectedIndex = 0;
        tabs.Size = new Size(1166, 262);
        tabs.TabIndex = 25;
        // 
        // tabLog
        // 
        tabLog.Controls.Add(txtLog);
        tabLog.Location = new Point(4, 29);
        tabLog.Name = "tabLog";
        tabLog.Padding = new Padding(3);
        tabLog.Size = new Size(1158, 229);
        tabLog.TabIndex = 0;
        tabLog.Text = "Log";
        tabLog.UseVisualStyleBackColor = true;
        // 
        // tabDuplicateData
        // 
        tabDuplicateData.Controls.Add(gridDuplicateData);
        tabDuplicateData.Location = new Point(4, 29);
        tabDuplicateData.Name = "tabDuplicateData";
        tabDuplicateData.Padding = new Padding(3);
        tabDuplicateData.Size = new Size(1158, 229);
        tabDuplicateData.TabIndex = 1;
        tabDuplicateData.Text = "Duplicated Data";
        tabDuplicateData.UseVisualStyleBackColor = true;
        // 
        // tabMissingDocuments
        // 
        tabMissingDocuments.Controls.Add(gridMissingDocuments);
        tabMissingDocuments.Location = new Point(4, 29);
        tabMissingDocuments.Name = "tabMissingDocuments";
        tabMissingDocuments.Padding = new Padding(3);
        tabMissingDocuments.Size = new Size(1158, 229);
        tabMissingDocuments.TabIndex = 2;
        tabMissingDocuments.Text = "Missing Documents";
        tabMissingDocuments.UseVisualStyleBackColor = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1202, 753);
        Controls.Add(layout);
        MinimumSize = new Size(1120, 720);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "DB Script Runner";
        ((System.ComponentModel.ISupportInitialize)gridDuplicateData).EndInit();
        ((System.ComponentModel.ISupportInitialize)gridMissingDocuments).EndInit();
        layout.ResumeLayout(false);
        inputLayout.ResumeLayout(false);
        inputLayout.PerformLayout();
        scriptsFolderLayout.ResumeLayout(false);
        scriptsFolderLayout.PerformLayout();
        bottomPanel.ResumeLayout(false);
        bottomPanel.PerformLayout();
        tabs.ResumeLayout(false);
        tabLog.ResumeLayout(false);
        tabLog.PerformLayout();
        tabDuplicateData.ResumeLayout(false);
        tabMissingDocuments.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Label lblConnectionString;
    private TextBox txtConnectionString;
    private Label lblScriptsFolder;
    private TextBox txtScriptsFolder;
    private Button btnBrowseScripts;
    private Label lblSourceTables;
    private TextBox txtSourceTables;
    private Label lblDocumentTables;
    private TextBox txtDocumentTables;
    private Label lblCommandTimeout;
    private TextBox txtCommandTimeout;
    private CheckBox chkTransaction;
    private Button btnPreview;
    private Button btnRun;
    private Button btnCancel;
    private Label lblBranch;
    private ComboBox cboBranch;
    private Button btnLoadBranches;
    private Button btnRunResults;
    private TextBox txtLog;
    private DataGridView gridDuplicateData;
    private DataGridView gridMissingDocuments;
    private TableLayoutPanel layout;
    private TableLayoutPanel inputLayout;
    private TableLayoutPanel scriptsFolderLayout;
    private FlowLayoutPanel bottomPanel;
    private TabControl tabs;
    private TabPage tabLog;
    private TabPage tabDuplicateData;
    private TabPage tabMissingDocuments;
}
