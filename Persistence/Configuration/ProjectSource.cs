using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configuration
{
    class ProjectSourceConfiguration : IEntityTypeConfiguration<ProjectSource>
    {
        public void Configure(EntityTypeBuilder<ProjectSource> builder)
        {
            builder
                .HasKey(ps => ps.ProjectSourceId);

            builder.Property(ps => ps.SourceUrl)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ps => ps.Type)
                .IsRequired()
                .HasDefaultValue(ProjectSourceType.Other);

            builder.HasOne(ps => ps.Project)
                .WithMany(p => p.ProjectSources)
                .HasPrincipalKey(p => p.ProjectId)
                .HasForeignKey(ps => ps.ProjectId);
        }
    }
}
