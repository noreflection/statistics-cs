using Microsoft.EntityFrameworkCore;
using Statistics.Shared;

namespace Statistics.Server.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<AbsWorkout> AbsWorkouts { get; set; }
    }
}