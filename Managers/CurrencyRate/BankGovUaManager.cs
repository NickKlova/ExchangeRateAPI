using ExchangeRateAPI.Managers.CurrencyRate;
using ExchangeRateAPI.Models.RateController;
using Newtonsoft.Json;

namespace ExchangeRateAPI.Managers.BankGovUaManager {
	public class BankGovUaManager : ICurrencyManager<GetCurrencyResponse> {
		private string _url = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
		private HttpClient _client { get; set; }
		public BankGovUaManager() {
			_client = new HttpClient();
		}

		public async Task<GetCurrencyResponse> GetCurrencyRate(string currencyId) {
			var rates = await GetListOfCurrencyRates();
			var rate = rates.Where(x => x.Currency == currencyId).FirstOrDefault();
			if(rate == null) {
				return null;
			}

			var response = new GetCurrencyResponse() {
				Currency = rate.Currency,
				ExchangeDate = rate.ExchangeDate,
				Rate = rate.Rate,
			};
			return response;
		}

		private async Task<List<Models.BankGovUa.CurrencyRate>> GetListOfCurrencyRates() {
			var response = await _client.GetAsync(_url);
			var json = response.Content.ReadAsStringAsync().Result.ToString() ?? string.Empty;
			var rates = JsonConvert.DeserializeObject<List<Models.BankGovUa.CurrencyRate>>(json);

			return rates ?? new List<Models.BankGovUa.CurrencyRate>();
		}
	}
}
