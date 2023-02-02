using GpaCalculator.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GpaCalculator.Api.Mappings;

public class GradeMap : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.HasKey(x => x.Id); 
        builder.HasOne(x=>x.subject).WithMany().HasForeignKey(t=>t.SubjectId);
    }
}