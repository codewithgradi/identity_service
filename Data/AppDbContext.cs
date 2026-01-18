using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions options) : base(options)
  {
  }
  public DbSet<User> Users { get; set; }
  public DbSet<Course> Courses { get; set; }


  //Relationships: One user has many Courses
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Course>()
    .HasOne(c => c.User)
    .WithMany(u => u.Courses)
    .HasForeignKey(u => u.UserId);

  }
}