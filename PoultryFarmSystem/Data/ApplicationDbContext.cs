using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PoultryFarmSystem.Data.Configurations;
using PoultryFarmSystem.Models.Entities;

namespace PoultryFarmSystem.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }   
    
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Batch> Batches { get; set; }
    public DbSet<Bird> Birds { get; set; }
    public DbSet<Cage> Cages { get; set; }
    public DbSet<HealthCard> HealthCards { get; set; }
    public DbSet<Worker> Workers { get; set; }
    
    public int GetCageOccupancyPercentage(int cageId)
    {
        return Database
            .SqlQueryRaw<int>("EXEC GetCageOccupancyPercentage @CageId", 
                new SqlParameter("@CageId", cageId))
            .AsEnumerable()
            .FirstOrDefault();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AssignmentConfiguration());
        modelBuilder.ApplyConfiguration(new BatchConfiguration());
        modelBuilder.ApplyConfiguration(new BirdConfiguration());
        modelBuilder.ApplyConfiguration(new CageConfiguration());
        modelBuilder.ApplyConfiguration(new HealthCardConfiguration());
        modelBuilder.ApplyConfiguration(new WorkerConfiguration());
    }
}