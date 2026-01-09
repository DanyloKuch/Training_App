using Microsoft.EntityFrameworkCore;
using Training_App.DataAccess.Configuration;
using Training_App.DataAccess.Entity;

namespace Training_App.DataAccess;

public class TrainingAppDbContext(DbContextOptions<TrainingAppDbContext> options) 
    : DbContext(options)
{
    public DbSet<TrainingEntity> Trainings { get; set; }
    public DbSet<ApplicationUserEntity> ApplicationUsers { get; set; }
    public DbSet<ExerciseEntity> Exercises { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
        modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
        modelBuilder.ApplyConfiguration(new TrainingConfiguration());
    }
}

