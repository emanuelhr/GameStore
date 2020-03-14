using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.EntityConfigurations
{
    public class DeveloperEntityConfig : IEntityTypeConfiguration<DeveloperEntity>
    {
        public void Configure(EntityTypeBuilder<DeveloperEntity> builder)
        {
            builder.Property(d => d.Headquarters)
                .HasMaxLength(50)
                .HasColumnType("VARCHAR")
                .IsRequired();

            builder.Property(d => d.Name)
                .HasMaxLength(20)
                .HasColumnType("VARCHAR")
                .IsRequired();
        }
    }
}
