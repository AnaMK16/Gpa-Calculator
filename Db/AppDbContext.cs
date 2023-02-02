using GpaCalculator.Api.Mappings;
using GpaCalculator.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GpaCalculator.Api.Db;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new GradeMap());
        builder.ApplyConfiguration(new StudentMap());
        base.OnModelCreating(builder);
    }
}