
using AspNetCore.Identity.CosmosDb.Extensions;
using Domain.DataContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;

namespace AuthApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContextFactory<AuthDbContext>(optionsBuilder =>
              optionsBuilder
                .UseCosmos(
                  connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
                  databaseName: "identity-db",
                  cosmosOptionsAction: options =>
                  {
                      options.ConnectionMode(Microsoft.Azure.Cosmos.ConnectionMode.Gateway);
                      options.MaxRequestsPerTcpConnection(16);
                      options.MaxTcpConnectionsPerEndpoint(32);
                  }));

            builder.Services.AddCosmosIdentity<AuthDbContext, IdentityUser, IdentityRole, string>(
                  options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI() // Use this if Identity Scaffolding is in use
                .AddDefaultTokenProviders();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseMvc();
                app.UseStaticFiles();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
