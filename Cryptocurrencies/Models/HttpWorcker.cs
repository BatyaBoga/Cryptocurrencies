using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Cryptocurrencies.Models
{

    
    static class HttpWorcker
    {
        static HttpClient client = new HttpClient();

        public static async Task<T> GetRequestAsync<T>(string path)
        {
            T? data = default(T);

            HttpResponseMessage response = await client.GetAsync(path, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<T>(result);
            }

            return data!;
        }

        public static CoinInfo[] GetCoinsInfo()
        {
            DataArr<CoinInfo> dataArr = HttpWorcker.GetRequestAsync<DataArr<CoinInfo>>(@"https://api.coincap.io/v2/assets").Result;
            CoinInfo[] coins = dataArr.data;
            return coins;
        }
    }
}
