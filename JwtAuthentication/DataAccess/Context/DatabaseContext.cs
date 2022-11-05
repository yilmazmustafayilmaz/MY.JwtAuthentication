using JwtAuthentication.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthentication.DataAccess.Context;

public class DatabaseContext : DbContext
{
    public IConfiguration Configuration { get; }
    public DatabaseContext() { }
    public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=.; database=JwtAuthenticationDb; integrated security=true;");
    }
    public DbSet<User> Users { get; set; }
}
