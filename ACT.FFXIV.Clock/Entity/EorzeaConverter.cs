using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.FFXIV.Clock
{
    public static class EorzeaConverter
    {
        public const double EORZEA_MULTIPLIER = 3600D / 175D;
        private static readonly long EPOCH_TIME = new DateTime(1970, 1, 1).Ticks;

        public static DateTime ToEorzeaTime(this DateTime date)
        {
            long epochTicks = date.ToUniversalTime().Ticks - EPOCH_TIME;
            long eorzeaTicks = (long)Math.Round(epochTicks * EORZEA_MULTIPLIER);
            return new DateTime(eorzeaTicks);
        }

        public static DateTime ToEarthTime(this DateTime date)
        {
            var epochTicks = (long)Math.Round(date.Ticks / EORZEA_MULTIPLIER);
            var earthTicks = epochTicks + EPOCH_TIME;
            var utc = new DateTime(earthTicks, DateTimeKind.Utc);
            return utc.ToLocalTime();
        }

        public static DateTime CreateByEorzeaTime(int h, int m, int s, bool ignoreNegative = false)
        {
            DateTime et = DateTime.Now.ToEorzeaTime();
            int diff = ((h - et.Hour) * 60 * 60) + ((m - et.Minute) * 60) + (s - et.Second);

            if (!ignoreNegative && diff < 0)   // next day
                diff += 24 * 60 * 60;

            et = et.AddSeconds(diff);

            return et;
        }
    }
}
