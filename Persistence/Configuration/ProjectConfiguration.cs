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
