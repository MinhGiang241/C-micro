using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Mango.Services.ProductAPI.AppServices;
using Mango.Services.ProductAPI.GraphqlBasic;
using Mango.Services.ProductAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions();


// var connectionString = builder.Configuration.GetConnectionString("ConnectMongo");
// var database = builder.Configuration.GetConnectionString("Database");

// MongoHelper.ConnectToMongoService(connectionString!, database!);

// var client = new MongoClient(connectionString);

builder.Services.Configure<DataSetting>(
   builder.Configuration.GetSection(nameof(DataSetting))
);
builder.Services.AddScoped<DataServices>();

builder.Services.AddScoped<IProductService, ProSer>();
builder.Services.AddScoped<Query>();
builder.Services.AddGraphQLServer()
                /* .AddType<ProductType>() */
                .AddQueryType<Query>();

/* AddGraphQL(p => SchemaBuilder.New().AddServices(p)
              .AddType<ProductType>()
              .AddQueryType<Query>()
              .Create()); */

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // app.UseSwagger();
    // app.UseSwaggerUI();
    app.UsePlayground(new PlaygroundOptions
    {
        QueryPath = "/api",
        Path = "/playground"
    });
}

app.UseHttpsRedirection();

app.MapGraphQL("/api");
// app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
