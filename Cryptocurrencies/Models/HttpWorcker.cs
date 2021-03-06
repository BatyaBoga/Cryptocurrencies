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

        public static CoinInfo GetCoinInfo(string id)
        {
            DataInfo data = HttpWorcker.GetRequestAsync<DataInfo>(@"https://api.coincap.io/v2/assets/" + id).Result;
            return data.data;
        }

        public static PriceChange[] GetPriceInfo(string id)
        {
            DataArr<PriceChange> dataArr = HttpWorcker.GetRequestAsync<DataArr<PriceChange>>(@"https://api.coincap.io/v2/assets/" + id + @"/history?interval=d1").Result;
            PriceChange[] prices = dataArr.data;
            return prices;
        }

        public static Markets[] GetMarkets(string id)
        {
            DataArr<Markets> dataArr = HttpWorcker.GetRequestAsync<DataArr<Markets>>(@"https://api.coincap.io/v2/markets?baseId=" + id).Result;
            Markets[] markets = dataArr.data;
            return markets;
        }
    }
}
