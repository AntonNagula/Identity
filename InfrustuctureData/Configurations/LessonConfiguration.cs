using InfrustuctureData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrustuctureData.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<DataLesson>
    {
        public void Configure(EntityTypeBuilder<DataLesson> builder)
        {

            builder.HasKey(_ => _.Id);
            builder.HasOne(p => p.Student).WithMany(t => t.Lessons).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
