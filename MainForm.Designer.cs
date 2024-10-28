namespace ObjectCounterApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Button btnCountObjects;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.TextBox txtActivity;
        private System.Windows.Forms.DateTimePicker dtpTime;

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
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.btnCountObjects = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();

            // txtFolderPath
            this.txtFolderPath.Location = new System.Drawing.Point(12, 12);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(300, 20);
            this.txtFolderPath.TabIndex = 0;

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 40);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(80, 13);
            this.lblStatus.TabIndex = 1;

            // txtResults
            this.txtResults.Location = new System.Drawing.Point(12, 60);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.Size = new System.Drawing.Size(400, 300);
            this.txtResults.TabIndex = 2;
            this.txtResults.ReadOnly = true;
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // btnSelectFolder
            this.btnSelectFolder.Location = new System.Drawing.Point(320, 10);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(90, 23);
            this.btnSelectFolder.TabIndex = 3;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);

            // btnCountObjects
            this.btnCountObjects.Location = new System.Drawing.Point(320, 40);
            this.btnCountObjects.Name = "btnCountObjects";
            this.btnCountObjects.Size = new System.Drawing.Size(90, 23);
            this.btnCountObjects.TabIndex = 4;
            this.btnCountObjects.Text = "Count Objects";
            this.btnCountObjects.UseVisualStyleBackColor = true;
            this.btnCountObjects.Click += new System.EventHandler(this.btnCountObjects_Click);

            // logoPictureBox
            this.logoPictureBox.Location = new System.Drawing.Point(150, 400);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(120, 60);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 5;
            this.logoPictureBox.TabStop = false;
            this.logoPictureBox.Image = System.Drawing.Image.FromFile("logo.jpeg"); // Ganti dengan path logo Anda

            // MainForm
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.btnCountObjects);
            this.Controls.Add(this.logoPictureBox);
            this.Name = "MainForm";
            this.Text = "Object Counter App";
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            // Di dalam InitializeComponent() tambahkan kode ini

            // txtActivity
            this.txtActivity = new System.Windows.Forms.TextBox();
            this.txtActivity.Location = new System.Drawing.Point(12, 370);
            this.txtActivity.Name = "txtActivity";
            this.txtActivity.Size = new System.Drawing.Size(200, 20);
            this.txtActivity.TabIndex = 6;
            this.txtActivity.PlaceholderText = "Masukkan aktivitas";

            // dtpTime
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(220, 370);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(80, 20);
            this.dtpTime.TabIndex = 7;

            // btnGenerateReport
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnGenerateReport.Location = new System.Drawing.Point(320, 370);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(90, 23);
            this.btnGenerateReport.TabIndex = 8;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);

            // Tambahkan elemen-elemen ini ke Controls
            this.Controls.Add(this.txtActivity);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.btnGenerateReport);
        }

        #endregion
    }
}
