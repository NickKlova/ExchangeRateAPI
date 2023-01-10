using ExchangeRateAPI.Models.RateController;
using Newtonsoft.Json;
using System.Net;

namespace ExchangeRateAPI.Managers.CryptocurrencyRate {
	public class BinanceManager : ICryptocurrencyManager<GetCryptocurrencyResponse> {
		private static readonly HttpClient client = new HttpClient();
		public async Task<GetCryptocurrencyResponse> GetCryptocurrencyRate(string cryptocode) {
			var rate = await GetCryptocurrencyRateFromBinance(cryptocode);
			if (rate == null) {
				return null;
			}

			var response = new GetCryptocurrencyResponse() {
				Code = rate.Code,
				Price = rate.Price
			};
			return response;
		}

		private async Task<Models.Binance.CryptocurrencyRate> GetCryptocurrencyRateFromBinance(string cryptocode) {
			var response = await client.GetAsync("https://api.binance.com/api/v3/ticker/price?symbol=" + cryptocode);
			if (response.StatusCode != HttpStatusCode.OK) {
				return null;
			}

			var json = response.Content.ReadAsStringAsync().Result.ToString();
			if (json == null) {
				return null;
			}
			var rate = JsonConvert.DeserializeObject<Models.Binance.CryptocurrencyRate>(json);
			return rate;
		}
	}
}