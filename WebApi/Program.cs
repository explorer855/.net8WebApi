using Domain.DataContext;
using Domain.Repositories;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using WebApi.Infrastructure.CultureMiddleware;
using WebApi.Infrastructure.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<CosmosDbContext>(optionsBuilder =>
  optionsBuilder
    .UseCosmos(
      connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
      databaseName: "product-store",
      cosmosOptionsAction: options =>
      {
          options.ConnectionMode(Microsoft.Azure.Cosmos.ConnectionMode.Direct);
          options.MaxRequestsPerTcpConnection(16);
          options.MaxTcpConnectionsPerEndpoint(32);
      }));

builder.Services.AddControllers();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CosmosDbContext>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler(opts => { });

app.UseHttpsRedirection();
app.UseMiddleware<RequestCultureMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();

