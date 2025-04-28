using Microsoft.EntityFrameworkCore;
using Database.Model;  // Import your models here

namespace Database.Context
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<LabInventoryContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    }

    // DbSets representing tables in the database
    public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Deadline> Deadline { get; set; }
        public DbSet<Document> Document { get; set; }
        // Add other DbSets for your models as needed
    }
}
