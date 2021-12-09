using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configuration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.UserId);     

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .HasMany(u => u.Projects)
                .WithOne(p => p.ResponsibleUser)
                .HasForeignKey(p => p.ResponsibleUserId)
                .HasPrincipalKey(u => u.UserId);
        }
    }
}
