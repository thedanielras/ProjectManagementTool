using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.SeedData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var adminUserGuid = new Guid("{3AF87455-F8EA-44B8-A33F-5BC89F433697}");

            var sampleJavaProjectGuid = new Guid("{B7ABABB7-E4BE-4A85-8B7F-C045EE258388}");
            var sampleDotNetProjectGuid = new Guid("{51BA2C30-B20A-4686-971F-4575860EDD5A}");
            var javaDepartmentGuid = new Guid("{E3E81151-2092-4921-8F8C-E0FE3800FA4D}");
            var dotnetDepartmentGuid = new Guid("{6D0484D4-B777-439C-8174-EB2B213349B8}");
            var sampleJavaProjectSourceGuid = new Guid("{12C74E66-D8D1-4966-9C88-18F3666740E8}");
            var sampleDotNetProjectSourceGuid = new Guid("{3B3C7093-D954-488B-930A-4AD6EADD2987}");                                

            var adminUser = new User { UserId = adminUserGuid, Name = "admin", Password = "password" };
            modelBuilder.Entity<User>().HasData(adminUser);

            var javaDepartment = new Department { DepartmentId = javaDepartmentGuid, Name = "Java" };
            var dotnetDepartmetn = new Department { DepartmentId = dotnetDepartmentGuid, Name = ".NET" };
            modelBuilder.Entity<Department>().HasData(javaDepartment, dotnetDepartmetn);

            var javaProject = new Project { ProjectId = sampleJavaProjectGuid, DepartmentId = javaDepartmentGuid, Name = "Aquilla", ResponsibleUserId = adminUserGuid };
            var dotnetProject = new Project { ProjectId = sampleDotNetProjectGuid, DepartmentId = dotnetDepartmentGuid, Name = "PWS", ResponsibleUserId = adminUserGuid };
            modelBuilder.Entity<Project>().HasData(javaProject, dotnetProject);

            var javaProjectSource = new ProjectSource
            {
                ProjectSourceId = sampleJavaProjectSourceGuid,
                SourceUrl = "https://github.com/topics/java",
                Type = ProjectSourceType.Github,
                ProjectId = sampleJavaProjectGuid
            };
            var dotnetProjectSource = new ProjectSource
            {
                ProjectSourceId = sampleDotNetProjectSourceGuid,
                SourceUrl = "https://github.com/topics/dotnet",
                Type = ProjectSourceType.Github,
                ProjectId = sampleDotNetProjectGuid
            };
            modelBuilder.Entity<ProjectSource>().HasData(javaProjectSource, dotnetProjectSource);
        }
    }
}
