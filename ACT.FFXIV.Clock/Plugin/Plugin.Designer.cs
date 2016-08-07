namespace ACT.FFXIV.Clock
{
    partial class Plugin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageClock = new System.Windows.Forms.TabPage();
            this.dataGridClock = new System.Windows.Forms.DataGridView();
            this.clockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.chkMouseMove = new System.Windows.Forms.CheckBox();
            this.chkAutoHideOverlay = new System.Windows.Forms.CheckBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.txtAlertSound = new System.Windows.Forms.TextBox();
            this.labelAlertSound = new System.Windows.Forms.Label();
            this.numAlertBefore = new System.Windows.Forms.NumericUpDown();
            this.labelAlertBefore = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.buttonNodeList = new System.Windows.Forms.Button();
            this.enabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aetheryteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coordinateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eorzeaHourDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eorzeaMinuteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eorzeaDurationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeDiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl.SuspendLayout();
            this.tabPageClock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clockBindingSource)).BeginInit();
            this.tabPageSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAlertBefore)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageClock);
            this.tabControl.Controls.Add(this.tabPageSettings);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(892, 666);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageClock
            // 
            this.tabPageClock.Controls.Add(this.dataGridClock);
            this.tabPageClock.Location = new System.Drawing.Point(4, 22);
            this.tabPageClock.Name = "tabPageClock";
            this.tabPageClock.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClock.Size = new System.Drawing.Size(884, 640);
            this.tabPageClock.TabIndex = 0;
            this.tabPageClock.Text = "Clock";
            this.tabPageClock.UseVisualStyleBackColor = true;
            // 
            // dataGridClock
            // 
            this.dataGridClock.AutoGenerateColumns = false;
            this.dataGridClock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridClock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.enabledDataGridViewCheckBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.regionDataGridViewTextBoxColumn,
            this.aetheryteDataGridViewTextBoxColumn,
            this.coordinateDataGridViewTextBoxColumn,
            this.jobDataGridViewTextBoxColumn,
            this.eorzeaHourDataGridViewTextBoxColumn,
            this.eorzeaMinuteDataGridViewTextBoxColumn,
            this.eorzeaDurationDataGridViewTextBoxColumn,
            this.slotDataGridViewTextBoxColumn,
            this.TimeDiff,
            this.Status});
            this.dataGridClock.DataSource = this.clockBindingSource;
            this.dataGridClock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridClock.Location = new System.Drawing.Point(3, 3);
            this.dataGridClock.Name = "dataGridClock";
            this.dataGridClock.Size = new System.Drawing.Size(878, 634);
            this.dataGridClock.TabIndex = 0;
            // 
            // clockBindingSource
            // 
            this.clockBindingSource.DataSource = typeof(ACT.FFXIV.Clock.Clock);
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.chkMouseMove);
            this.tabPageSettings.Controls.Add(this.chkAutoHideOverlay);
            this.tabPageSettings.Controls.Add(this.buttonBrowse);
            this.tabPageSettings.Controls.Add(this.txtAlertSound);
            this.tabPageSettings.Controls.Add(this.labelAlertSound);
            this.tabPageSettings.Controls.Add(this.numAlertBefore);
            this.tabPageSettings.Controls.Add(this.labelAlertBefore);
            this.tabPageSettings.Controls.Add(this.chkEnabled);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(884, 640);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // chkMouseMove
            // 
            this.chkMouseMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkMouseMove.AutoSize = true;
            this.chkMouseMove.Location = new System.Drawing.Point(9, 604);
            this.chkMouseMove.Name = "chkMouseMove";
            this.chkMouseMove.Size = new System.Drawing.Size(161, 17);
            this.chkMouseMove.TabIndex = 8;
            this.chkMouseMove.Text = "Enable move to drag overlay";
            this.chkMouseMove.UseVisualStyleBackColor = true;
            // 
            // chkAutoHideOverlay
            // 
            this.chkAutoHideOverlay.AutoSize = true;
            this.chkAutoHideOverlay.Location = new System.Drawing.Point(175, 6);
            this.chkAutoHideOverlay.Name = "chkAutoHideOverlay";
            this.chkAutoHideOverlay.Size = new System.Drawing.Size(221, 17);
            this.chkAutoHideOverlay.TabIndex = 7;
            this.chkAutoHideOverlay.Text = "Auto hide overlay when you are in a party";
            this.chkAutoHideOverlay.UseVisualStyleBackColor = true;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(426, 94);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(27, 23);
            this.buttonBrowse.TabIndex = 6;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // txtAlertSound
            // 
            this.txtAlertSound.Location = new System.Drawing.Point(9, 96);
            this.txtAlertSound.Name = "txtAlertSound";
            this.txtAlertSound.Size = new System.Drawing.Size(411, 20);
            this.txtAlertSound.TabIndex = 5;
            // 
            // labelAlertSound
            // 
            this.labelAlertSound.AutoSize = true;
            this.labelAlertSound.Location = new System.Drawing.Point(6, 80);
            this.labelAlertSound.Name = "labelAlertSound";
            this.labelAlertSound.Size = new System.Drawing.Size(65, 13);
            this.labelAlertSound.TabIndex = 4;
            this.labelAlertSound.Text = "Alert Sound:";
            // 
            // numAlertBefore
            // 
            this.numAlertBefore.Location = new System.Drawing.Point(9, 47);
            this.numAlertBefore.Name = "numAlertBefore";
            this.numAlertBefore.Size = new System.Drawing.Size(120, 20);
            this.numAlertBefore.TabIndex = 3;
            // 
            // labelAlertBefore
            // 
            this.labelAlertBefore.AutoSize = true;
            this.labelAlertBefore.Location = new System.Drawing.Point(6, 31);
            this.labelAlertBefore.Name = "labelAlertBefore";
            this.labelAlertBefore.Size = new System.Drawing.Size(167, 13);
            this.labelAlertBefore.TabIndex = 2;
            this.labelAlertBefore.Text = "Pre-alert before (Eorzea seconds):";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(6, 6);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(83, 17);
            this.chkEnabled.TabIndex = 1;
            this.chkEnabled.Text = "Enable Alert";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(813, 668);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save All";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonNodeList
            // 
            this.buttonNodeList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonNodeList.Location = new System.Drawing.Point(3, 668);
            this.buttonNodeList.Name = "buttonNodeList";
            this.buttonNodeList.Size = new System.Drawing.Size(75, 23);
            this.buttonNodeList.TabIndex = 1;
            this.buttonNodeList.Text = "Node List";
            this.buttonNodeList.UseVisualStyleBackColor = true;
            this.buttonNodeList.Click += new System.EventHandler(this.buttonNodeList_Click);
            // 
            // enabledDataGridViewCheckBoxColumn
            // 
            this.enabledDataGridViewCheckBoxColumn.DataPropertyName = "Enabled";
            this.enabledDataGridViewCheckBoxColumn.HeaderText = "";
            this.enabledDataGridViewCheckBoxColumn.Name = "enabledDataGridViewCheckBoxColumn";
            this.enabledDataGridViewCheckBoxColumn.Width = 30;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // regionDataGridViewTextBoxColumn
            // 
            this.regionDataGridViewTextBoxColumn.DataPropertyName = "Region";
            this.regionDataGridViewTextBoxColumn.HeaderText = "Region";
            this.regionDataGridViewTextBoxColumn.Name = "regionDataGridViewTextBoxColumn";
            // 
            // aetheryteDataGridViewTextBoxColumn
            // 
            this.aetheryteDataGridViewTextBoxColumn.DataPropertyName = "Aetheryte";
            this.aetheryteDataGridViewTextBoxColumn.HeaderText = "Aetheryte";
            this.aetheryteDataGridViewTextBoxColumn.Name = "aetheryteDataGridViewTextBoxColumn";
            // 
            // coordinateDataGridViewTextBoxColumn
            // 
            this.coordinateDataGridViewTextBoxColumn.DataPropertyName = "Coordinate";
            this.coordinateDataGridViewTextBoxColumn.HeaderText = "Coordinate";
            this.coordinateDataGridViewTextBoxColumn.Name = "coordinateDataGridViewTextBoxColumn";
            // 
            // jobDataGridViewTextBoxColumn
            // 
            this.jobDataGridViewTextBoxColumn.DataPropertyName = "Job";
            this.jobDataGridViewTextBoxColumn.HeaderText = "Job";
            this.jobDataGridViewTextBoxColumn.Name = "jobDataGridViewTextBoxColumn";
            this.jobDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // eorzeaHourDataGridViewTextBoxColumn
            // 
            this.eorzeaHourDataGridViewTextBoxColumn.DataPropertyName = "EorzeaHour";
            this.eorzeaHourDataGridViewTextBoxColumn.HeaderText = "Hour";
            this.eorzeaHourDataGridViewTextBoxColumn.Name = "eorzeaHourDataGridViewTextBoxColumn";
            // 
            // eorzeaMinuteDataGridViewTextBoxColumn
            // 
            this.eorzeaMinuteDataGridViewTextBoxColumn.DataPropertyName = "EorzeaMinute";
            this.eorzeaMinuteDataGridViewTextBoxColumn.HeaderText = "Minute";
            this.eorzeaMinuteDataGridViewTextBoxColumn.Name = "eorzeaMinuteDataGridViewTextBoxColumn";
            // 
            // eorzeaDurationDataGridViewTextBoxColumn
            // 
            this.eorzeaDurationDataGridViewTextBoxColumn.DataPropertyName = "EorzeaDuration";
            this.eorzeaDurationDataGridViewTextBoxColumn.HeaderText = "Duration";
            this.eorzeaDurationDataGridViewTextBoxColumn.Name = "eorzeaDurationDataGridViewTextBoxColumn";
            // 
            // slotDataGridViewTextBoxColumn
            // 
            this.slotDataGridViewTextBoxColumn.DataPropertyName = "Slot";
            this.slotDataGridViewTextBoxColumn.HeaderText = "Slot";
            this.slotDataGridViewTextBoxColumn.Name = "slotDataGridViewTextBoxColumn";
            this.slotDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // TimeDiff
            // 
            this.TimeDiff.DataPropertyName = "TimeDiff";
            this.TimeDiff.HeaderText = "Next node in";
            this.TimeDiff.Name = "TimeDiff";
            this.TimeDiff.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 150;
            // 
            // Plugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonNodeList);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonSave);
            this.Name = "Plugin";
            this.Size = new System.Drawing.Size(892, 694);
            this.tabControl.ResumeLayout(false);
            this.tabPageClock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clockBindingSource)).EndInit();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAlertBefore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageClock;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.DataGridView dataGridClock;
        public System.Windows.Forms.BindingSource clockBindingSource;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TextBox txtAlertSound;
        private System.Windows.Forms.Label labelAlertSound;
        private System.Windows.Forms.NumericUpDown numAlertBefore;
        private System.Windows.Forms.Label labelAlertBefore;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.CheckBox chkAutoHideOverlay;
        public System.Windows.Forms.CheckBox chkMouseMove;
        private System.Windows.Forms.Button buttonNodeList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aetheryteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coordinateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eorzeaHourDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eorzeaMinuteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eorzeaDurationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn slotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeDiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}
