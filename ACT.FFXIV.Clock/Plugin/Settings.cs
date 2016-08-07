using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace ACT.FFXIV.Clock
{
    public class Settings
    {
        private const string SETTINGS_FILENAME = "ACT.FFXIV.Clock.Settings.xml";

        public static Settings Load(string filename = SETTINGS_FILENAME)
        {
            XmlDocument xmlSettings = new XmlDocument();

            if (File.Exists(filename))
            {
                // load the settings if it is already exists
                xmlSettings.Load(filename);
            }
            else
            {
                // create new settings
                xmlSettings.AppendChild(xmlSettings.CreateXmlDeclaration("1.0", null, null));

                var settingsNode = xmlSettings.CreateElement("settings");

                var node = xmlSettings.CreateElement("enabled");
                node.InnerText = "false";
                settingsNode.AppendChild(node);

                node = xmlSettings.CreateElement("alertbefore");
                node.InnerText = "60";
                settingsNode.AppendChild(node);

                node = xmlSettings.CreateElement("alertsound");
                node.InnerText = "";
                settingsNode.AppendChild(node);

                settingsNode.AppendChild(xmlSettings.CreateElement("clock"));

                xmlSettings.AppendChild(settingsNode);

                xmlSettings.Save(filename);
            }

            return new Settings(filename, xmlSettings);
        }

        // ===
        public XmlDocument xmlSettings;
        public string filename;

        public bool Enabled { get; set; }
        public int AlertBefore { get; set; }
        public string AlertSound { get; set; }
        public bool AutoHideOverlay { get; set; }
        public double OverlayX { get; set; }
        public double OverlayY { get; set; }

        private Settings(string filename, XmlDocument xmlSettings)
        {
            this.filename = filename;
            this.xmlSettings = xmlSettings;

            // load settings
            Enabled = bool.Parse(GetXml("enabled", "true"));
            AlertBefore = int.Parse(GetXml("alertbefore", "60"));
            AlertSound = GetXml("alertsound", "");
            AutoHideOverlay = bool.Parse(GetXml("autohideoverlay", "true"));
            OverlayX = double.Parse(GetXml("overlay_xpos", "0"));
            OverlayY = double.Parse(GetXml("overlay_ypos", "0"));

            lock (Clock.List)
            {
                // clear the list
                Clock.List.Clear();

                // load all clock
                foreach (XmlNode node in xmlSettings.SelectNodes("/settings/clock/clock"))
                {
                    try
                    {
                        Clock.List.Add(new Clock(bool.Parse(node.Attributes["enabled"].InnerText), node.Attributes["name"].InnerText, node.Attributes["region"].InnerText, node.Attributes["aetheryte"].InnerText,
                            node.Attributes["coordinate"].InnerText, node.Attributes["job"].InnerText,
                            int.Parse(node.Attributes["h"].InnerText), int.Parse(node.Attributes["m"].InnerText), int.Parse(node.Attributes["duration"].InnerText),
                            int.Parse(node.Attributes["slot"].InnerText)));
                    }
                    catch
                    {
                        // just ignore the error node
                    }
                }
            }
        }

        public void Save()
        {
            SetXml("enabled", Enabled.ToString());
            SetXml("alertbefore", AlertBefore.ToString());
            SetXml("alertsound", AlertSound);
            SetXml("autohideoverlay", AutoHideOverlay.ToString());
            SetXml("overlay_xpos", OverlayX.ToString());
            SetXml("overlay_ypos", OverlayY.ToString());

            // clock
            var clockNode = xmlSettings.SelectSingleNode("/settings/clock");
            clockNode.RemoveAll();

            lock (Clock.List)
            {
                foreach (var clock in Clock.List)
                {
                    var node = xmlSettings.CreateElement("clock");
                    node.SetAttribute("name", clock.Name);
                    node.SetAttribute("region", clock.Region);
                    node.SetAttribute("aetheryte", clock.Aetheryte);
                    node.SetAttribute("coordinate", clock.Coordinate);
                    node.SetAttribute("job", clock.Job);
                    node.SetAttribute("h", clock.EorzeaHour.ToString());
                    node.SetAttribute("m", clock.EorzeaMinute.ToString());
                    node.SetAttribute("duration", clock.EorzeaDuration.ToString());
                    node.SetAttribute("slot", clock.Slot.ToString());
                    node.SetAttribute("enabled", clock.Enabled.ToString());

                    clockNode.AppendChild(node);
                }
            }

            xmlSettings.Save(filename);
        }

        private void SetXml(string item, string value)
        {
            var node = xmlSettings.SelectSingleNode("/settings/" + item);

            if (node == null)
            {
                node = xmlSettings.CreateElement(item);
                node.InnerText = value;
                xmlSettings.SelectSingleNode("/settings").AppendChild(node);
            }
            else
            {
                node.InnerText = value;
            }
        }

        private string GetXml(string item, string defaultValue = "")
        {
            var node = xmlSettings.SelectSingleNode("/settings/" + item);

            if (node == null)
            {
                return defaultValue;
            }
            else
            {
                return node.InnerText;
            }
        }
    }
}
