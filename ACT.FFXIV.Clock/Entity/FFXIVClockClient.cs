using System;
using System.Net;
using System.IO;

namespace ACT.FFXIV.Clock
{
    class FFXIVClockClient
    {
        private const string JSON_ITEM_LIST_STRING = "__JSON_ITEM_LIST=";
        private const string FFXIV_CLOCK_URL = "http://www.ffxivclock.com/";

        public FFXIVClockClient()
        {
        }

        public void Get(string url, out int statusCode, out string content)
        {
            var request = (HttpWebRequest)WebRequest.Create(FFXIV_CLOCK_URL + url);
            var response = (HttpWebResponse)request.GetResponse();

            statusCode = (int)response.StatusCode;
            content = string.Empty;

            try
            {
                using (var s = new StreamReader(response.GetResponseStream()))
                {
                    content = s.ReadToEnd();
                }
            }
            catch
            {
                // ignore error
            }
        }

        public string FindItemListJsonURL()
        {
            string content;
            int statusCode;
            Get(string.Empty, out statusCode, out content);

            if (statusCode != 200)
                return null;

            content = content.Replace(" ", "");

            if (!content.Contains(JSON_ITEM_LIST_STRING))
                return null;

            content = content.Substring(content.IndexOf(JSON_ITEM_LIST_STRING) + JSON_ITEM_LIST_STRING.Length);

            char quota = content[0];
            content = content.Substring(1, content.IndexOf(quota, 1) - 1);

            return content;
        }
    }
}
