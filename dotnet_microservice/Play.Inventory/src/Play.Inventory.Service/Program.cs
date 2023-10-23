using Play.Common.Settings;
using Play.Common.MongoDB;
using Play.Inventory.Service.Entities;
using Play.Inventory.Service.Clients;
using Polly;
using Polly.Timeout;

var builder = WebApplication.CreateBuilder(args);

var serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

Extensions.AddMongo(builder.Services)
          .AddMongoRepository<InventoryItem>("inventoryitems");

Random jitterer = new Random();

// Add services to the container.
builder.Services.AddHttpClient<CatalogClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5048");
})
.AddTransientHttpErrorPolicy(builders => builders.Or<TimeoutRejectedException>().WaitAndRetryAsync(
      5,
      retryApptempt => TimeSpan.FromSeconds(Math.Pow(2, retryApptempt)) + TimeSpan.FromMilliseconds(jitterer.Next(0, 1000)),
      onRetry: (outcome, timespan, retryAttempt) =>
      {
          var serviceProvider = builder.Services.BuildServiceProvider();
          serviceProvider.GetService<ILogger<CatalogClient>>()?
          .LogWarning($"Delaying for {timespan.TotalSeconds} seconds, then making retry {retryAttempt}");
      }

      ))
.AddTransientHttpErrorPolicy(builders => builders.Or<TimeoutRejectedException>().CircuitBreakerAsync(
      3,
      TimeSpan.FromSeconds(15),
      onBreak: (outcome, timespan) =>
      {
          var serviceProvider = builder.Services.BuildServiceProvider();
          serviceProvider.GetService<ILogger<CatalogClient>>()?
          .LogWarning($"Openning the circuit for {timespan.TotalSeconds} seconds");

      },
      onReset: () =>
      {
          var serviceProvider = builder.Services.BuildServiceProvider();
          serviceProvider.GetService<ILogger<CatalogClient>>()?
          .LogWarning($"Closing the circuit");

      }
  ))
.AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(1));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
