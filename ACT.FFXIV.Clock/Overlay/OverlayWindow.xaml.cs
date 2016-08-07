using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ACT.FFXIV.Clock
{
    /// <summary>
    /// Interaction logic for OverlayWindow.xaml
    /// </summary>
    public partial class OverlayWindow : Window
    {
        internal Clock Clock
        {
            get;
            set;
        }

        public OverlayWindow()
        {
            Clock = null;
            InitializeComponent();
        }

        internal void ShowDetails(Clock clock)
        {
            Clock = clock;
            UpdateDetails();

            DetailUI.Visibility = Visibility.Visible;
            ListUI.Visibility = Visibility.Hidden;
        }

        public void UpdateDetails()
        {
            if (Clock == null)
                return;

            textName.Text = Clock.Name;
            textSlot.Text = "Slot " + (Clock.Slot <= 0 ? "Random" : Clock.Slot.ToString());
            textRegion.Text = Clock.Region;
            textAetheryte.Text = Clock.Aetheryte;
            textCoordinate.Text = "(" + Clock.Coordinate + ")";
            textJob.Text = Clock.Job;
            textTime.Text = Clock.EorzeaHour.ToString("00") + ":" + Clock.EorzeaMinute.ToString("00") + " ET - " + Clock.TimeDiff;
            textStatus.Text = Clock.Status;
            textStatus.Tag = Clock.IsInDuration ? "Active" : "NonActive";
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!Plugin.Instance.chkMouseMove.Checked)
            {
                // back to the game
                Plugin.SetFFXIVForeground();
                return;
            }
                
            this.DragMove();
        }

        private void DetailUI_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DetailUI.Visibility = Visibility.Hidden;
            ListUI.Visibility = Visibility.Visible;
            Plugin.SetFFXIVForeground();
        }
    }
}
