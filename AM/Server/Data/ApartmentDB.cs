
namespace AM.Server.Data;

public class ApartmentDB : DbContext
{
    public ApartmentDB(DbContextOptions<ApartmentDB> opt) : base(opt) { }

    public DbSet<User> User { get; set; }
    public DbSet<ApartmentInfo> ApartmentInfo { get; set; }

}

