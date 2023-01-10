using Newtonsoft.Json;

namespace ExchangeRateAPI.Models.Binance {
	public class CryptocurrencyRate {
		[JsonProperty("symbol")]
		public string? Code { get; set; }

		[JsonProperty("price")]
		public string? Price { get; set; }
	}
}
