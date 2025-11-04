using Bank.Domain;
using Microsoft.EntityFrameworkCore;


namespace Bank.Infra.repository
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Item> Itens { get; set; }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ItemConfiguration).Assembly);
            base.OnModelCreating(modelBuilder); 
        }

    }
}
