using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public class HttpService
    {
        public async Task SendAsync(string url,HttpMethod method,HttpContent content = null)
        {
            var request = new HttpRequestMessage(method, url);
            if (content != null) request.Content = content;

            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK) 
                {
                    var body = response.Content.ReadAsStringAsync();
                }
            }

        }

        private HttpClient DefaultHttpClient()
        {
            return new HttpClient();
        }
    }
}
