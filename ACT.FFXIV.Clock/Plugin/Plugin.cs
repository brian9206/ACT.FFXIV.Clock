using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using Advanced_Combat_Tracker;
using System.Windows.Interop;

namespace ACT.FFXIV.Clock
{
    public partial class Plugin : UserControl, IActPluginV1
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        // ===
        public static Plugin Instance = null;

        public Label lblStatus = null;    // The status label that appears in ACT's Plugin tab
        public Settings settings = null;
        public OverlayWindow overlayWindow = null;

        public bool IsRunning
        {
            get;
            set;
        }

        public Plugin()
        {
            Instance = this;
            InitializeComponent();
        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            // load config
            settings = Settings.Load();

            chkEnabled.Checked = settings.Enabled;
            numAlertBefore.Value = settings.AlertBefore;
            txtAlertSound.Text = settings.AlertSound;
            chkAutoHideOverlay.Checked = settings.AutoHideOverlay;

            // overlay
            overlayWindow = new FFXIV.Clock.OverlayWindow();
            overlayWindow.Show();
            overlayWindow.Left = settings.OverlayX;
            overlayWindow.Top = settings.OverlayY;

            // config window
            Dock = DockStyle.Fill;
            pluginScreenSpace.Text = "FFXIV: In-Game Clock";
            pluginScreenSpace.Controls.Add(this);

            // start!
            IsRunning = true;
            Task.Run(PluginTask);

            // plugin started
            lblStatus = pluginStatusText;   // Hand the status label's reference to our local var
            lblStatus.Text = "Plugin Started";

            clockBindingSource.DataSource = Clock.List;
        }

        public void DeInitPlugin()
        {
            lblStatus.Text = "Plugin Stopped";
            IsRunning = false;
        }

        public static void SetFFXIVForeground()
        {
            var ffxivProcess = FF14PluginHelper.GetFFXIVProcess;

            // check if ffxiv is running
            if (ffxivProcess == null)
                return;

            // bring ff14 to foreground
            SetForegroundWindow(ffxivProcess.MainWindowHandle);
        }

        // ---
        private async Task PluginTask()
        {
            while (IsRunning)
            {
                // alert task
                ClockTask();

                // update datagrid
                Invoke(new Action(UpdateDataGrid));

                // update overlay
                overlayWindow.Dispatcher.Invoke(new Action(UpdateOverlay));

                await Task.Delay(200);
            }
        }

        private void ClockTask()
        {
            if (!settings.Enabled)
                return;

            lock (Clock.List)
            {
                foreach (var clock in Clock.List.Where(x => x.Enabled))
                {
                    clock.PreAlert();
                    clock.Alert();
                }
            }
        }

        private void UpdateDataGrid()
        {
            if (dataGridClock.IsCurrentCellInEditMode)
                return;

            dataGridClock.Refresh();
        }

        private void UpdateOverlay()
        {
            bool isVisible = (GetForegroundWindow() == new WindowInteropHelper(overlayWindow).Handle || (FF14PluginHelper.GetFFXIVProcess != null && !FF14PluginHelper.GetFFXIVProcess.HasExited && GetForegroundWindow() == FF14PluginHelper.GetFFXIVProcess.MainWindowHandle));

            // ---
            if (isVisible && settings.AutoHideOverlay)
            {
                // check if the user is in a party
                var list = FF14PluginHelper.GetCombatantListParty();
                int combatant = list.Count();
                
                if (combatant > 1)
                {
                    isVisible = false;
                }
            }
            // ---

            if (!settings.Enabled)
                isVisible = false;

            overlayWindow.Visibility = isVisible ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;

            if (!settings.Enabled)
                return;

            overlayWindow.UpdateDetails();
            overlayWindow.ListUI.Children.Clear();

            lock (Clock.List)
            {
                foreach (Clock clock in Clock.List.Where(x => x.Enabled).OrderBy(x => !x.IsInDuration).ThenBy(x => x.GetTimeDiff(x.IsInDuration)))
                {
                    overlayWindow.ListUI.Children.Add(new NodeItem(clock)
                    {
                        HorizontalAlignment = System.Windows.HorizontalAlignment.Right
                    });
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            settings.Enabled = chkEnabled.Checked;
            settings.AlertBefore = (int)numAlertBefore.Value;
            settings.AlertSound = txtAlertSound.Text;
            settings.AutoHideOverlay = chkAutoHideOverlay.Checked;
            settings.OverlayX = overlayWindow.Left;
            settings.OverlayY = overlayWindow.Top;

            settings.Save();

            MessageBox.Show("Saved");
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            openFileDlg.ShowDialog();
            txtAlertSound.Text = openFileDlg.FileName;
        }

        private void buttonNodeList_Click(object sender, EventArgs e)
        {
            frmNodeList w = new frmNodeList();
            w.Show();
        }
    }
}
