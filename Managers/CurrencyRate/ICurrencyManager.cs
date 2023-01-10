namespace ExchangeRateAPI.Managers.CurrencyRate {
	public interface ICurrencyManager<T> {
		public Task<T> GetCurrencyRate(string currencyId);
	}
}
