namespace WinControlTool
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageHome = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelHome = new System.Windows.Forms.TableLayoutPanel();
            this.tabPageSecure = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelSecurity = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxSecurity = new System.Windows.Forms.GroupBox();
            this.radioButtonDisableSecurity = new System.Windows.Forms.RadioButton();
            this.radioButtonEnableSecurity = new System.Windows.Forms.RadioButton();
            this.tabPageDateTime = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelDateAndTime = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxSelectTime = new System.Windows.Forms.GroupBox();
            this.buttonApplyTime = new System.Windows.Forms.Button();
            this.TimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBoxSelectDate = new System.Windows.Forms.GroupBox();
            this.buttonApplyDate = new System.Windows.Forms.Button();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBoxSyncDateTime = new System.Windows.Forms.GroupBox();
            this.buttonSyncDateTime = new System.Windows.Forms.Button();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelSettings = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxLanguage = new System.Windows.Forms.GroupBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.groupBoxUpdate = new System.Windows.Forms.GroupBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.groupBoxHints = new System.Windows.Forms.GroupBox();
            this.checkBoxDisableBalloonHint = new System.Windows.Forms.CheckBox();
            this.checkBoxDisableElevatedAdminRightsHint = new System.Windows.Forms.CheckBox();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelLog = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelHeader = new System.Windows.Forms.Label();
            this.pictureBoxGitHub = new System.Windows.Forms.PictureBox();
            this.contextMenu.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageHome.SuspendLayout();
            this.tabPageSecure.SuspendLayout();
            this.tableLayoutPanelSecurity.SuspendLayout();
            this.groupBoxSecurity.SuspendLayout();
            this.tabPageDateTime.SuspendLayout();
            this.tableLayoutPanelDateAndTime.SuspendLayout();
            this.groupBoxSelectTime.SuspendLayout();
            this.groupBoxSelectDate.SuspendLayout();
            this.groupBoxSyncDateTime.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.tableLayoutPanelSettings.SuspendLayout();
            this.groupBoxLanguage.SuspendLayout();
            this.groupBoxUpdate.SuspendLayout();
            this.groupBoxHints.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.tableLayoutPanelLog.SuspendLayout();
            this.groupBoxLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGitHub)).BeginInit();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.contextMenu;
            resources.ApplyResources(this.trayIcon, "trayIcon");
            this.trayIcon.BalloonTipClicked += new System.EventHandler(this.TrayIcon_BalloonTipClicked);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdateToolStripMenuItem,
            this.ShowToolStripMenuItem,
            this.toolStripSeparator1,
            this.CloseToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            resources.ApplyResources(this.contextMenu, "contextMenu");
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenu_Opening);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            resources.ApplyResources(this.checkForUpdateToolStripMenuItem, "checkForUpdateToolStripMenuItem");
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.CheckForUpdateToolStripMenuItem_Click);
            // 
            // ShowToolStripMenuItem
            // 
            resources.ApplyResources(this.ShowToolStripMenuItem, "ShowToolStripMenuItem");
            this.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
            this.ShowToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // CloseToolStripMenuItem
            // 
            resources.ApplyResources(this.CloseToolStripMenuItem, "CloseToolStripMenuItem");
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.tableLayoutPanelMain, "tableLayoutPanelMain");
            this.tableLayoutPanelMain.Controls.Add(this.tabControlMain, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelHeader, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxGitHub, 1, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            // 
            // tabControlMain
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.tabControlMain, 2);
            this.tabControlMain.Controls.Add(this.tabPageHome);
            this.tabControlMain.Controls.Add(this.tabPageSecure);
            this.tabControlMain.Controls.Add(this.tabPageDateTime);
            this.tabControlMain.Controls.Add(this.tabPageSettings);
            this.tabControlMain.Controls.Add(this.tabPageLog);
            resources.ApplyResources(this.tabControlMain, "tabControlMain");
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            // 
            // tabPageHome
            // 
            this.tabPageHome.Controls.Add(this.tableLayoutPanelHome);
            resources.ApplyResources(this.tabPageHome, "tabPageHome");
            this.tabPageHome.Name = "tabPageHome";
            this.tabPageHome.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelHome
            // 
            resources.ApplyResources(this.tableLayoutPanelHome, "tableLayoutPanelHome");
            this.tableLayoutPanelHome.Name = "tableLayoutPanelHome";
            // 
            // tabPageSecure
            // 
            this.tabPageSecure.Controls.Add(this.tableLayoutPanelSecurity);
            resources.ApplyResources(this.tabPageSecure, "tabPageSecure");
            this.tabPageSecure.Name = "tabPageSecure";
            this.tabPageSecure.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelSecurity
            // 
            resources.ApplyResources(this.tableLayoutPanelSecurity, "tableLayoutPanelSecurity");
            this.tableLayoutPanelSecurity.Controls.Add(this.groupBoxSecurity, 0, 0);
            this.tableLayoutPanelSecurity.Name = "tableLayoutPanelSecurity";
            // 
            // groupBoxSecurity
            // 
            resources.ApplyResources(this.groupBoxSecurity, "groupBoxSecurity");
            this.groupBoxSecurity.Controls.Add(this.radioButtonDisableSecurity);
            this.groupBoxSecurity.Controls.Add(this.radioButtonEnableSecurity);
            this.groupBoxSecurity.Name = "groupBoxSecurity";
            this.groupBoxSecurity.TabStop = false;
            // 
            // radioButtonDisableSecurity
            // 
            resources.ApplyResources(this.radioButtonDisableSecurity, "radioButtonDisableSecurity");
            this.radioButtonDisableSecurity.Name = "radioButtonDisableSecurity";
            this.radioButtonDisableSecurity.TabStop = true;
            this.radioButtonDisableSecurity.UseVisualStyleBackColor = true;
            this.radioButtonDisableSecurity.CheckedChanged += new System.EventHandler(this.RadioButtonDisableSecurity_CheckedChanged);
            // 
            // radioButtonEnableSecurity
            // 
            resources.ApplyResources(this.radioButtonEnableSecurity, "radioButtonEnableSecurity");
            this.radioButtonEnableSecurity.Name = "radioButtonEnableSecurity";
            this.radioButtonEnableSecurity.TabStop = true;
            this.radioButtonEnableSecurity.UseVisualStyleBackColor = true;
            this.radioButtonEnableSecurity.CheckedChanged += new System.EventHandler(this.RadioButtonDisableSecurity_CheckedChanged);
            // 
            // tabPageDateTime
            // 
            this.tabPageDateTime.Controls.Add(this.tableLayoutPanelDateAndTime);
            resources.ApplyResources(this.tabPageDateTime, "tabPageDateTime");
            this.tabPageDateTime.Name = "tabPageDateTime";
            this.tabPageDateTime.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelDateAndTime
            // 
            resources.ApplyResources(this.tableLayoutPanelDateAndTime, "tableLayoutPanelDateAndTime");
            this.tableLayoutPanelDateAndTime.Controls.Add(this.groupBoxSelectTime, 0, 1);
            this.tableLayoutPanelDateAndTime.Controls.Add(this.groupBoxSelectDate, 0, 0);
            this.tableLayoutPanelDateAndTime.Controls.Add(this.groupBoxSyncDateTime, 1, 0);
            this.tableLayoutPanelDateAndTime.Name = "tableLayoutPanelDateAndTime";
            // 
            // groupBoxSelectTime
            // 
            resources.ApplyResources(this.groupBoxSelectTime, "groupBoxSelectTime");
            this.groupBoxSelectTime.Controls.Add(this.buttonApplyTime);
            this.groupBoxSelectTime.Controls.Add(this.TimePicker);
            this.groupBoxSelectTime.Name = "groupBoxSelectTime";
            this.groupBoxSelectTime.TabStop = false;
            // 
            // buttonApplyTime
            // 
            resources.ApplyResources(this.buttonApplyTime, "buttonApplyTime");
            this.buttonApplyTime.Name = "buttonApplyTime";
            this.buttonApplyTime.UseVisualStyleBackColor = true;
            // 
            // TimePicker
            // 
            this.TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            resources.ApplyResources(this.TimePicker, "TimePicker");
            this.TimePicker.Name = "TimePicker";
            this.TimePicker.ShowUpDown = true;
            this.TimePicker.ValueChanged += new System.EventHandler(this.TimePicker_ValueChanged);
            // 
            // groupBoxSelectDate
            // 
            resources.ApplyResources(this.groupBoxSelectDate, "groupBoxSelectDate");
            this.groupBoxSelectDate.Controls.Add(this.buttonApplyDate);
            this.groupBoxSelectDate.Controls.Add(this.DatePicker);
            this.groupBoxSelectDate.Name = "groupBoxSelectDate";
            this.groupBoxSelectDate.TabStop = false;
            // 
            // buttonApplyDate
            // 
            resources.ApplyResources(this.buttonApplyDate, "buttonApplyDate");
            this.buttonApplyDate.Name = "buttonApplyDate";
            this.buttonApplyDate.UseVisualStyleBackColor = true;
            // 
            // DatePicker
            // 
            this.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.DatePicker, "DatePicker");
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.ValueChanged += new System.EventHandler(this.DatePicker_ValueChanged);
            // 
            // groupBoxSyncDateTime
            // 
            resources.ApplyResources(this.groupBoxSyncDateTime, "groupBoxSyncDateTime");
            this.tableLayoutPanelDateAndTime.SetColumnSpan(this.groupBoxSyncDateTime, 2);
            this.groupBoxSyncDateTime.Controls.Add(this.buttonSyncDateTime);
            this.groupBoxSyncDateTime.Name = "groupBoxSyncDateTime";
            this.groupBoxSyncDateTime.TabStop = false;
            // 
            // buttonSyncDateTime
            // 
            resources.ApplyResources(this.buttonSyncDateTime, "buttonSyncDateTime");
            this.buttonSyncDateTime.Name = "buttonSyncDateTime";
            this.buttonSyncDateTime.UseVisualStyleBackColor = true;
            this.buttonSyncDateTime.Click += new System.EventHandler(this.ButtonSyncDateTime_Click);
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.tableLayoutPanelSettings);
            resources.ApplyResources(this.tabPageSettings, "tabPageSettings");
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelSettings
            // 
            resources.ApplyResources(this.tableLayoutPanelSettings, "tableLayoutPanelSettings");
            this.tableLayoutPanelSettings.Controls.Add(this.groupBoxLanguage, 0, 0);
            this.tableLayoutPanelSettings.Controls.Add(this.groupBoxUpdate, 1, 0);
            this.tableLayoutPanelSettings.Controls.Add(this.groupBoxHints, 0, 1);
            this.tableLayoutPanelSettings.Name = "tableLayoutPanelSettings";
            // 
            // groupBoxLanguage
            // 
            resources.ApplyResources(this.groupBoxLanguage, "groupBoxLanguage");
            this.groupBoxLanguage.Controls.Add(this.comboBoxLanguage);
            this.groupBoxLanguage.Name = "groupBoxLanguage";
            this.groupBoxLanguage.TabStop = false;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxLanguage, "comboBoxLanguage");
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLanguage_SelectedIndexChanged);
            // 
            // groupBoxUpdate
            // 
            resources.ApplyResources(this.groupBoxUpdate, "groupBoxUpdate");
            this.tableLayoutPanelSettings.SetColumnSpan(this.groupBoxUpdate, 2);
            this.groupBoxUpdate.Controls.Add(this.buttonUpdate);
            this.groupBoxUpdate.Name = "groupBoxUpdate";
            this.groupBoxUpdate.TabStop = false;
            // 
            // buttonUpdate
            // 
            resources.ApplyResources(this.buttonUpdate, "buttonUpdate");
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // groupBoxHints
            // 
            resources.ApplyResources(this.groupBoxHints, "groupBoxHints");
            this.tableLayoutPanelSettings.SetColumnSpan(this.groupBoxHints, 3);
            this.groupBoxHints.Controls.Add(this.checkBoxDisableBalloonHint);
            this.groupBoxHints.Controls.Add(this.checkBoxDisableElevatedAdminRightsHint);
            this.groupBoxHints.Name = "groupBoxHints";
            this.tableLayoutPanelSettings.SetRowSpan(this.groupBoxHints, 2);
            this.groupBoxHints.TabStop = false;
            // 
            // checkBoxDisableBalloonHint
            // 
            resources.ApplyResources(this.checkBoxDisableBalloonHint, "checkBoxDisableBalloonHint");
            this.checkBoxDisableBalloonHint.Name = "checkBoxDisableBalloonHint";
            this.checkBoxDisableBalloonHint.UseVisualStyleBackColor = true;
            this.checkBoxDisableBalloonHint.CheckStateChanged += new System.EventHandler(this.CheckBoxDisableBalloonHint_CheckStateChanged);
            // 
            // checkBoxDisableElevatedAdminRightsHint
            // 
            resources.ApplyResources(this.checkBoxDisableElevatedAdminRightsHint, "checkBoxDisableElevatedAdminRightsHint");
            this.checkBoxDisableElevatedAdminRightsHint.Name = "checkBoxDisableElevatedAdminRightsHint";
            this.checkBoxDisableElevatedAdminRightsHint.UseVisualStyleBackColor = true;
            this.checkBoxDisableElevatedAdminRightsHint.CheckStateChanged += new System.EventHandler(this.CheckBoxDisableElevatedAdminRightsHint_CheckStateChanged);
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.tableLayoutPanelLog);
            resources.ApplyResources(this.tabPageLog, "tabPageLog");
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelLog
            // 
            resources.ApplyResources(this.tableLayoutPanelLog, "tableLayoutPanelLog");
            this.tableLayoutPanelLog.Controls.Add(this.groupBoxLog, 0, 0);
            this.tableLayoutPanelLog.Name = "tableLayoutPanelLog";
            // 
            // groupBoxLog
            // 
            resources.ApplyResources(this.groupBoxLog, "groupBoxLog");
            this.tableLayoutPanelLog.SetColumnSpan(this.groupBoxLog, 2);
            this.groupBoxLog.Controls.Add(this.textBoxLog);
            this.groupBoxLog.Controls.Add(this.buttonReset);
            this.groupBoxLog.Name = "groupBoxLog";
            this.tableLayoutPanelLog.SetRowSpan(this.groupBoxLog, 2);
            this.groupBoxLog.TabStop = false;
            // 
            // textBoxLog
            // 
            resources.ApplyResources(this.textBoxLog, "textBoxLog");
            this.textBoxLog.Name = "textBoxLog";
            // 
            // buttonReset
            // 
            resources.ApplyResources(this.buttonReset, "buttonReset");
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // labelHeader
            // 
            resources.ApplyResources(this.labelHeader, "labelHeader");
            this.labelHeader.Name = "labelHeader";
            // 
            // pictureBoxGitHub
            // 
            this.pictureBoxGitHub.Image = global::WinControlTool.Properties.Resources.github;
            resources.ApplyResources(this.pictureBoxGitHub, "pictureBoxGitHub");
            this.pictureBoxGitHub.Name = "pictureBoxGitHub";
            this.pictureBoxGitHub.TabStop = false;
            this.pictureBoxGitHub.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxGitHub_MouseClick);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenu.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageHome.ResumeLayout(false);
            this.tabPageSecure.ResumeLayout(false);
            this.tableLayoutPanelSecurity.ResumeLayout(false);
            this.tableLayoutPanelSecurity.PerformLayout();
            this.groupBoxSecurity.ResumeLayout(false);
            this.groupBoxSecurity.PerformLayout();
            this.tabPageDateTime.ResumeLayout(false);
            this.tableLayoutPanelDateAndTime.ResumeLayout(false);
            this.tableLayoutPanelDateAndTime.PerformLayout();
            this.groupBoxSelectTime.ResumeLayout(false);
            this.groupBoxSelectTime.PerformLayout();
            this.groupBoxSelectDate.ResumeLayout(false);
            this.groupBoxSelectDate.PerformLayout();
            this.groupBoxSyncDateTime.ResumeLayout(false);
            this.groupBoxSyncDateTime.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            this.tableLayoutPanelSettings.ResumeLayout(false);
            this.tableLayoutPanelSettings.PerformLayout();
            this.groupBoxLanguage.ResumeLayout(false);
            this.groupBoxUpdate.ResumeLayout(false);
            this.groupBoxUpdate.PerformLayout();
            this.groupBoxHints.ResumeLayout(false);
            this.groupBoxHints.PerformLayout();
            this.tabPageLog.ResumeLayout(false);
            this.tableLayoutPanelLog.ResumeLayout(false);
            this.tableLayoutPanelLog.PerformLayout();
            this.groupBoxLog.ResumeLayout(false);
            this.groupBoxLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGitHub)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem ShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageHome;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.PictureBox pictureBoxGitHub;
        private System.Windows.Forms.TabPage tabPageSecure;
        private System.Windows.Forms.TabPage tabPageDateTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLog;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSecurity;
        private System.Windows.Forms.GroupBox groupBoxSecurity;
        private System.Windows.Forms.RadioButton radioButtonDisableSecurity;
        private System.Windows.Forms.RadioButton radioButtonEnableSecurity;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSettings;
        private System.Windows.Forms.GroupBox groupBoxLanguage;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.GroupBox groupBoxUpdate;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDateAndTime;
        private System.Windows.Forms.GroupBox groupBoxSelectDate;
        private System.Windows.Forms.DateTimePicker DatePicker;
        private System.Windows.Forms.GroupBox groupBoxSyncDateTime;
        private System.Windows.Forms.GroupBox groupBoxSelectTime;
        private System.Windows.Forms.DateTimePicker TimePicker;
        private System.Windows.Forms.Button buttonSyncDateTime;
        private System.Windows.Forms.GroupBox groupBoxHints;
        private System.Windows.Forms.CheckBox checkBoxDisableElevatedAdminRightsHint;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHome;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonApplyTime;
        private System.Windows.Forms.Button buttonApplyDate;
        private System.Windows.Forms.CheckBox checkBoxDisableBalloonHint;
    }
}

