using System;
using System.IO;
using System.Net;

namespace VkTools.Common
{
    public class SimpleWebClient
    {
        public static SimpleWebClient New()
        {

            return new SimpleWebClient();
        }

        public string Get(string url)
        {

            var client = new WebClient();

            var data = client.OpenRead(url);

            var reader = new StreamReader(data);
            var rawData = reader.ReadToEnd();

            data.Close();
            reader.Close();

            return rawData;
        }
    }
}
