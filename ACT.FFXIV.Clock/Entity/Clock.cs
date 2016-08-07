using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ACT.FFXIV.Clock
{
    internal class Clock
    {
        public static List<Clock> List = new List<Clock>();

        // ===
        public bool Enabled
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Region
        {
            get;
            set;
        }

        public string Aetheryte
        {
            get;
            set;
        }

        public string Coordinate
        {
            get;
            set;
        }

        public string Job
        {
            get;
            set;
        }

        public int EorzeaHour
        {
            get;
            set;
        }

        public int EorzeaMinute
        {
            get;
            set;
        }

        public int EorzeaDuration
        {
            get;
            set;
        }

        public int Slot
        {
            get;
            set;
        }

        public string TimeDiff
        {
            get
            {
                int totalSeconds = GetTimeDiff();

                int m = totalSeconds / 60;
                int s = totalSeconds % 60;

                return m.ToString("00") + "m " + s.ToString("00") + "s";
            }
        }

        public string TimeDiffInDuration
        {
            get
            {
                DateTime et = EorzeaConverter.CreateByEorzeaTime(EorzeaHour, EorzeaMinute, 0, true).AddMinutes(EorzeaDuration);

                int diff = (int)((et.ToEarthTime() - DateTime.Now).TotalSeconds);

                int m = diff / 60;
                int s = diff % 60;

                return m.ToString("00") + "m " + s.ToString("00") + "s";
            }
        }

        public string Status
        {
            get
            {
                // in duration
                if (IsInDuration)
                {

                    return "Active: " + TimeDiffInDuration + " remaining";
                }

                return "Inactive";
            }
        }

        public bool IsInDuration
        {
            get
            {
                DateTime et = EorzeaConverter.CreateByEorzeaTime(EorzeaHour, EorzeaMinute, 0, true);
                int diff = GetTimeDiff(true);

                return et.ToEarthTime() < DateTime.Now && Math.Abs(diff) < EorzeaDuration * 60 / EorzeaConverter.EORZEA_MULTIPLIER;
            }
        }

        public DateTime LastAlert
        {
            get;
            set;
        }

        public DateTime NextPreAlert
        {
            get;
            set;
        }

        public Clock() :
            this(false, "(New Node)", "", "", "0,0", "MIN", 0, 0, 55, 0)
        {
        }

        public Clock(bool enabled, string name, string region, string aetheryte, string coordinate, string job, int h, int m, int duration, int slot)
        {
            this.Enabled = enabled;
            this.Name = name;
            this.Region = region;
            this.Aetheryte = aetheryte;
            this.Coordinate = coordinate;
            this.Job = job;
            this.EorzeaHour = h;
            this.EorzeaMinute = m;
            this.EorzeaDuration = duration;
            this.Slot = slot;
            this.LastAlert = default(DateTime);
            this.NextPreAlert = default(DateTime);
        }

        public int GetTimeDiff(bool ignoreNegative = false)
        {
            DateTime et = EorzeaConverter.CreateByEorzeaTime(EorzeaHour, EorzeaMinute, 0, ignoreNegative);
            return (int)Math.Abs((et.ToEarthTime() - DateTime.Now).TotalSeconds);
        }

        private void DoAlert()
        {
            try
            {
                // play alert sound
                using (SoundPlayer snd = new SoundPlayer(Plugin.Instance.settings.AlertSound))
                {
                    snd.Play();
                }
            }
            catch
            {
                System.Media.SystemSounds.Asterisk.Play();
            }
        }

        public void Alert()
        {
            if (!IsInDuration)
                return;

            // check if alerted once
            if (LastAlert != default(DateTime) && 
                LastAlert.AddSeconds(EorzeaDuration * EorzeaConverter.EORZEA_MULTIPLIER) > EorzeaConverter.CreateByEorzeaTime(EorzeaHour, EorzeaMinute, 0, true).ToEarthTime())
                return;

            LastAlert = DateTime.Now;

            // start alert
            DoAlert();
        }

        public void PreAlert()
        {
            if (IsInDuration)
                return;

            if (NextPreAlert != default(DateTime) && NextPreAlert > DateTime.Now)
                return;

            DateTime et = EorzeaConverter.CreateByEorzeaTime(EorzeaHour, EorzeaMinute, 0);

            if ((et.ToEarthTime() - DateTime.Now).TotalSeconds > Plugin.Instance.settings.AlertBefore * 3)
                return;

            NextPreAlert = DateTime.Now.AddSeconds(Plugin.Instance.settings.AlertBefore * 3);

            // start alert
            DoAlert();
        }
    }
}

