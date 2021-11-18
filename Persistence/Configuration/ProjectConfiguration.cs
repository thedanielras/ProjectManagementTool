using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ProjectConfiguration: IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .HasKey(p => p.ProjectId);
                       
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .HasOne(p => p.Department)
                .WithMany(d => d.Projects)
                .HasPrincipalKey(d => d.DepartmentId)
                .HasForeignKey(p => p.DepartmentId);

            builder
                .HasMany(p => p.ProjectSources)
                .WithOne(ps => ps.Project)
                .HasPrincipalKey(p => p.ProjectId)
                .HasForeignKey(ps => ps.ProjectId);             

                        

            /*
            builder.HasData(
            new Project
            {
                ProjectId = -1,
                Name = "SomeProject1",
                Department = new Department 
                { 
                  DepartmentId = -1, 
                  Name = ".NET" 
                },
                ProjectSources = new List<ProjectSource>
                {
                    new ProjectSource
                    {
                          ProjectSourceId = -1,
                        SourceUrl = "http://test.com",
                        Type = ProjectSourceType.Other
                    }
                }
            },
            new Project
            {
                ProjectId = -1,
                Name = "SomeProject2",
                Department = new Department
                {
                    DepartmentId = -1,
                    Name = "Java"
                },
                ProjectSources = new List<ProjectSource>
                {
                    new ProjectSource
                    {
                        ProjectSourceId = -1,
                        SourceUrl = "http://test.com",
                        Type = ProjectSourceType.Other
                    }
                }
            });
            */
        }
    }
}
