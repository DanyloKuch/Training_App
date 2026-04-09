using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Training_App.DataAccess.Entity;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Training_App.DataAccess;

public class TrainingAppDbContext : IdentityDbContext<UserEntity, IdentityRole<Guid>, Guid>
{
    public TrainingAppDbContext(DbContextOptions<TrainingAppDbContext> options): base(options){}
    public DbSet<TrainingEntity> Trainings => Set<TrainingEntity>();
    public DbSet<UserEntity> ApplicationUsers => Set<UserEntity>();
    public DbSet<ExerciseEntity> Exercises => Set<ExerciseEntity>();
    public DbSet<ExerciseMusclesEntity> ExercisesMuscles => Set<ExerciseMusclesEntity>();
    public DbSet<ExerciseSetEntity> ExersiseSets => Set<ExerciseSetEntity>();
    public DbSet<MusclesEnity>  MusclesEnities => Set<MusclesEnity>();
    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrainingAppDbContext).Assembly);
    }
}

