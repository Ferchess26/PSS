using Microsoft.EntityFrameworkCore;
using PV_app;
using PV_app.Models;
using System.Linq;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(App.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users");

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.userName).HasColumnName("userName");
            entity.Property(e => e.password).HasColumnName("password");
            entity.Property(e => e.firstName).HasColumnName("firstName");
            entity.Property(e => e.lastName).HasColumnName("lastName");
            entity.Property(e => e.position).HasColumnName("position");
            entity.Property(e => e.email).HasColumnName("email");
            entity.Property(e => e.profilePicture).HasColumnName("profilePicture");
        });
    }

    public User GetUser(string userName, string password)
    {
        var user = this.Users
            .Where(u => u.userName == userName && u.password == password)
            .Select(u => new User
            {
                userName = u.userName,
                password = u.password,
                firstName = u.firstName
            })
            .FirstOrDefault();

        return user;
    }

}
