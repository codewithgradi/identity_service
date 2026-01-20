using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<AppUser>
{
  public AppDbContext(
    DbContextOptions<AppDbContext>
     options)
     : base(options)
  {

  }
  public DbSet<AppUser> AppUsers { get; set; }
}