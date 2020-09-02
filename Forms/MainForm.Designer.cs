namespace BatchMp4Converter.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlPrimary = new System.Windows.Forms.Panel();
            this.dgvJobs = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmsJobs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDeleteJob = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteAllJobs = new System.Windows.Forms.ToolStripMenuItem();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.btnAbout = new System.Windows.Forms.Button();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiOpenFileLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlPrimary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).BeginInit();
            this.cmsJobs.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrimary
            // 
            this.pnlPrimary.Controls.Add(this.dgvJobs);
            this.pnlPrimary.Location = new System.Drawing.Point(12, 12);
            this.pnlPrimary.Name = "pnlPrimary";
            this.pnlPrimary.Size = new System.Drawing.Size(939, 381);
            this.pnlPrimary.TabIndex = 0;
            // 
            // dgvJobs
            // 
            this.dgvJobs.AllowUserToAddRows = false;
            this.dgvJobs.AllowUserToDeleteRows = false;
            this.dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJobs.Location = new System.Drawing.Point(0, 0);
            this.dgvJobs.Name = "dgvJobs";
            this.dgvJobs.ReadOnly = true;
            this.dgvJobs.Size = new System.Drawing.Size(939, 381);
            this.dgvJobs.TabIndex = 0;
            this.dgvJobs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridViewMouseClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(517, 399);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 28);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "button1";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(627, 399);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(104, 28);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "button3";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(847, 399);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 28);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "button4";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmsJobs
            // 
            this.cmsJobs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDeleteJob,
            this.tsmiDeleteAllJobs,
            this.toolStripMenuItem1,
            this.tsmiOpenFileLocation});
            this.cmsJobs.Name = "cmsJobs";
            this.cmsJobs.Size = new System.Drawing.Size(181, 98);
            // 
            // tsmiDeleteJob
            // 
            this.tsmiDeleteJob.Name = "tsmiDeleteJob";
            this.tsmiDeleteJob.Size = new System.Drawing.Size(180, 22);
            this.tsmiDeleteJob.Text = "Delete Job";
            this.tsmiDeleteJob.Click += new System.EventHandler(this.ToolStripMenuItemClick);
            // 
            // tsmiDeleteAllJobs
            // 
            this.tsmiDeleteAllJobs.Name = "tsmiDeleteAllJobs";
            this.tsmiDeleteAllJobs.Size = new System.Drawing.Size(180, 22);
            this.tsmiDeleteAllJobs.Text = "Delete All Jobs";
            this.tsmiDeleteAllJobs.Click += new System.EventHandler(this.ToolStripMenuItemClick);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Tick += new System.EventHandler(this.TimerRefreshTick);
            // 
            // btnAbout
            // 
            this.btnAbout.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.Location = new System.Drawing.Point(737, 399);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(104, 28);
            this.btnAbout.TabIndex = 5;
            this.btnAbout.Text = "button4";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.ButtonClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmiOpenFileLocation
            // 
            this.tsmiOpenFileLocation.Name = "tsmiOpenFileLocation";
            this.tsmiOpenFileLocation.Size = new System.Drawing.Size(180, 22);
            this.tsmiOpenFileLocation.Text = "Open File Location";
            this.tsmiOpenFileLocation.Click += new System.EventHandler(this.ToolStripMenuItemClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 436);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pnlPrimary);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "ain";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.pnlPrimary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).EndInit();
            this.cmsJobs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlPrimary;
        internal System.Windows.Forms.DataGridView dgvJobs;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ContextMenuStrip cmsJobs;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteJob;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteAllJobs;
        internal System.Windows.Forms.Timer timerRefresh;
        internal System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFileLocation;
    }
}

