using InfrustuctureData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrustuctureData.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<DataStudent>
    {
        public void Configure(EntityTypeBuilder<DataStudent> builder)
        {
            builder.HasKey(_ => _.Id);
        }
    }
}
