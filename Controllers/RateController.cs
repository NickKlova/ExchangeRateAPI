using ExchangeRateAPI.Managers.CryptocurrencyRate;
using ExchangeRateAPI.Managers.CurrencyRate;
using ExchangeRateAPI.Models.RateController;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRateAPI.Controllers {
	[Route("api/rate/")]
	[ApiController]
	public class RateController : ControllerBase {
		private ICurrencyManager<GetCurrencyResponse> _currencyManager { get; set; }
		private ICryptocurrencyManager<GetCryptocurrencyResponse> _cryptoManager { get; set; }
		public RateController(ICurrencyManager<GetCurrencyResponse> currencyManager, ICryptocurrencyManager<GetCryptocurrencyResponse> cryptoManager) {
			_currencyManager = currencyManager;
			_cryptoManager = cryptoManager;
		}
		[HttpGet("currency")]
		public async Task<IActionResult> Get([FromQuery] string currencycode) {
			try {
				var rate = await _currencyManager.GetCurrencyRate(currencycode);
				if (rate == null) {
					return StatusCode(404, "{\n \"msg\": \"not found\" \n}");
				}
				return StatusCode(200, rate);
			} catch (Exception e) {
				return StatusCode(500, e.Message);
			}
		}

		[HttpGet("cryptocurrency")]
		public async Task<IActionResult> Get([FromQuery] string firstcode, [FromQuery] string secondcode) {
			try {
				var rate = await _cryptoManager.GetCryptocurrencyRate(firstcode + secondcode);
				if (rate == null) {
					return StatusCode(404, "{\n \"msg\": \"not found\" \n}");
				}
				return StatusCode(200, rate);
			} catch (Exception e) {
				return StatusCode(500, e.Message);
			}
		}
	}
}
