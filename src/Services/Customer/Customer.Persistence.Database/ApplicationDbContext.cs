using Customer.Domain;
using Microsoft.EntityFrameworkCore;

using Customer.Persistence.Database.Configuration;

namespace Customer.Persistence.Database
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Database schema
            builder.HasDefaultSchema("Customer");

            // Model Contraints
            ModelConfig(builder);
        }

        

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new ClientConfiguration(modelBuilder.Entity<Client>());
        }
    }
}
