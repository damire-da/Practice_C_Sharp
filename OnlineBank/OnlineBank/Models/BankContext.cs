using Microsoft.EntityFrameworkCore;

namespace OnlineBank.Models
{
    public class BankContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        

        public BankContext(DbContextOptions<BankContext> option) : base(option)
        {
            Database.EnsureCreated();
        }
    }
}
