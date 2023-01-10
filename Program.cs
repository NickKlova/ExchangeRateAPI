using ExchangeRateAPI.Managers.BankGovUaManager;
using ExchangeRateAPI.Managers.CryptocurrencyRate;
using ExchangeRateAPI.Managers.CurrencyRate;
using ExchangeRateAPI.Models.RateController;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<ICurrencyManager<GetCurrencyResponse>, BankGovUaManager>();
builder.Services.AddTransient<ICryptocurrencyManager<GetCryptocurrencyResponse>, BinanceManager>();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
