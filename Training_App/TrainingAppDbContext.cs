using Microsoft.EntityFrameworkCore;
using Training_App.Configuration;
using Training_App.Models;

namespace Training_App;

public class TrainingAppDbContext(DbContextOptions<TrainingAppDbContext> options) 
    : DbContext(options)
{
    public DbSet<Training> Trainings { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Exercise> Exercises { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
        modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
        modelBuilder.ApplyConfiguration(new TrainingConfiguration());
    }
}

