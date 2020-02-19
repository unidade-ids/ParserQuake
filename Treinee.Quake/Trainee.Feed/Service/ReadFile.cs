using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Trainee.Feed.Service
{
    public class ReadFile
    {
        public async Task<string> Read()
        {

            string result = string.Empty;

            using (var client = new HttpClient())
            {
                var url = GetURL();

                result = await client.GetStringAsync(url);
            }

            return result;
        }

        private string GetURL()
        {
            var url = ConfigurationManager.AppSettings["parser"];

            if (string.IsNullOrEmpty(url))
                throw new ArgumentException("Verifique se a url do parser está devidamente configurada.");

            return url;
        }
    }
}
