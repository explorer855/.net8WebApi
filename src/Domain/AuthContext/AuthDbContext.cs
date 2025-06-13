using AspNetCore.Identity.CosmosDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Domain.DataContext
{
    /// <summary>
    /// Azure Cosmos DB Context
    /// for setting up Entities and its relationships
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AuthDbContext : CosmosIdentityDbContext<IdentityUser, IdentityRole, string>
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
