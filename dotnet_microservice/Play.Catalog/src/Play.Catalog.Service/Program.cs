using Play.Catalog.Service.Entities;
using Play.Common.Settings;
using Play.Common.MongoDB;
using Play.Common.MassTransit;

var builder = WebApplication.CreateBuilder(args);


var serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

// Extensions.AddMongo(builder.Services)
//           .AddMongoRepository<Item>("items");
// MassExtensions.AddMassTransitWithRabbitMq(builder.Services);

builder.Services
.AddMongo()
.AddMongoRepository<Item>("items")
.AddMassTransitWithRabbitMq();
// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
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
