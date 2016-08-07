using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for NodeItem.xaml
    /// </summary>
    public partial class NodeItem : UserControl
    {
        private Clock clock;

        internal Clock Item
        {
            get
            {
                return clock;
            }
            set
            {
                clock = value;
                Update();
            }
        }

        internal NodeItem(Clock clock)
        {
            InitializeComponent();
            Item = clock;
        }

        public void Update()
        {
            TextUI.Tag = Item.IsInDuration ? "Active" : "NonActive";

            if (Item.IsInDuration)
            {
                TextUI.Text = Item.Name + " (" + (Item.Slot <= 0 ? "Random" : Item.Slot.ToString()) + ") - " + Item.TimeDiffInDuration + " [" + Item.Job + "]";
            }
            else
            {
                TextUI.Text = Item.Name + " - " + Item.TimeDiff + " [" + Item.Job + "]";
            }
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Plugin.Instance.overlayWindow.ShowDetails(Item);
        }
    }
}
