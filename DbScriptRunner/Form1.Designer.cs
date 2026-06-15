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
        txtLog = new TextBox();
        layout = new TableLayoutPanel();
        inputLayout = new TableLayoutPanel();
        scriptsFolderLayout = new TableLayoutPanel();
        bottomPanel = new FlowLayoutPanel();
        layout.SuspendLayout();
        inputLayout.SuspendLayout();
        scriptsFolderLayout.SuspendLayout();
        bottomPanel.SuspendLayout();
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
        txtConnectionString.Size = new Size(812, 27);
        txtConnectionString.TabIndex = 1;
        txtConnectionString.Text = "Server=4.194.128.51,1433;Database=Enadoc12688B9B38A4000;User ID=sa;Password=Alctraz56#$2\r\n;TrustServerCertificate=True;";
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
        txtScriptsFolder.Size = new Size(725, 27);
        txtScriptsFolder.TabIndex = 3;
        // 
        // btnBrowseScripts
        // 
        btnBrowseScripts.Dock = DockStyle.Fill;
        btnBrowseScripts.Location = new Point(734, 3);
        btnBrowseScripts.Name = "btnBrowseScripts";
        btnBrowseScripts.Size = new Size(75, 23);
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
        lblSourceTables.Size = new Size(142, 170);
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
        txtSourceTables.Size = new Size(812, 164);
        txtSourceTables.TabIndex = 6;
        // 
        // lblDocumentTables
        // 
        lblDocumentTables.AutoSize = true;
        lblDocumentTables.Dock = DockStyle.Fill;
        lblDocumentTables.Location = new Point(3, 239);
        lblDocumentTables.Name = "lblDocumentTables";
        lblDocumentTables.Size = new Size(142, 170);
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
        txtDocumentTables.Location = new Point(151, 242);
        txtDocumentTables.Multiline = true;
        txtDocumentTables.Name = "txtDocumentTables";
        txtDocumentTables.ScrollBars = ScrollBars.Vertical;
        txtDocumentTables.Size = new Size(812, 164);
        txtDocumentTables.TabIndex = 8;
        // 
        // lblCommandTimeout
        // 
        lblCommandTimeout.AutoSize = true;
        lblCommandTimeout.Dock = DockStyle.Fill;
        lblCommandTimeout.Location = new Point(3, 409);
        lblCommandTimeout.Name = "lblCommandTimeout";
        lblCommandTimeout.Size = new Size(142, 55);
        lblCommandTimeout.TabIndex = 9;
        lblCommandTimeout.Text = "Timeout seconds";
        lblCommandTimeout.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtCommandTimeout
        // 
        txtCommandTimeout.Location = new Point(3, 3);
        txtCommandTimeout.Name = "txtCommandTimeout";
        txtCommandTimeout.Size = new Size(90, 27);
        txtCommandTimeout.TabIndex = 10;
        // 
        // chkTransaction
        // 
        chkTransaction.AutoSize = true;
        chkTransaction.Checked = true;
        chkTransaction.CheckState = CheckState.Checked;
        chkTransaction.Location = new Point(99, 3);
        chkTransaction.Name = "chkTransaction";
        chkTransaction.Size = new Size(161, 24);
        chkTransaction.TabIndex = 11;
        chkTransaction.Text = "Use one transaction";
        chkTransaction.UseVisualStyleBackColor = true;
        // 
        // btnPreview
        // 
        btnPreview.Location = new Point(266, 3);
        btnPreview.Name = "btnPreview";
        btnPreview.Size = new Size(150, 30);
        btnPreview.TabIndex = 12;
        btnPreview.Text = "Preview SQL";
        btnPreview.UseVisualStyleBackColor = true;
        btnPreview.Click += btnPreview_Click;
        // 
        // btnRun
        // 
        btnRun.Location = new Point(422, 3);
        btnRun.Name = "btnRun";
        btnRun.Size = new Size(110, 30);
        btnRun.TabIndex = 13;
        btnRun.Text = "Run";
        btnRun.UseVisualStyleBackColor = true;
        btnRun.Click += btnRun_Click;
        // 
        // btnCancel
        // 
        btnCancel.Enabled = false;
        btnCancel.Location = new Point(538, 3);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(94, 30);
        btnCancel.TabIndex = 14;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // txtLog
        // 
        txtLog.Dock = DockStyle.Fill;
        txtLog.Font = new Font("Consolas", 9F);
        txtLog.Location = new Point(18, 488);
        txtLog.Multiline = true;
        txtLog.Name = "txtLog";
        txtLog.ReadOnly = true;
        txtLog.ScrollBars = ScrollBars.Both;
        txtLog.Size = new Size(966, 247);
        txtLog.TabIndex = 15;
        txtLog.WordWrap = false;
        // 
        // layout
        // 
        layout.ColumnCount = 1;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Controls.Add(inputLayout, 0, 0);
        layout.Controls.Add(txtLog, 0, 1);
        layout.Dock = DockStyle.Fill;
        layout.Location = new Point(0, 0);
        layout.Name = "layout";
        layout.Padding = new Padding(15);
        layout.RowCount = 2;
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 470F));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layout.Size = new Size(1002, 753);
        layout.TabIndex = 16;
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
        inputLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 170F));
        inputLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 170F));
        inputLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        inputLayout.Size = new Size(966, 464);
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
        scriptsFolderLayout.Size = new Size(812, 29);
        scriptsFolderLayout.TabIndex = 16;
        // 
        // bottomPanel
        // 
        bottomPanel.Controls.Add(txtCommandTimeout);
        bottomPanel.Controls.Add(chkTransaction);
        bottomPanel.Controls.Add(btnPreview);
        bottomPanel.Controls.Add(btnRun);
        bottomPanel.Controls.Add(btnCancel);
        bottomPanel.Dock = DockStyle.Fill;
        bottomPanel.Location = new Point(151, 412);
        bottomPanel.Name = "bottomPanel";
        bottomPanel.Size = new Size(812, 49);
        bottomPanel.TabIndex = 17;
        bottomPanel.WrapContents = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1002, 753);
        Controls.Add(layout);
        MinimumSize = new Size(920, 700);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "DB Script Runner";
        layout.ResumeLayout(false);
        layout.PerformLayout();
        inputLayout.ResumeLayout(false);
        inputLayout.PerformLayout();
        scriptsFolderLayout.ResumeLayout(false);
        scriptsFolderLayout.PerformLayout();
        bottomPanel.ResumeLayout(false);
        bottomPanel.PerformLayout();
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
    private TextBox txtLog;
    private TableLayoutPanel layout;
    private TableLayoutPanel inputLayout;
    private TableLayoutPanel scriptsFolderLayout;
    private FlowLayoutPanel bottomPanel;
}
