using AutoUpdaterDotNET;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using UACHelper;

namespace WinControlTool
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.allowVisible = false; // Defines the visibility state of the form (true is shown and false is hidden)
            this.trayIcon.MouseUp += new MouseEventHandler(NotifyIconClicked);
            this.Deactivate += new EventHandler(HideOnEvent);

            PresetDefaultSettings();

            // Timer for checking updates 
            System.Timers.Timer timer = new System.Timers.Timer
            {
                // 1000 is the number of milliseconds in a second.
                // 60 is the number of seconds in a minute
                // 30 is the number of minutes.
                Interval = 1000 * 60 * 30,
                SynchronizingObject = this
            };
            timer.Elapsed += delegate
            {
                AutoUpdater.Mandatory = false;
                AutoUpdater.ReportErrors = false;
                AutoUpdater.ShowSkipButton = true;
                AutoUpdater.ShowRemindLaterButton = true;
                AutoUpdater.UpdateMode = Mode.Forced;
                UpdateCheck();
            };
            timer.Start();

            if (!RegistryHelper.GetBoolean("GeneralSettings", "DisableStartHint")) // If it's not disabled
            {
                // a BalloonTip will be displayed
                Notification(500, WinControlTool.Properties.Resources.Note, WinControlTool.Properties.Resources.TheProgramWasPlacedInTheTaskBarAtTheStart, ToolTipIcon.Info);
            }
        }

        public bool allowVisible; // Global bool for SetVisibleCore method

        protected override void SetVisibleCore(bool visible)
        {
            base.SetVisibleCore(this.allowVisible ? visible : this.allowVisible);
        }

        private void HideOnEvent(object sender, EventArgs e)
        {
            try
            {
                if (!NotifyIconRect.GetIconRect(trayIcon) // Goes to the class NotifyIconRect and finds out the rectangle of the current NotifyIcon
                        .Contains(Cursor.Position)) // Checks if the cursor position is over the rectangle
                {
                    this.Hide(); // If the cursor is not over the rectangle, the form is faded out
                }
                else
                {
                    return;
                };
            }
            catch (Exception)
            { }
        }

        new public void Show()
        {
            this.allowVisible = true;
            this.Visible = true;
            this.Activate();
        }

        new public void Hide()
        {
            this.allowVisible = false;
            this.Visible = false;
        }

        public void ForceClose()
        {
            this.trayIcon.Icon = null;  //
            this.trayIcon.Dispose();    // Close the NotifyIcon in the Menubar when the programm is closing
            Application.DoEvents();     //
            Environment.Exit(0);        // Fastest way to end the program with code "0"
        }

        private void NotifyIconClicked(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) // If the NotifyIcon is pressed with the left mouse button
            {
                thisVisibility();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            var screen = Screen.FromPoint(this.Location);
            this.Location = new Point(screen.WorkingArea.Right - (this.Width + 10), screen.WorkingArea.Bottom - (this.Height + 10));

            // Check for updates at startup
            UpdateCheckOnStartup();

            base.OnLoad(e);
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            this.trayIcon.Visible = true; // Make the NotifyIcon visible
            this.ShowInTaskbar = false;   // Remove the Form from taskbar
            try
            {
                insertComboBoxValues();
                comboBoxLanguage.SelectedIndexChanged -= new EventHandler(ComboBoxLanguage_SelectedIndexChanged);
                Language.checkLanguage(this, comboBoxLanguage);
                comboBoxLanguage.SelectedIndexChanged += new EventHandler(ComboBoxLanguage_SelectedIndexChanged);
                if (!UACHelper.UACHelper.IsAdministrator) // Program was started without admin rights
                {
                    if (!RegistryHelper.GetBoolean("GeneralSettings", "DisableStartHint"))
                    {
                        // UAC Helper Class GitHub Doc
                        // https://github.com/falahati/UACHelper
                        DialogResult result = WinForm.ShieldifyNativeDialog(DialogResult.Yes, () =>
                                MessageBox.Show(this, WinControlTool.Properties.Resources.YouHaveStartedTheProgramWithoutAdministratorRights,
                                   WinControlTool.Properties.Resources.StartedWithoutAdminRights, MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Information));
                        switch (result)
                        {
                            case DialogResult.Yes:
                                ProcessStartInfo proc = new ProcessStartInfo();
                                proc.UseShellExecute = true;
                                proc.WorkingDirectory = Environment.CurrentDirectory;
                                proc.FileName = Assembly.GetEntryAssembly().CodeBase;
                                proc.Verb = "runas";
                                Process.Start(proc);
                                ForceClose();
                                break;
                            case DialogResult.No:
                                this.Show();
                                // add all admin actions the UAC Shield
                                WinForm.ShieldifyButton(buttonSyncDateTime);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TrayIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
        }

        private void ContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.Visible) // If it's visible, then
            {
                ShowToolStripMenuItem.Text = WinControlTool.Properties.Resources.Hide; //change the text to "Hide"
            }
            else if (!this.Visible) // If it isn't visible, then
            {
                ShowToolStripMenuItem.Text = WinControlTool.Properties.Resources.Show; //change the text to "Show"
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show(WinControlTool.Properties.Resources.TheApplicationWillBeClosedNowNDoYouReallyWantToDoThisAction, WinControlTool.Properties.Resources.Note, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                ForceClose();
            }
            else if (result == DialogResult.No)
            {
                return;
            }
        }

        private void ShowToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            thisVisibility();
        }

        private void PictureBoxGitHub_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) // If the left mouse button is pressed
            {
                GoToWebsite("https://github.com/Hendrik-Koelbel/");
            }
        }


        /// <summary>
        /// Method for simplified usage as these tasks are used several times
        /// </summary>
        public void thisVisibility()
        {
            if (this.Visible) // If it's visible
            {
                this.Hide(); // then hide the application
            }
            else if (!this.Visible) // If it isn't visible
            {
                this.Show(); // then show the application
            }
        }

        /// <summary>
        /// Method for opening a URL in the default browser.
        /// </summary>
        /// <param name="SiteUrl">The URL to open in the default browser</param>
        public void GoToWebsite(string SiteUrl)
        {
            string url = SiteUrl; // Set the parameter to a local variable
            try
            {
                WebRequest request = WebRequest.Create(url); // Send a WebRequest 
                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); // Get the answer of the webrequest
                if (response != null || response.StatusCode == HttpStatusCode.OK)
                {
                    System.Diagnostics.Process.Start(url);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region AutoUpdater.Net Config
        // ToolStripMenuItem Check for Update
        private void CheckForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoUpdater.Mandatory = true;
            AutoUpdater.ReportErrors = true;
            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.UpdateMode = Mode.Normal;
            UpdateCheck();
        }
        // ButtonUpdate Check for Update
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            AutoUpdater.Mandatory = true;
            AutoUpdater.ReportErrors = true;
            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.UpdateMode = Mode.Normal;
            UpdateCheck();
        }

        public void UpdateCheckOnStartup()
        {
            AutoUpdater.Mandatory = true;
            AutoUpdater.ReportErrors = false;
            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.UpdateMode = Mode.Normal;
            UpdateCheck();
        }

        protected string InfoXML = "https://raw.githubusercontent.com/Hendrik-Koelbel/WinControlTool/master/WinControlTool/Info.xml";
        public void UpdateCheck()
        {
            try
            {
                AutoUpdater.UpdateFormSize = new System.Drawing.Size(650, 450);
                AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;
                AutoUpdater.RunUpdateAsAdmin = false;
                //AutoUpdater.DownloadPath = Environment.CurrentDirectory;
                AutoUpdater.Start(InfoXML);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message,
                    ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    thisVisibility();
                }
            }
        }
        private void AutoUpdater_ApplicationExitEvent()
        {
            this.Text = @"Closing application...";
            Thread.Sleep(2000);
            Application.Exit();
        }

        #endregion


        #region ComboBoxLanguage Events
        private void ComboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string currentItem = comboBoxLanguage.SelectedItem.ToString(); // { Description = Deutsch, value = de }
            //string currentDisplay = comboBoxLanguage.DisplayMember; // only "Deutsch"
            string currentValue = comboBoxLanguage.SelectedValue.ToString(); // only "de"

            try
            {
                Language.switchCaseLanguage(this, currentValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(ex.Message), ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void insertComboBoxValues()
        {
            try
            {
                //https://stackoverflow.com/a/35936210/11189474
                comboBoxLanguage.DataSource = Enum.GetValues(typeof(Language.Languages)).Cast<Enum>().Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                    .OrderBy(item => item.value).ToList();
                comboBoxLanguage.DisplayMember = "Description";
                comboBoxLanguage.ValueMember = "value";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Date/Time Region
        private void ButtonSyncDateTime_Click(object sender, EventArgs e)
        {
            try
            {
                Process processTime = new Process();
                processTime.StartInfo.FileName = "w32tm";
                processTime.StartInfo.Arguments = "/resync";
                processTime.StartInfo.Verb = "runas";
                processTime.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processTime.Start();
                processTime.WaitForExit();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message,
                    ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    thisVisibility();
                }
            }
        }

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private void RadioButtonDisableSecurity_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                // hier noch die änderung in der Registry einfügen
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// System notification
        /// </summary>
        /// <param name="Time">Time displayed</param>
        /// <param name="TitleText">Title text (REQUIRED)</param>
        /// <param name="TipText">Body text (REQUIRED)</param>
        /// <param name="Icon">Icon</param>
        public void Notification(int Time, string TitleText, string TipText, ToolTipIcon Icon)
        {
            try
            {
                if (!String.IsNullOrEmpty(TitleText) && !String.IsNullOrEmpty(TipText))
                {
                    trayIcon.ShowBalloonTip(Time, TitleText, TipText, Icon);
                }
            }
            catch (Exception)
            {
            }
        }

        private void CheckBoxDisableStartHint_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxDisableStartHint.CheckState == CheckState.Checked)
                {
                    RegistryHelper.SaveValue("GeneralSettings", "DisableStartHint", true);
                }
                else if (checkBoxDisableStartHint.CheckState == CheckState.Unchecked)
                {
                    RegistryHelper.SaveValue("GeneralSettings", "DisableStartHint", false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Preset Default Settings and Controls
        public void PresetDefaultSettings()
        {
            try
            {
                RegistryHelper.CreateKeyIfNotExisting("SecuritySettings", "EnableSecurity", true);
                if (RegistryHelper.GetBoolean("SecuritySettings", "EnableSecurity"))
                    radioButtonEnableSecurity.Checked = true;
                else if (!RegistryHelper.GetBoolean("SecuritySettings", "EnableSecurity"))
                    radioButtonDisableSecurity.Checked = true;

                RegistryHelper.CreateKeyIfNotExisting("GeneralSettings", "DisableStartHint", false);
                if (RegistryHelper.GetBoolean("GeneralSettings", "DisableStartHint"))
                    checkBoxDisableStartHint.Checked = true;
                else if (!RegistryHelper.GetBoolean("GeneralSettings", "DisableStartHint"))
                    checkBoxDisableStartHint.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
