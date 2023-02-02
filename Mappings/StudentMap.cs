using GpaCalculator.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GpaCalculator.Api.Mappings;

public class StudentMap : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);  
        builder.HasMany((t => t.Grades)).WithOne(t=>t.student).HasForeignKey(t => t.StudentId);     
    }
}