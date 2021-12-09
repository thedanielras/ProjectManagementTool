using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configuration
{
    class DepartmentConfiguration: IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                .HasKey(d => d.DepartmentId);

            builder
                 .Property(d => d.Name)
                 .IsRequired()
                 .HasMaxLength(200);

            builder
                .HasMany(d => d.Projects)
                .WithOne(p => p.Department)
                .HasPrincipalKey(d => d.DepartmentId)
                .HasForeignKey(p => p.DepartmentId);
        }
    }
}
