﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ProjectManagementToolDbContext))]
    [Migration("20211119153045_SeedDataMigration")]
    partial class SeedDataMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            DepartmentId = new Guid("e3e81151-2092-4921-8f8c-e0fe3800fa4d"),
                            Name = "Java"
                        },
                        new
                        {
                            DepartmentId = new Guid("6d0484d4-b777-439c-8174-eb2b213349b8"),
                            Name = ".NET"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProjectId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = new Guid("b7ababb7-e4be-4a85-8b7f-c045ee258388"),
                            DepartmentId = new Guid("e3e81151-2092-4921-8f8c-e0fe3800fa4d"),
                            Name = "Aquilla",
                            UserId = new Guid("3af87455-f8ea-44b8-a33f-5bc89f433697")
                        },
                        new
                        {
                            ProjectId = new Guid("51ba2c30-b20a-4686-971f-4575860edd5a"),
                            DepartmentId = new Guid("6d0484d4-b777-439c-8174-eb2b213349b8"),
                            Name = "PWS",
                            UserId = new Guid("3af87455-f8ea-44b8-a33f-5bc89f433697")
                        });
                });

            modelBuilder.Entity("Domain.Entities.ProjectSource", b =>
                {
                    b.Property<Guid>("ProjectSourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SourceUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.HasKey("ProjectSourceId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectSource");

                    b.HasData(
                        new
                        {
                            ProjectSourceId = new Guid("12c74e66-d8d1-4966-9c88-18f3666740e8"),
                            ProjectId = new Guid("b7ababb7-e4be-4a85-8b7f-c045ee258388"),
                            SourceUrl = "https://github.com/topics/java",
                            Type = 0
                        },
                        new
                        {
                            ProjectSourceId = new Guid("3b3c7093-d954-488b-930a-4ad6eadd2987"),
                            ProjectId = new Guid("51ba2c30-b20a-4686-971f-4575860edd5a"),
                            SourceUrl = "https://github.com/topics/dotnet",
                            Type = 0
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("3af87455-f8ea-44b8-a33f-5bc89f433697"),
                            Name = "admin",
                            Password = "password"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Project", b =>
                {
                    b.HasOne("Domain.Entities.Department", "Department")
                        .WithMany("Projects")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.ProjectSource", b =>
                {
                    b.HasOne("Domain.Entities.Project", "Project")
                        .WithMany("ProjectSources")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
