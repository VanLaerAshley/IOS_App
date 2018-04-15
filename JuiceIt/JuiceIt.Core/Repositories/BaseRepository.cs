using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JuiceIt.Core.Repositories
{
    public class BaseRepository
    {
        private HttpClient CreateHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        protected async Task<T> GetAsync<T>(string url)
        {
            using (HttpClient client = CreateHttpClient())
            {
                try
                {
                    //   var json = await client.GetStringAsync(url);
                    var json = Task.Run(() => client.GetStringAsync(url));
                    var r = json.Result;
                    return await Task.Run(() => JsonConvert.DeserializeObject<T>(r));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return default(T);
                }
            }
        }
    }
}
