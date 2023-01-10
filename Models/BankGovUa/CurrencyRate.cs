using Newtonsoft.Json;

namespace ExchangeRateAPI.Models.BankGovUa {
	public class CurrencyRate {
		[JsonProperty("rate")]
		public string? Rate { get; set; }

		[JsonProperty("cc")]
		public string? Currency { get; set; }

		[JsonProperty("exchangedate")]
		public string? ExchangeDate { get; set; }
	}
}
