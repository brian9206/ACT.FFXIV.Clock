using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace ACT.FFXIV.Clock
{
    public partial class frmNodeList : Form
    {
        private List<FFXIVClockNode> nodeList = new List<FFXIVClockNode>();

        public frmNodeList()
        {
            InitializeComponent();
        }

        public void LoadData(string filter = "")
        {
            dataGridView.DataSource = null;

            if (filter == "") dataGridView.DataSource = nodeList;
            else dataGridView.DataSource = nodeList.Where(x => x.Name.ToLower().Contains(filter.ToLower())).ToList();
        }

        private void frmNodeList_Load(object sender, EventArgs e)
        {
            FFXIVClockClient client = new FFXIVClockClient();

            int statusCode;
            string content;

            try
            {
                string url = client.FindItemListJsonURL();

                if (url == null)
                    return;


                client.Get(url, out statusCode, out content);

                if (statusCode != 200)
                    return;
            }
            catch
            {
                return;
            }

            // parse json            
            JArray jNodeList = JArray.Parse(content);

            foreach (JObject jNode in jNodeList)
            {
                nodeList.Add(new FFXIV.Clock.FFXIVClockNode()
                {
                    Type = (string)jNode["type"],
                    Name = (string)jNode["name"],
                    Slot = (string)jNode["slot"],
                    Zone = (string)jNode["zone"],
                    Position = (string)jNode["position"],
                    Teleport = (string)jNode["teleport"],
                    Level = (string)jNode["level"],
                    GatheringSkill = (string)jNode["gathering_skill"],
                    Perception = (string)jNode["perception"],
                    Start = (string)jNode["start"],
                    End = (string)jNode["end"],
                    NodeType = (string)jNode["node_type"]
                });
            }

            LoadData();
        }

        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= nodeList.Count)
                return;

            FFXIVClockNode node = nodeList[e.RowIndex];

            int h, m, duration;

            try
            {
                string[] startTime = node.Start.Split(':');
                string[] endTime = node.End.Split(':');

                int end_h, end_m;

                if (startTime.Length < 2 || endTime.Length < 2)
                    throw new InvalidCastException();

                if (!int.TryParse(startTime[0], out h) || !int.TryParse(startTime[1], out m) || !int.TryParse(endTime[0], out end_h) || !int.TryParse(endTime[1], out end_m))
                    throw new InvalidCastException();

                duration = ((end_h - h) * 60) + (end_m - m);
            }
            catch
            {
                h = 0;
                m = 0;
                duration = 0;

                MessageBox.Show("Time error.\nPlease edit it by yourself.");
            }

            int slot;
            if (node.Slot == "?")
            {
                slot = 0;
            }
            else if (!int.TryParse(node.Slot, out slot))
            {
                slot = 0;
                MessageBox.Show("Slot error.\nPlease edit it by yourself.");
            }

            Clock clock = new FFXIV.Clock.Clock(false, node.Name, node.Zone, node.Teleport, node.Position.Replace("(", "").Replace(")", ""),
                node.Type == "Mining" ? "MIN" : (node.Type == "Botanist" ? "BTN" : node.Type),
                h, m, duration, slot);

            lock (Clock.List)
                Clock.List.Add(clock);

            Plugin.Instance.clockBindingSource.DataSource = null;
            Plugin.Instance.clockBindingSource.DataSource = Clock.List;

            System.Media.SystemSounds.Asterisk.Play();
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            LoadData(textBoxFilter.Text);
        }
    }
}
