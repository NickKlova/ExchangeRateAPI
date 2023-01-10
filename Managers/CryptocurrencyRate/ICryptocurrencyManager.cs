using ExchangeRateAPI.Models.RateController;

namespace ExchangeRateAPI.Managers.CryptocurrencyRate {
	public interface ICryptocurrencyManager<T> {
		public Task<T> GetCryptocurrencyRate(string cryptocode);
	}
}
