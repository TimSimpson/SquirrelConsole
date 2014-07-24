namespace DebugConsole
{
    partial class DebugConsole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugConsole));
            this.lblStatus = new System.Windows.Forms.Label();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.tabControlWatch = new System.Windows.Forms.TabControl();
            this.tpConsole = new System.Windows.Forms.TabPage();
            this.cbClearOnStart = new System.Windows.Forms.CheckBox();
            this.tpWatch = new System.Windows.Forms.TabPage();
            this.dgvWatch = new System.Windows.Forms.DataGridView();
            this.tpMemory = new System.Windows.Forms.TabPage();
            this.dgvMemory = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlActions = new System.Windows.Forms.TabControl();
            this.tpScripts = new System.Windows.Forms.TabPage();
            this.tabControlWatch.SuspendLayout();
            this.tpConsole.SuspendLayout();
            this.tpWatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWatch)).BeginInit();
            this.tpMemory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemory)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlActions.SuspendLayout();
            this.SuspendLayout();
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(4, 7);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(49, 20);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Hello!";
            //
            // rtbOutput
            //
            this.rtbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbOutput.Location = new System.Drawing.Point(2, 5);
            this.rtbOutput.Margin = new System.Windows.Forms.Padding(2);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(534, 211);
            this.rtbOutput.TabIndex = 2;
            this.rtbOutput.Text = "";
            //
            // tabControlWatch
            //
            this.tabControlWatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlWatch.Controls.Add(this.tpConsole);
            this.tabControlWatch.Controls.Add(this.tpWatch);
            this.tabControlWatch.Controls.Add(this.tpMemory);
            this.tabControlWatch.Location = new System.Drawing.Point(2, 2);
            this.tabControlWatch.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlWatch.Name = "tabControlWatch";
            this.tabControlWatch.SelectedIndex = 0;
            this.tabControlWatch.Size = new System.Drawing.Size(543, 266);
            this.tabControlWatch.TabIndex = 5;
            //
            // tpConsole
            //
            this.tpConsole.Controls.Add(this.cbClearOnStart);
            this.tpConsole.Controls.Add(this.rtbOutput);
            this.tpConsole.Location = new System.Drawing.Point(4, 22);
            this.tpConsole.Margin = new System.Windows.Forms.Padding(2);
            this.tpConsole.Name = "tpConsole";
            this.tpConsole.Padding = new System.Windows.Forms.Padding(2);
            this.tpConsole.Size = new System.Drawing.Size(535, 240);
            this.tpConsole.TabIndex = 0;
            this.tpConsole.Text = "Log";
            this.tpConsole.UseVisualStyleBackColor = true;
            //
            // cbClearOnStart
            //
            this.cbClearOnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbClearOnStart.AutoSize = true;
            this.cbClearOnStart.Checked = true;
            this.cbClearOnStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbClearOnStart.Location = new System.Drawing.Point(5, 220);
            this.cbClearOnStart.Margin = new System.Windows.Forms.Padding(2);
            this.cbClearOnStart.Name = "cbClearOnStart";
            this.cbClearOnStart.Size = new System.Drawing.Size(129, 17);
            this.cbClearOnStart.TabIndex = 3;
            this.cbClearOnStart.Text = "Clear on program start";
            this.cbClearOnStart.UseVisualStyleBackColor = true;
            //
            // tpWatch
            //
            this.tpWatch.Controls.Add(this.dgvWatch);
            this.tpWatch.Location = new System.Drawing.Point(4, 22);
            this.tpWatch.Margin = new System.Windows.Forms.Padding(2);
            this.tpWatch.Name = "tpWatch";
            this.tpWatch.Padding = new System.Windows.Forms.Padding(2);
            this.tpWatch.Size = new System.Drawing.Size(535, 240);
            this.tpWatch.TabIndex = 1;
            this.tpWatch.Text = "Watch";
            this.tpWatch.UseVisualStyleBackColor = true;
            //
            // dgvWatch
            //
            this.dgvWatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWatch.Location = new System.Drawing.Point(2, 2);
            this.dgvWatch.Margin = new System.Windows.Forms.Padding(2);
            this.dgvWatch.Name = "dgvWatch";
            this.dgvWatch.RowTemplate.Height = 24;
            this.dgvWatch.Size = new System.Drawing.Size(531, 236);
            this.dgvWatch.TabIndex = 0;
            //
            // tpMemory
            //
            this.tpMemory.Controls.Add(this.dgvMemory);
            this.tpMemory.Location = new System.Drawing.Point(4, 22);
            this.tpMemory.Margin = new System.Windows.Forms.Padding(2);
            this.tpMemory.Name = "tpMemory";
            this.tpMemory.Size = new System.Drawing.Size(535, 240);
            this.tpMemory.TabIndex = 2;
            this.tpMemory.Text = "Memory";
            this.tpMemory.UseVisualStyleBackColor = true;
            //
            // dgvMemory
            //
            this.dgvMemory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMemory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMemory.Location = new System.Drawing.Point(0, 0);
            this.dgvMemory.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMemory.Name = "dgvMemory";
            this.dgvMemory.RowTemplate.Height = 24;
            this.dgvMemory.Size = new System.Drawing.Size(535, 240);
            this.dgvMemory.TabIndex = 1;
            //
            // timer1
            //
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            //
            // splitContainer1
            //
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(-4, 30);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            // splitContainer1.Panel1
            //
            this.splitContainer1.Panel1.Controls.Add(this.tabControlActions);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            //
            // splitContainer1.Panel2
            //
            this.splitContainer1.Panel2.Controls.Add(this.tabControlWatch);
            this.splitContainer1.Size = new System.Drawing.Size(552, 433);
            this.splitContainer1.SplitterDistance = 159;
            this.splitContainer1.TabIndex = 6;
            //
            // tabControlActions
            //
            this.tabControlActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlActions.Controls.Add(this.tpScripts);
            this.tabControlActions.Location = new System.Drawing.Point(2, 3);
            this.tabControlActions.Name = "tabControlActions";
            this.tabControlActions.SelectedIndex = 0;
            this.tabControlActions.Size = new System.Drawing.Size(547, 153);
            this.tabControlActions.TabIndex = 0;
            //
            // tpScripts
            //
            this.tpScripts.Location = new System.Drawing.Point(4, 22);
            this.tpScripts.Name = "tpScripts";
            this.tpScripts.Padding = new System.Windows.Forms.Padding(3);
            this.tpScripts.Size = new System.Drawing.Size(539, 127);
            this.tpScripts.TabIndex = 0;
            this.tpScripts.Text = "Scripts";
            this.tpScripts.UseVisualStyleBackColor = true;
            //
            // DebugConsole
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 456);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblStatus);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DebugConsole";
            this.Text = "Squirrel Console";
            this.tabControlWatch.ResumeLayout(false);
            this.tpConsole.ResumeLayout(false);
            this.tpConsole.PerformLayout();
            this.tpWatch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWatch)).EndInit();
            this.tpMemory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemory)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControlActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.TabControl tabControlWatch;
        private System.Windows.Forms.TabPage tpConsole;
        private System.Windows.Forms.TabPage tpWatch;
        private System.Windows.Forms.DataGridView dgvWatch;
        private System.Windows.Forms.TabPage tpMemory;
        private System.Windows.Forms.DataGridView dgvMemory;
        private System.Windows.Forms.CheckBox cbClearOnStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControlActions;
        private System.Windows.Forms.TabPage tpScripts;
    }
}

