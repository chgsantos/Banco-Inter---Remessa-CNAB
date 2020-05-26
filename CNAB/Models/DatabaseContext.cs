using CNAB.Models.Entity;
using CNAB.Models.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CNAB.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }
        
        public DbSet<Pagamento> Pagamentos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PagamentoConfiguration());
            base.OnModelCreating(builder);
        }
    }
}