using AspNetCore.Identity.CosmosDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace AuthApi.Data.AuthDbContext
{
    /// <summary>
    /// Azure Cosmos DB Context
    /// for setting up Entities and its relationships
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class AuthDbContext : CosmosIdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public AuthDbContext(DbContextOptions options) : base(options) { 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAutoscaleThroughput(1000);
        }
    }
}
