﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ProjectManagementToolDbContext))]
    partial class ProjectManagementToolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.ToTable("Departments");

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

                    b.Property<Guid?>("ForeignResponsibleUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<Guid>("ResponsibleUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProjectId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ForeignResponsibleUserId");

                    b.HasIndex("ResponsibleUserId");

                    b.HasIndex("Name", "DepartmentId")
                        .IsUnique();

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = new Guid("b7ababb7-e4be-4a85-8b7f-c045ee258388"),
                            DepartmentId = new Guid("e3e81151-2092-4921-8f8c-e0fe3800fa4d"),
                            Name = "Aquilla",
                            ResponsibleUserId = new Guid("3af87455-f8ea-44b8-a33f-5bc89f433697")
                        },
                        new
                        {
                            ProjectId = new Guid("51ba2c30-b20a-4686-971f-4575860edd5a"),
                            DepartmentId = new Guid("6d0484d4-b777-439c-8174-eb2b213349b8"),
                            Name = "PWS",
                            ResponsibleUserId = new Guid("3af87455-f8ea-44b8-a33f-5bc89f433697")
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
                        .HasDefaultValue(3);

                    b.HasKey("ProjectSourceId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectSources");

                    b.HasData(
                        new
                        {
                            ProjectSourceId = new Guid("12c74e66-d8d1-4966-9c88-18f3666740e8"),
                            ProjectId = new Guid("b7ababb7-e4be-4a85-8b7f-c045ee258388"),
                            SourceUrl = "https://github.com/topics/java",
                            Type = 1
                        },
                        new
                        {
                            ProjectSourceId = new Guid("3b3c7093-d954-488b-930a-4ad6eadd2987"),
                            ProjectId = new Guid("51ba2c30-b20a-4686-971f-4575860edd5a"),
                            SourceUrl = "https://github.com/topics/dotnet",
                            Type = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("703cccc6-2a7d-4d31-93be-0809c77b7ebf"),
                            Name = "user"
                        },
                        new
                        {
                            RoleId = new Guid("ede5e059-6960-410c-8164-224660d6705b"),
                            Name = "admin"
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

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("3af87455-f8ea-44b8-a33f-5bc89f433697"),
                            Name = "admin",
                            Password = "password",
                            RoleId = new Guid("ede5e059-6960-410c-8164-224660d6705b")
                        });
                });

            modelBuilder.Entity("Domain.Entities.Project", b =>
                {
                    b.HasOne("Domain.Entities.Department", "Department")
                        .WithMany("Projects")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "ForeignResponsibleUser")
                        .WithMany()
                        .HasForeignKey("ForeignResponsibleUserId");

                    b.HasOne("Domain.Entities.User", "ResponsibleUser")
                        .WithMany("Projects")
                        .HasForeignKey("ResponsibleUserId")
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

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
